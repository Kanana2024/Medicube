using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Medicube
{
    public partial class Stock : System.Web.UI.Page
    {
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
           
            LoadStock();
            LoadSummary();
        }
        // Load stock summary cards
        private void LoadSummary()
        {
            string sql = @"
                SELECT
                    COUNT(*) AS TotalMedicines,

                    SUM(CASE
                        WHEN QuantityInStock > 10
                        THEN 1 ELSE 0 END) AS InStock,

                    SUM(CASE
                        WHEN QuantityInStock > 0
                        AND QuantityInStock <= 10
                        THEN 1 ELSE 0 END) AS LowStock,

                    SUM(CASE
                        WHEN QuantityInStock <= 0
                        THEN 1 ELSE 0 END) AS OutOfStock

                FROM MedicineList";
            

            SqlConnection con = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ELITEBOOK\Documents\Projects\Medicube\App_Data\medicubedb.mdf; Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblTotalMedicines.Text =
                    dr["TotalMedicines"].ToString();

                lblInStock.Text =
                    dr["InStock"].ToString();

                lblLowStock.Text =
                    dr["LowStock"].ToString();

                lblOutOfStock.Text =
                    dr["OutOfStock"].ToString();
            }

            dr.Close();
            con.Close();
        }
        private void LoadStock()
        {
            string sql = @"
            SELECT *,
            CASE
                WHEN QuantityInStock <= 0
                    THEN 'Out of Stock'
                WHEN QuantityInStock <= 10
                    THEN 'Low Stock'
                ELSE 'In Stock'
            END AS StockStatus
            FROM MedicineList
            WHERE
                (@Search = ''
                OR MedicineName LIKE @SearchPattern
                OR BatchNumber LIKE @SearchPattern)
            AND
            (
                @Status = 'All'
                OR (@Status = 'In Stock' AND QuantityInStock > 10)
                OR (@Status = 'Low Stock' AND QuantityInStock > 0 AND QuantityInStock <= 10)
                OR (@Status = 'Out of Stock' AND QuantityInStock <= 0)
            )
            ORDER BY MedicineID DESC";
            

            SqlConnection con = new SqlConnection(
                @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ELITEBOOK\Documents\Projects\Medicube\App_Data\medicubedb.mdf; Integrated Security=True");

            con.Open();

            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@Search", txtSearch.Text.Trim());
            cmd.Parameters.AddWithValue("@SearchPattern", "%" + txtSearch.Text.Trim() + "%");
            cmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);

            SqlDataReader dr = cmd.ExecuteReader();

            gvStock.DataSource = dr;
            gvStock.DataBind();

            dr.Close();
            con.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadStock();
        }

        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ddlStatus.SelectedValue = "All";

            LoadStock();
            lblMessage.Text = "";
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            LoadStock();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            ddlStatus.SelectedValue = "All";

            LoadSummary();
            LoadStock();

            lblMessage.Text = "";
        }
    }
}