using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicube
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void clearInputs()
        {
            txtCategoryName.Text = " ";
            txtDescription.Text = " ";
        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            // Declare variables
            string categoryname = txtCategoryName.Text;
            string description = txtDescription.Text;
            // SQL query
            string sql = @"INSERT INTO Categories
            (CategoryName, Description)
            VALUES
            (@categoryName, @description)";
            // Create connection
            SqlConnection con = new SqlConnection();
            // Connection string
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();

            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);
            // Bind parameters
            cmd.Parameters.AddWithValue("@categoryName", categoryname);
            cmd.Parameters.AddWithValue("@description", description);
            // Execute query
            cmd.ExecuteNonQuery();

            lblMessage.Text = "Category added successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            clearInputs();

            // Close connection
            con.Close();
        }
    }
}