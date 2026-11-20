using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Medicube
{
    public partial class ViewSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSuppliers();
            }
        }
        private void LoadSuppliers()
        {
            string sql = "SELECT * FROM Suppliers ORDER BY SupplierID DESC";

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
            gvSuppliers.DataSource = dt;
            gvSuppliers.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Suppliers WHERE SupplierName LIKE @Search OR ContactPerson LIKE @Search ORDER BY SupplierID DESC";
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
            gvSuppliers.DataSource = dt;
            gvSuppliers.DataBind();
        }
        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadSuppliers();
        }
        protected void gvSuppliers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set selected row to edit mode
            gvSuppliers.EditIndex = e.NewEditIndex;

            // Reload suppliers
            LoadSuppliers();
        }

        protected void gvSuppliers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel edit mode
            gvSuppliers.EditIndex = -1;

            // Reload suppliers
            LoadSuppliers();
        }

        protected void gvSuppliers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Get SupplierID
            int supplierID = Convert.ToInt32(
                gvSuppliers.DataKeys[e.RowIndex].Value);

            // Get selected row
            GridViewRow row = gvSuppliers.Rows[e.RowIndex];

            // Declare variables
            string supplierName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string contactPerson = ((TextBox)row.Cells[2].Controls[0]).Text;
            string phone = ((TextBox)row.Cells[3].Controls[0]).Text;
            string email = ((TextBox)row.Cells[4].Controls[0]).Text;
            string address = ((TextBox)row.Cells[5].Controls[0]).Text;

            // SQL query
            string sql = @"UPDATE Suppliers
                           SET SupplierName = @supplierName,
                               ContactPerson = @contactPerson,
                               Phone = @phone,
                               Email = @email,
                               Address = @address
                           WHERE SupplierID = @supplierID";

            // Create connection
            SqlConnection con = new SqlConnection();

            // Connection string
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();

            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);

            // Bind parameters
            cmd.Parameters.AddWithValue("@supplierName", supplierName);
            cmd.Parameters.AddWithValue("@contactPerson", contactPerson);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@supplierID", supplierID);

            // Execute query
            cmd.ExecuteNonQuery();

            // Close connection
            con.Close();

            // Exit edit mode
            gvSuppliers.EditIndex = -1;

            // Reload suppliers
            LoadSuppliers();
        }

        protected void gvSuppliers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get SupplierID
            int supplierID = Convert.ToInt32(
                gvSuppliers.DataKeys[e.RowIndex].Value);

            // SQL query
            string sql = "DELETE FROM Suppliers WHERE SupplierID = @supplierID";

            // Create connection
            SqlConnection con = new SqlConnection();

            // Connection string
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();

            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);

            // Bind parameter
            cmd.Parameters.AddWithValue("@supplierID", supplierID);

            // Execute query
            cmd.ExecuteNonQuery();

            // Close connection
            con.Close();

            // Reload suppliers
            LoadSuppliers();
        }
    }
}