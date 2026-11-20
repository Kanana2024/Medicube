using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicube
{
    public partial class index : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ELITEBOOK\Documents\Projects\Medicube\App_Data\medicubedb.mdf; Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check whether user is logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                lblDate.Text = DateTime.Now.ToString("dd MMM yyyy");

                LoadDashboard();
                LoadLowStock();
                LoadRecentTransactions();
            }
        }
        private void LoadDashboard()
        {
            // Declare SQL queries
            string medicinesSQL = "SELECT COUNT(*) FROM Medicines";
            string categoriesSQL = "SELECT COUNT(*) FROM Categories";
            string suppliersSQL = "SELECT COUNT(*) FROM Suppliers";

            string lowStockSQL = @"
                SELECT COUNT(*)
                FROM Medicines
                WHERE QuantityInStock <= ReorderLevel";

            string totalUnitsSQL = @"
                SELECT ISNULL(SUM(QuantityInStock), 0)
                FROM Medicines";

            string expiredSQL = @"
                SELECT COUNT(*)
                FROM Medicines
                WHERE ExpiryDate < CAST(GETDATE() AS DATE)";

            string expiringSQL = @"
                SELECT COUNT(*)
                FROM Medicines
                WHERE ExpiryDate >= CAST(GETDATE() AS DATE)
                AND ExpiryDate <= DATEADD(DAY, 30, CAST(GETDATE() AS DATE))";

            // Create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Open connection
                con.Open();

                // Get total medicines
                SqlCommand cmd = new SqlCommand(medicinesSQL, con);
                lblTotalMedicines.Text = cmd.ExecuteScalar().ToString();

                // Get total categories
                cmd = new SqlCommand(categoriesSQL, con);
                lblTotalCategories.Text = cmd.ExecuteScalar().ToString();

                // Get total suppliers
                cmd = new SqlCommand(suppliersSQL, con);
                lblTotalSuppliers.Text = cmd.ExecuteScalar().ToString();

                // Get low stock
                cmd = new SqlCommand(lowStockSQL, con);
                lblLowStock.Text = cmd.ExecuteScalar().ToString();

                // Get total units
                cmd = new SqlCommand(totalUnitsSQL, con);
                lblTotalUnits.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");

                // Get expired medicines
                cmd = new SqlCommand(expiredSQL, con);
                lblExpired.Text = cmd.ExecuteScalar().ToString();

                // Get expiring medicines
                cmd = new SqlCommand(expiringSQL, con);
                lblExpiringSoon.Text = cmd.ExecuteScalar().ToString();
            }

            // Display user's name if FullName exists
            if (Session["FullName"] != null)
            {
                lblUserName.Text = Session["FullName"].ToString();
            }
            else
            {
                lblUserName.Text = "Admin";
            }
        }
        private void LoadLowStock()
        {
            // Declare SQL query
            string sql = @"
                SELECT MedicineName, QuantityInStock, ReorderLevel
                FROM Medicines
                WHERE QuantityInStock <= ReorderLevel
                ORDER BY QuantityInStock ASC";

            // Create DataTable
            DataTable dt = new DataTable();

            // Create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Open connection
                con.Open();

                // Create command
                SqlCommand cmd = new SqlCommand(sql, con);

                // Create adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Fill DataTable
                da.Fill(dt);
            }

            // Bind GridView
            gvLowStock.DataSource = dt;
            gvLowStock.DataBind();
        }
        private void LoadRecentTransactions()
        {
            // Declare SQL query
            string sql = @"
                SELECT TOP 5
                    m.MedicineName,
                    st.TransactionType,
                    st.Quantity,
                    st.TransactionDate
                FROM StockTransactions st
                INNER JOIN Medicines m
                    ON st.MedicineID = m.MedicineID
                ORDER BY st.TransactionDate DESC";

            // Create DataTable
            DataTable dt = new DataTable();

            // Create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Open connection
                con.Open();

                // Create command
                SqlCommand cmd = new SqlCommand(sql, con);

                // Create adapter
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                // Fill DataTable
                da.Fill(dt);
            }

            // Bind GridView
            gvTransactions.DataSource = dt;
            gvTransactions.DataBind();
        }

    }
}