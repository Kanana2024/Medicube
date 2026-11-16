using Medicube.medicubedsTableAdapters;
//using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Design;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicube
{
    public partial class AddMedicine : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadSuppliers();
              
            }
        }
        public void clearInputs()
        {
            txtMedicineName.Text = " ";
            
        }
        private void LoadCategories()
        {
            //SQL to execute
            string sql = "SELECT CategoryID,CategoryName FROM Categories ORDER BY CategoryName";
            //Create an instance for the connection class
            SqlConnection con = new SqlConnection();
            //Set up connection string
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";
            //Open the connection
            con.Open();
            //Create an instance of command class
            SqlCommand cmd = new SqlCommand(sql, con);
            ddlCategory.DataSource = cmd.ExecuteReader();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();


            ddlCategory.Items.Add(new ListItem("Select Category", ""));
            ddlCategory.SelectedIndex = 0;
        }
        private void LoadSuppliers()
        {
            //SQL to execute
            string sql = "SELECT SupplierID,SupplierName FROM Suppliers ORDER BY SupplierName";
            //Create an instance for the connection class
            SqlConnection con = new SqlConnection();
            //Set up connection string
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";
            //Open the connection
            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);
            ddlSupplier.DataSource = cmd.ExecuteReader();
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataValueField = "SupplierID";
            ddlSupplier.DataBind();


            ddlSupplier.Items.Add(new ListItem("Select Supplier", ""));
            ddlSupplier.SelectedIndex = 0;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Declare variables
            string medicineName = txtMedicineName.Text;
            string batchNumber = txtBatchNumber.Text;

            string categoryID = ddlCategory.SelectedValue;
            string supplierID = ddlSupplier.Text;

            decimal unitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            int quantity = Convert.ToInt32(txtQuantity.Text);
            int reorderLevel = Convert.ToInt32(txtReorderLevel.Text);
            string manufactureDate = txtManufactureDate.Text;
            string expiryDate = txtExpiryDate.Text;

            // SQL query
            string sql = @"INSERT INTO Medicines
            (MedicineName, BatchNumber, CategoryID, SupplierID,
             UnitPrice, QuantityInStock, ReorderLevel,
             ManufactureDate, ExpiryDate)
            VALUES
            (@medicineName, @batchNumber, @categoryID, @supplierID,
             @unitPrice, @quantity, @reorderLevel,
             @manufactureDate, @expiryDate)";
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
            cmd.Parameters.AddWithValue("@categoryID", categoryID);
            cmd.Parameters.AddWithValue("@supplierID", supplierID);
            cmd.Parameters.AddWithValue("@unitPrice", unitPrice);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            cmd.Parameters.AddWithValue("@reorderLevel", reorderLevel);
            cmd.Parameters.AddWithValue("@manufactureDate", manufactureDate);
            cmd.Parameters.AddWithValue("@expiryDate", expiryDate);

            // Execute query
            cmd.ExecuteNonQuery();

        }
    }
}