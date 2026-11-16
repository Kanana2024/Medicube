using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Medicube
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void clearInputs()
        {
            txtFullName.Text = " ";
            txtEmail.Text = " ";
            txtPhone.Text = " ";
            txtDOB.Text = " ";
            txtGender.Text = " ";
            txtAddress.Text = " ";
            txtPassword.Text = " ";

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            //Decalre variables
            string fullname = txtFullName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string dob = txtDOB.Text;
            string gender = txtGender.Text;
            string address = txtAddress.Text;
            string password = txtPassword.Text;
            //SQL to execute
            string sql = "insert into Users(FullName,Email,Phone,DOB,Gender,Address,Password) values (@fullname,@email,@phone,@dob,@gender,@address,@password)";
            //Create an instance for the connection class
            SqlConnection con = new SqlConnection();
            //Set up connection string
            con.ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\ELITEBOOK\\Documents\\Projects\\Medicube\\App_Data\\medicubedb.mdf;Integrated Security=True";
            //Open the connection
            con.Open();
            //Create an instance of command class
            SqlCommand cmd = new SqlCommand(sql, con);
            //Bind the parameters and fields
            cmd.Parameters.AddWithValue("@fullname", fullname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@dob", dob);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@password", password);
            //Execute query
            cmd.ExecuteNonQuery();
            lblMessage.Text = "Record saved";
            lblMessage.ForeColor = System.Drawing.Color.Green;
            clearInputs();

        }
    }
}