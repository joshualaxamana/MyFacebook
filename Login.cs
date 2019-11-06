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
    
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(Sir.GetConnection());
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT UserID, TypeID FROM Users " + 
               "WHERE userEmail=@userEmail AND userPW=@userPW";
            cmd.Parameters.AddWithValue("@userEmail", txtEmail.Text);
            cmd.Parameters.AddWithValue("@userPW",
                Sir.CreateSHAHash(txtPassword.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows) // email and password are correct
            {
                while(dr.Read())
                {
                    Model.userID = dr["UserID"].ToString();
                    Model.typeID = dr["TypeID"].ToString();
                }
                con.Close();

                Main form = new Main();
                this.Hide();
                form.Show();
            }
            else // email or password is incorrect
            {
                con.Close();
                MessageBox.Show("Email or password is incorrect!",
                    "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
