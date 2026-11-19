using Medicube.medicubedsxsdTableAdapters;
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
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            //Create an instance of a datatable
            DataTable dt = new DataTable();
            //Create an instance of adapter
            UsersTableAdapter ta = new UsersTableAdapter();
            //Execute get data method
            dt = ta.GetData(email, password);
            //Check if table has rows
            if (dt.Rows.Count > 0)
            {
                // Save UserID in Session
                Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                lblMessage.Text = "Successful";
                lblMessage.ForeColor = System.Drawing.Color.Green;
                Response.Redirect("~/index.aspx");
            }
            else
            {
                lblMessage.Text = "Not";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
           
        }
    }
}