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
    public partial class PaymentHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPayments();
            }
        }
        // Load payment records
        private void LoadPayments()
        {
            // SQL query
            string sql = @"SELECT
                           sp.PaymentID,
                           s.SupplierName,
                           sp.PaymentDate,
                           sp.AmountPaid,
                           sp.PaymentMethod,
                           sp.TransactionReference,
                           sp.Description
                           FROM SupplierPayment sp
                           INNER JOIN Suppliers s
                           ON sp.SupplierID = s.SupplierID
                           ORDER BY sp.PaymentID DESC";

            // Create connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();

            // Create adapter
            SqlDataAdapter da = new SqlDataAdapter(sql, con);

            // Create datatable
            DataTable dt = new DataTable();

            // Fill datatable
            da.Fill(dt);

            // Bind GridView
            gvPaymentHistory.DataSource = dt;
            gvPaymentHistory.DataBind();

            // Close connection
            con.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Declare variables
            string supplierName = txtSearch.Text.Trim();

            // SQL query
            string sql = @"SELECT
                           sp.PaymentID,
                           s.SupplierName,
                           sp.PaymentDate,
                           sp.AmountPaid,
                           sp.PaymentMethod,
                           sp.TransactionReference,
                           sp.Description
                           FROM SupplierPayment sp
                           INNER JOIN Suppliers s
                           ON sp.SupplierID = s.SupplierID
                           WHERE s.SupplierName LIKE @supplierName
                           ORDER BY sp.PaymentID DESC";

            // Create connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);

            // Bind parameters
            cmd.Parameters.AddWithValue("@supplierName", "%" + supplierName + "%");

            // Create adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            // Create datatable
            DataTable dt = new DataTable();

            // Fill datatable
            da.Fill(dt);

            // Bind GridView
            gvPaymentHistory.DataSource = dt;
            gvPaymentHistory.DataBind();

            // Close connection
            con.Close();

            // Display message
            if (dt.Rows.Count == 0)
            {
                lblMessage.Text = "No payment records found.";
                lblMessage.CssClass = "text-danger d-block mb-3";
            }
            else
            {
                lblMessage.Text = dt.Rows.Count + " payment record(s) found.";
                lblMessage.CssClass = "text-success d-block mb-3";
            }
        }


        protected void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";

            lblMessage.Text = "";

            LoadPayments();
        }
        // Enable editing
        
        protected void gvPaymentHistory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPaymentHistory.EditIndex = e.NewEditIndex;

            LoadPayments();
        }

        // Cancel editing
        protected void gvPaymentHistory_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPaymentHistory.EditIndex = -1;

            LoadPayments();
        }
        // Update payment record
        protected void gvPaymentHistory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Declare variables
            int paymentID = Convert.ToInt32(gvPaymentHistory.DataKeys[e.RowIndex].Value);

            GridViewRow row = gvPaymentHistory.Rows[e.RowIndex];

            string paymentDate = ((TextBox)row.Cells[2].Controls[0]).Text;

            decimal amountPaid = Convert.ToDecimal(((TextBox)row.Cells[3].Controls[0]).Text);

            string paymentMethod = ((TextBox)row.Cells[4].Controls[0]).Text;

            string transactionReference = ((TextBox)row.Cells[5].Controls[0]).Text;

            string description = ((TextBox)row.Cells[6].Controls[0]).Text;


            // SQL query
            string sql = @"UPDATE SupplierPayment
                           SET PaymentDate = @paymentDate,
                               AmountPaid = @amountPaid,
                               PaymentMethod = @paymentMethod,
                               TransactionReference = @transactionReference,
                               Description = @description
                           WHERE PaymentID = @paymentID";


            // Create connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";


            // Open connection
            con.Open();


            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);


            // Bind parameters
            cmd.Parameters.AddWithValue("@paymentDate", Convert.ToDateTime(paymentDate));
            cmd.Parameters.AddWithValue("@amountPaid", amountPaid);
            cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);

            cmd.Parameters.AddWithValue("@transactionReference",
                string.IsNullOrWhiteSpace(transactionReference)
                ? (object)DBNull.Value : transactionReference);

            cmd.Parameters.AddWithValue("@description",
                string.IsNullOrWhiteSpace(description)
                ? (object)DBNull.Value : description);

            cmd.Parameters.AddWithValue("@paymentID", paymentID);


            // Execute query
            cmd.ExecuteNonQuery();


            // Close connection
            con.Close();


            // Exit edit mode
            gvPaymentHistory.EditIndex = -1;


            // Reload records
            LoadPayments();


            // Display message
            lblMessage.Text = "Payment record updated successfully!";
            lblMessage.CssClass = "text-success d-block mb-3";
        }


        // Delete payment record
        protected void gvPaymentHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Declare variables
            int paymentID = Convert.ToInt32(gvPaymentHistory.DataKeys[e.RowIndex].Value);


            // SQL query
            string sql = "DELETE FROM SupplierPayment WHERE PaymentID = @paymentID";


            // Create connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";


            // Open connection
            con.Open();


            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);


            // Bind parameters
            cmd.Parameters.AddWithValue("@paymentID", paymentID);


            // Execute query
            cmd.ExecuteNonQuery();


            // Close connection
            con.Close();


            // Reload records
            LoadPayments();


            // Display message
            lblMessage.Text = "Payment record deleted successfully!";
            lblMessage.CssClass = "text-success d-block mb-3";
        }

    }
}
