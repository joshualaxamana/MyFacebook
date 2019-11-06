using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyFacebook_LaxamanaJ
{
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection(Sir.GetConnection());
        public Register()
        {
            InitializeComponent();
        }

        bool IsEmailExisting(string email)
        {
            bool existing = true; // initial value
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT userEmail FROM users
                WHERE userEmail=@userEmail";
            cmd.Parameters.AddWithValue("@userEmail", email);
            existing = cmd.ExecuteScalar() == null ? false : true;
            con.Close();
            return existing;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            bool existingAccount = IsEmailExisting(txtEmail.Text);

            if (existingAccount)
            {
                MessageBox.Show("Email address already taken!");
            }

            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = @"INSERT INTO users VALUES (@typeID,
                @userEmail, @userPW, @userFN, @userLN, @userPhone,
                @userAddress, @userStatus)";
                cmd.Parameters.AddWithValue("@typeID", 1);
                cmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);
                cmd.Parameters.AddWithValue("@userPW", Sir.CreateSHAHash(txtPassword.Text));
                cmd.Parameters.AddWithValue("@userFN", txtFN.Text);
                cmd.Parameters.AddWithValue("@userLN", txtLN.Text);
                cmd.Parameters.AddWithValue("@userPhone", "");
                cmd.Parameters.AddWithValue("@userAddress", "");
                cmd.Parameters.AddWithValue("@userStatus", "Active");
                cmd.ExecuteNonQuery();
                con.Close();

                string message = "Hello, " + txtFN.Text + " " + txtLN.Text + "!<br/>" +
                    "<br/>" +
                    "Thank you. Here are your credentials: <br/>" +
                    "Email: " + txtEmail.Text + "<br/>" +
                    "Password: " + txtPassword.Text + "<br/>" +
                    "<br/>" +
                    "Regards, " +
                    "The Administrator";

                Sir.SendEmail(txtEmail.Text, "Account Registration", message);
                MessageBox.Show("Registered successfully!");
            }
                
        }

    }
}
