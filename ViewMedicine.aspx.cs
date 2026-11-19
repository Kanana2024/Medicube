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
            LoadMedicines();
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
    }
}