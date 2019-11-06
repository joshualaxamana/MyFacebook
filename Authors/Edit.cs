using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace MyFacebook_LaxamanaJ.Authors
{
    public partial class Edit : Form
    {
        //instantiate
        SqlConnection con = new SqlConnection(Sir.GetConnection());
        public Edit()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allows you to display the existing
        /// author information based from the selected
        /// author ID
        /// </summary>
        /// <param name="ID">Author ID</param>
        public void GetInfo(string ID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT authorLN, authorFN, authorPhone,
                authorAddress, authorCity, authorState, authorZip
                FROM authors WHERE authorID=@authorID";
            cmd.Parameters.AddWithValue("@authorID", ID);
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                txtFN.Text = data["authorFN"].ToString();
                txtLN.Text = data["authorLN"].ToString();
                txtPhone.Text = data["authorPhone"].ToString();
                txtAddress.Text = data["authorAddress"].ToString();
                txtCity.Text = data["authorCity"].ToString();
                txtState.Text = data["authorState"].ToString();
                txtZip.Text = data["authorZip"].ToString();
            }
            con.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"UPDATE authors SET 
                authorLN=@authorLN, authorFN=@authorFN, authorPhone=@authorPhone,
                authorAddress=@authorAddress,authorCity=@authorCity, authorState=@authorState,
                authorZip=@authorZip WHERE authorID=@authorID";
            cmd.Parameters.AddWithValue("@authorLN", txtLN.Text);
            cmd.Parameters.AddWithValue("@authorFN", txtFN.Text);
            cmd.Parameters.AddWithValue("@authorPhone", txtPhone.Text);
            cmd.Parameters.AddWithValue("@authorAddress", txtAddress.Text);
            cmd.Parameters.AddWithValue("@authorCity", txtCity.Text);
            cmd.Parameters.AddWithValue("@authorState", txtState.Text);
            cmd.Parameters.AddWithValue("@authorZip", txtZip.Text);
            cmd.Parameters.AddWithValue("@authorID", txtZip.Text);
            cmd.ExecuteNonQuery();
            //cmd.Parameters.Add("@authorLN", SqlDbType.VarChar).Value = txtLN.Text;

            con.Close();

            MessageBox.Show("Record updated!");

            Authors.View form = new View();
            this.Hide();
            form.Show();
        }
    }
}
