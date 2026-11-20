using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicube
{
    public partial class Sidebar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            lnkUsers.Visible = Session["Role"] != null &&
                               Session["Role"].ToString() == "Admin";
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear all session variables
            Session.Clear();

            // Abandon the current session
            Session.Abandon();

            // Redirect to Login page
            Response.Redirect("~/Login.aspx");
        }
    }
  }