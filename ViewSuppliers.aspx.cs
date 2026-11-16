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
    }
}