using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Medicube
{
    public partial class ViewMedicine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMedicines();
            }
        }



        private void LoadMedicines()
        {
            
            string sql = "SELECT * FROM MedicineList ORDER BY MedicineID DESC";

            // Create connection
            SqlConnection con = new SqlConnection();
            // Connection string
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();
            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);


            // Create DataAdapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Create DataTable
            DataTable dt = new DataTable();

            // Retrieve data
            da.Fill(dt);
            gvMedicines.DataSource = dt;
            gvMedicines.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM MedicineList WHERE MedicineName LIKE @Search OR BatchNumber LIKE @Search ORDER BY MedicineID DESC";
            // Create connection
            SqlConnection con = new SqlConnection();
            // Connection string
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();
            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Search", "%" + txtSearch.Text.Trim() + "%");
            // Create DataAdapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Create DataTable
            DataTable dt = new DataTable();

            // Retrieve data
            da.Fill(dt);
            gvMedicines.DataSource = dt;
            gvMedicines.DataBind();

            if (gvMedicines.Rows.Count == 0)
            {
                // lblMessage.Text = "No medicines found.";
                // lblMessage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                // lblMessage.Text = "Search results found.";
                //lblMessage.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadMedicines();
        }
        protected void gvMedicines_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row to edit mode
            gvMedicines.EditIndex = e.NewEditIndex;

            // Reload the GridView
            LoadMedicines();
        }

        protected void gvMedicines_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel edit mode
            gvMedicines.EditIndex = -1;

            // Reload the GridView
            LoadMedicines();
        }

        protected void gvMedicines_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get MedicineID
            int medicineID = Convert.ToInt32(gvMedicines.DataKeys[e.RowIndex].Value);

            // Get selected row
            GridViewRow row = gvMedicines.Rows[e.RowIndex];

            // Declare variables
            string medicineName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string batchNumber = ((TextBox)row.Cells[2].Controls[0]).Text;
            string categoryName = ((TextBox)row.Cells[3].Controls[0]).Text;
            string supplierName = ((TextBox)row.Cells[4].Controls[0]).Text;

            decimal unitPrice = Convert.ToDecimal(((TextBox)row.Cells[5].Controls[0]).Text);

            int quantity = Convert.ToInt32(((TextBox)row.Cells[6].Controls[0]).Text);

            int reorderLevel = Convert.ToInt32(((TextBox)row.Cells[7].Controls[0]).Text);

            DateTime expiryDate = Convert.ToDateTime(((TextBox)row.Cells[8].Controls[0]).Text);



            // SQL query
            string sql = @"UPDATE Medicines
                   SET MedicineName = @medicineName,
                       BatchNumber = @batchNumber,
                       CategoryID = (SELECT CategoryID FROM Categories WHERE CategoryName = @categoryName),
                       SupplierID = (SELECT SupplierID FROM Suppliers WHERE SupplierName = @supplierName),
                       UnitPrice = @unitPrice,
                       QuantityInStock = @quantity,
                       ReorderLevel = @reorderLevel,
                       ExpiryDate = @expiryDate
                   WHERE MedicineID = @medicineID";

            // Create connection
            SqlConnection con = new SqlConnection();

            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();

            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);

            // Bind parameters
            cmd.Parameters.AddWithValue("@medicineName", medicineName);
            cmd.Parameters.AddWithValue("@batchNumber", batchNumber);
            cmd.Parameters.AddWithValue("@categoryName", categoryName);
            cmd.Parameters.AddWithValue("@supplierName", supplierName);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmd.Parameters.AddWithValue("@expiryDate", expiryDate);
            cmd.Parameters.AddWithValue("@medicineID", medicineID);

            // Execute query
            int result = cmd.ExecuteNonQuery();

            // Close connection
            con.Close();

            // Exit edit mode
            gvMedicines.EditIndex = -1;

            // Reload GridView
            LoadMedicines();
        }

        protected void gvMedicines_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get MedicineID
            int medicineID = Convert.ToInt32(gvMedicines.DataKeys[e.RowIndex].Value);

            // Create connection
            SqlConnection con = new SqlConnection();

            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();

            // Check if medicine has stock transactions
            string checkSQL = "SELECT COUNT(*) FROM StockTransactions WHERE MedicineID = @medicineID";

            SqlCommand checkCmd = new SqlCommand(checkSQL, con);

            checkCmd.Parameters.AddWithValue("@medicineID", medicineID);

            int transactionCount = Convert.ToInt32(checkCmd.ExecuteScalar());

            if (transactionCount > 0)
            {
                //lblMessage.Text = "Cannot delete this medicine because it has existing stock transactions.";
               // lblMessage.ForeColor = System.Drawing.Color.Red;

                con.Close();
                return;
            }

            // SQL query
            string sql = "DELETE FROM Medicines WHERE MedicineID = @medicineID";

            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);

            // Bind parameter
            cmd.Parameters.AddWithValue("@medicineID", medicineID);

            // Execute query
            cmd.ExecuteNonQuery();

            // Close connection
            con.Close();

            // Reload GridView
            LoadMedicines();

            // Display message
            //lblMessage.Text = "Medicine deleted successfully!";
            //lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}