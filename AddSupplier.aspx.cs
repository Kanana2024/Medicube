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
    public partial class AddSupplier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Declare variables
            string supplierName = txtSupplierName.Text;
            string contactPerson = txtContactPerson.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            // SQL query
           
            string sql = @"INSERT INTO Suppliers (SupplierName, ContactPerson, Phone, Email, Address)VALUES (@SupplierName, @ContactPerson, @Phone, @Email, @Address)";
                                        
                            
            // Create connection
            SqlConnection con = new SqlConnection();
            // Connection string
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();

            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);
            // Bind parameters
            cmd.Parameters.AddWithValue("@SupplierName", supplierName);
            cmd.Parameters.AddWithValue("@ContactPerson", contactPerson);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Address", address);
            // Execute query
            cmd.ExecuteNonQuery();

            lblMessage.Text = "Supplier added successfully!";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            //clearInputs();

            // Close connection
            con.Close();
        }
    }
}