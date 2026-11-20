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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //HAVE THIS ABOVE
            // using System.Data.SqlClient;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Declare variables
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ELITEBOOK\Documents\Projects\Medicube\App_Data\medicubedb.mdf; Integrated Security=True";

            // SQL query
            string sql = @"
        SELECT UserID, Email, Password, Role
        FROM Users
        WHERE Email = @Email
        AND Password = @Password";

            // Create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Open connection
                con.Open();

                // Create command
                SqlCommand cmd = new SqlCommand(sql, con);

                // Bind parameters
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                // Execute query
                SqlDataReader reader = cmd.ExecuteReader();

                // Check if user exists
                if (reader.Read())
                {
                    // Save UserID in Session
                    Session["UserID"] = reader["UserID"].ToString();

                    // Save Role in Session
                    Session["Role"] = reader["Role"].ToString();

                    // Display success message
                    lblMessage.Text = "Login successful!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    // Close reader
                    reader.Close();

                    // Redirect to Dashboard
                    Response.Redirect("~/index.aspx");
                }
                else
                {
                    lblMessage.Text = "Invalid email or password.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

            }
        }
    }
}
    
