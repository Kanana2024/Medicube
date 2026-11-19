using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Medicube
{
    public partial class SupplierPayment : System.Web.UI.Page
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
            // SQL query
            string sql = "SELECT SupplierID, SupplierName FROM Suppliers";

            // Create connection
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";

            // Open connection
            con.Open();

            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);

            // Execute query
            SqlDataReader dr = cmd.ExecuteReader();

            // Bind dropdown
            ddlSupplier.DataSource = dr;
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataValueField = "SupplierID";
            ddlSupplier.DataBind();

            // Add default item
            ddlSupplier.Items.Insert(0, "Select Supplier");

            // Close connection
            con.Close();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Declare variables
            string supplierID = ddlSupplier.SelectedValue;

            string paymentDate = txtPaymentDate.Text;

            decimal amountPaid = Convert.ToDecimal(txtAmountPaid.Text);

            string paymentMethod = ddlPaymentMethod.SelectedValue;

            string transactionReference = txtTransactionReference.Text;

            string description = txtDescription.Text;


            // SQL query
            string sql = @"INSERT INTO SupplierPayment
            (SupplierID, PaymentDate, AmountPaid, PaymentMethod,
             TransactionReference, Description)
            VALUES
            (@supplierID, @paymentDate, @amountPaid, @paymentMethod,
             @transactionReference, @description)";


            // Create connection
            SqlConnection con = new SqlConnection();

            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";


            // Open connection
            con.Open();


            // Create command
            SqlCommand cmd = new SqlCommand(sql, con);


            // Bind parameters
            cmd.Parameters.AddWithValue("@supplierID", supplierID);
            cmd.Parameters.AddWithValue("@paymentDate", paymentDate);
            cmd.Parameters.AddWithValue("@amountPaid", amountPaid);
            cmd.Parameters.AddWithValue("@paymentMethod", paymentMethod);

            cmd.Parameters.AddWithValue("@transactionReference", transactionReference);
            // string.IsNullOrWhiteSpace(transactionReference)
            // ? (object)DBNull.Value : transactionReference);

            cmd.Parameters.AddWithValue("@description", description);
               // string.IsNullOrWhiteSpace(description)
                //? (object)DBNull.Value : description);


            // Execute query
            cmd.ExecuteNonQuery();


            // Close connection
            con.Close();


            // Display message
            lblMessage.Text = "Supplier payment saved successfully!";
            lblMessage.CssClass = "text-success d-block mt-3";


            // Clear inputs
            ClearForm();
        }
        private void ClearForm()
        {
            ddlSupplier.SelectedIndex = 0;

            txtPaymentDate.Text = "";

            txtAmountPaid.Text = "";

            ddlPaymentMethod.SelectedIndex = 0;

            txtTransactionReference.Text = "";

            txtDescription.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();

            lblMessage.Text = "";
        }
    }
}