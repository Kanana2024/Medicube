using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicube
{
    public partial class Users : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ELITEBOOK\Documents\Projects\Medicube\App_Data\medicubedb.mdf; Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check whether user is logged in and is an Admin
            if (Session["UserID"] == null ||
                Session["Role"] == null ||
                Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("~/Dashboard.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadUsers();
            }
        }
        private void LoadUsers()
        {
            // Declare SQL query
            string sql = @"
                SELECT UserID, FullName, Email,Phone,DOB,Gender,Address,Password, Role
                FROM Users
                ORDER BY UserID DESC";

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
            gvUsers.DataSource = dt;
            gvUsers.DataBind();
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            LoadUsers();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            LoadUsers();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Declare variables
            int userID = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            GridViewRow row = gvUsers.Rows[e.RowIndex];

            string fullName = e.NewValues["FullName"].ToString();
            string password = e.NewValues["Password"].ToString();
            string phone = e.NewValues["Phone"].ToString();
            string dob = e.NewValues["DOB"].ToString();
            string gender = ((DropDownList)row.FindControl("ddlGender")).SelectedValue;
            string role = ((DropDownList)row.FindControl("ddlRole")).SelectedValue;

            // SQL query
            string sql = @"
            UPDATE Users
            SET FullName = @FullName,
                Password = CASE WHEN @Password = '' THEN Password ELSE @Password END,
                Phone = @Phone,
                DOB = @DOB,
                Gender = @Gender,
                Role = @Role
            WHERE UserID = @UserID";

            // Create connection
            SqlConnection con = new SqlConnection(connectionString);

            // Open connection
            con.Open();

            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);

            // Bind parameters
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@Phone", phone);
            cmd.Parameters.AddWithValue("@DOB", dob);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Role", role);
            cmd.Parameters.AddWithValue("@UserID", userID);

            // Execute query
            cmd.ExecuteNonQuery();

            // Close connection
            con.Close();

            lblMessage.Text = "User updated successfully.";
            lblMessage.ForeColor = System.Drawing.Color.Green;

            gvUsers.EditIndex = -1;
            LoadUsers();
        }


        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteUser")
            {
                try
                {
                    int userID = Convert.ToInt32(e.CommandArgument);

                    // Get logged-in UserID
                    int loggedInUserID = Convert.ToInt32(Session["UserID"]);

                    // Prevent deleting own account
                    if (userID == loggedInUserID)
                    {
                        lblMessage.Text = "You cannot delete your own account.";
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    // SQL query
                    string sql = "DELETE FROM Users WHERE UserID = @UserID";

                    // Create connection
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Open connection
                        con.Open();

                        // Create command
                        SqlCommand cmd = new SqlCommand(sql, con);

                        // Bind parameter
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        // Execute query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            lblMessage.Text = "User deleted successfully.";
                            lblMessage.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            lblMessage.Text = "User was not found.";
                            lblMessage.ForeColor = System.Drawing.Color.Red;
                        }
                    }

                    // Reload users
                    LoadUsers();
                }
                catch (SqlException ex)
                {
                    lblMessage.Text = "Cannot delete this user because another record references their account.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }



        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            gvUsers.EditIndex = -1;
            LoadUsers();

            lblMessage.Text = "";
        }

    }
}