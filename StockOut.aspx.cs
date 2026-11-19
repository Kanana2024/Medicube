using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Medicube
{
    public partial class StockOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMedicines();
                LoadStockInHistory();
            }

        }
        private void LoadMedicines()
        {
            string sql = "SELECT MedicineID, MedicineName FROM Medicines";

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ELITEBOOK\Documents\Projects\Medicube\App_Data\medicubedb.mdf; Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();

            ddlMedicine.DataSource = dr;
            ddlMedicine.DataTextField = "MedicineName";
            ddlMedicine.DataValueField = "MedicineID";
            ddlMedicine.DataBind();

            dr.Close();
            con.Close();

            ddlMedicine.Items.Insert(0, new ListItem("-- Select Medicine --", "0"));
        }
        // Load stock-in history
        private void LoadStockInHistory()
        {
            string sql = @"
            SELECT
                st.TransactionID,
                ml.MedicineName,
                ml.BatchNumber,
                st.Quantity,
                st.TransactionDate,
                st.Notes
            FROM StockTransactions st
            INNER JOIN MedicineList ml
                ON st.MedicineID = ml.MedicineID
            WHERE st.TransactionType = 'OUT'
            ORDER BY st.TransactionID DESC";

            using (SqlConnection con = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ELITEBOOK\Documents\Projects\Medicube\App_Data\medicubedb.mdf; Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        gvStockOut.DataSource = dr;
                        gvStockOut.DataBind();
                    }
                }
            }
        }

       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int quantity = Convert.ToInt32(txtQuantity.Text);
            DateTime dateIssued = Convert.ToDateTime(txtDateIssued.Text);
            int medicineID = Convert.ToInt32(ddlMedicine.SelectedValue);
            int userID = Convert.ToInt32(Session["UserID"]);

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ELITEBOOK\Documents\Projects\Medicube\App_Data\medicubedb.mdf; Integrated Security=True";

            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            SqlTransaction transaction = con.BeginTransaction();

            // Update medicine quantity
            string updateQuery = @"
            UPDATE Medicines
            SET QuantityInStock = QuantityInStock - @Quantity
            WHERE MedicineID = @MedicineID";

            SqlCommand cmd = new SqlCommand(updateQuery, con, transaction);

            cmd.Parameters.AddWithValue("@Quantity", quantity);
            cmd.Parameters.AddWithValue("@MedicineID", medicineID);

            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == 0)
            {
                transaction.Rollback();
                con.Close();

                lblMessage.Text = "Medicine not found.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Insert stock transaction
            string insertQuery = @"
            INSERT INTO StockTransactions
            (MedicineID, UserID, TransactionType, Quantity, TransactionDate, Notes)
            VALUES
            (@MedicineID, @UserID, 'OUT', @Quantity, @TransactionDate, @Notes)";

            SqlCommand cmd2 = new SqlCommand(insertQuery, con, transaction);

            cmd2.Parameters.AddWithValue("@MedicineID", medicineID);
            cmd2.Parameters.AddWithValue("@UserID", userID);
            cmd2.Parameters.AddWithValue("@Quantity", quantity);
            cmd2.Parameters.AddWithValue("@TransactionDate", dateIssued);
            cmd2.Parameters.AddWithValue("@Notes", txtNotes.Text.Trim());

            cmd2.ExecuteNonQuery();

            transaction.Commit();

            con.Close();

            lblMessage.Text = "Stock received successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            ClearForm();
            LoadStockInHistory();
        }
        // Clear form
        private void ClearForm()
        {
            ddlMedicine.SelectedIndex = 0;
            txtQuantity.Text = "";
            txtDateIssued.Text = DateTime.Now.ToString("yyyy-MM-dd");
            txtNotes.Text = "";
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblMessage.Text = "";
        }
    }
}