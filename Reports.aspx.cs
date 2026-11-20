using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Medicube
{
    public partial class Reports : System.Web.UI.Page
    {
        string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\ELITEBOOK\Documents\Projects\Medicube\App_Data\medicubedb.mdf; Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            // Declare variables
            string reportType = ddlReportType.SelectedValue;
            string sql = "";

            DateTime startDate;
            DateTime endDate;

            bool hasStartDate = DateTime.TryParse(txtStartDate.Text, out startDate);
            bool hasEndDate = DateTime.TryParse(txtEndDate.Text, out endDate);

            // Validate dates
            if (!string.IsNullOrEmpty(txtStartDate.Text) && !hasStartDate)
            {
                lblMessage.Text = "Enter a valid start date.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!string.IsNullOrEmpty(txtEndDate.Text) && !hasEndDate)
            {
                lblMessage.Text = "Enter a valid end date.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (hasStartDate && hasEndDate && startDate > endDate)
            {
                lblMessage.Text = "Start date cannot be after end date.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Select report query
            switch (reportType)
            {
                case "Inventory":

                    sql = @"
                    SELECT
                        MedicineID,
                        MedicineName,
                        BatchNumber,
                        CategoryName,
                        SupplierName,
                        UnitPrice,
                        QuantityInStock,
                        ReorderLevel,
                        ExpiryDate
                    FROM MedicineList
                    ORDER BY MedicineName";

                    lblReportTitle.Text = "Inventory Report";

                    break;


                case "LowStock":

                    sql = @"
                    SELECT
                        MedicineID,
                        MedicineName,
                        BatchNumber,
                        CategoryName,
                        SupplierName,
                        QuantityInStock,
                        ReorderLevel
                    FROM MedicineList
                    WHERE QuantityInStock <= ReorderLevel
                    ORDER BY QuantityInStock ASC";

                    lblReportTitle.Text = "Low Stock Report";

                    break;


                case "Expiring":

                    if (!hasStartDate && !hasEndDate)
                    {
                        sql = @"
                        SELECT
                            MedicineID,
                            MedicineName,
                            BatchNumber,
                            CategoryName,
                            QuantityInStock,
                            ExpiryDate
                        FROM MedicineList
                        WHERE ExpiryDate >= CAST(GETDATE() AS DATE)
                        AND ExpiryDate <= DATEADD(DAY, 30, CAST(GETDATE() AS DATE))
                        ORDER BY ExpiryDate ASC";
                    }
                    else
                    {
                        sql = @"
                        SELECT
                            MedicineID,
                            MedicineName,
                            BatchNumber,
                            CategoryName,
                            QuantityInStock,
                            ExpiryDate
                        FROM MedicineList
                        WHERE (@StartDate IS NULL OR ExpiryDate >= @StartDate)
                        AND (@EndDate IS NULL OR ExpiryDate < DATEADD(DAY, 1, @EndDate))
                        ORDER BY ExpiryDate ASC";
                    }

                    lblReportTitle.Text = "Expiring Medicines Report";

                    break;


                case "StockIn":

                    sql = @"
                    SELECT
                        st.TransactionID,
                        ml.MedicineName,
                        ml.BatchNumber,
                        st.Quantity,
                        st.TransactionDate,
                        st.Notes
                    FROM StockTransactions st
                    INNER JOIN MedicineList ml
                        ON st.MedicineID = ml.MedicineID
                    WHERE st.TransactionType = 'IN'
                    AND (@StartDate IS NULL OR st.TransactionDate >= @StartDate)
                    AND (@EndDate IS NULL OR st.TransactionDate < DATEADD(DAY, 1, @EndDate))
                    ORDER BY st.TransactionDate DESC";

                    lblReportTitle.Text = "Stock In Report";

                    break;


                case "StockOut":

                    sql = @"
                    SELECT
                        st.TransactionID,
                        ml.MedicineName,
                        ml.BatchNumber,
                        st.Quantity,
                        st.TransactionDate,
                        st.Notes
                    FROM StockTransactions st
                    INNER JOIN MedicineList ml
                        ON st.MedicineID = ml.MedicineID
                    WHERE st.TransactionType = 'OUT'
                    AND (@StartDate IS NULL OR st.TransactionDate >= @StartDate)
                    AND (@EndDate IS NULL OR st.TransactionDate < DATEADD(DAY, 1, @EndDate))
                    ORDER BY st.TransactionDate DESC";

                    lblReportTitle.Text = "Stock Out Report";

                    break;
            }

            // Create DataTable
            DataTable dt = new DataTable();

            // Create connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Create command
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    // Bind date parameters for reports that use them
                    if (reportType == "Expiring" && (hasStartDate || hasEndDate))
                    {
                        cmd.Parameters.AddWithValue(
                            "@StartDate",
                            hasStartDate ? (object)startDate.Date : DBNull.Value);

                        cmd.Parameters.AddWithValue(
                            "@EndDate",
                            hasEndDate ? (object)endDate.Date : DBNull.Value);
                    }
                    else if (reportType == "StockIn" || reportType == "StockOut")
                    {
                        cmd.Parameters.AddWithValue(
                            "@StartDate",
                            hasStartDate ? (object)startDate.Date : DBNull.Value);

                        cmd.Parameters.AddWithValue(
                            "@EndDate",
                            hasEndDate ? (object)endDate.Date : DBNull.Value);
                    }

                    // Open connection
                    con.Open();

                    // Execute query
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    da.Fill(dt);
                }
            }

            // Bind report results
            gvReports.DataSource = dt;
            gvReports.DataBind();

            // Display number of records
            lblRecordCount.Text = dt.Rows.Count.ToString();

            // Display message
            lblMessage.Text = "Report generated successfully.";
            lblMessage.ForeColor = System.Drawing.Color.Green;
        }
    }
}
