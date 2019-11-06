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
    public partial class Add : Form
    {
        SqlConnection con = new SqlConnection(Sir.GetConnection());
        public Add()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"INSERT INTO authors VALUES 
                (@authorLN, @authorFN, @authorPhone,
                @authorAddress, @authorCity, @authorState,
                @authorZip)";
            cmd.Parameters.AddWithValue("@authorLN",txtLN.Text);
            cmd.Parameters.AddWithValue("@authorFN",txtFN.Text);
            cmd.Parameters.AddWithValue("@authorPhone",txtPhone.Text);
            cmd.Parameters.AddWithValue("@authorAddress",txtAddress.Text);
            cmd.Parameters.AddWithValue("@authorCity",txtCity.Text);
            cmd.Parameters.AddWithValue("@authorState",txtState.Text);
            cmd.Parameters.AddWithValue("@authorZip",txtZip.Text);
            cmd.ExecuteNonQuery();
            //cmd.Parameters.Add("@authorLN", SqlDbType.VarChar).Value = txtLN.Text;

            con.Close();

            MessageBox.Show("Record added!");

            Authors.View form = new View();
            this.Hide();
            form.Show();
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}
