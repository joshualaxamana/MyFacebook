using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyFacebook_LaxamanaJ.Quiz
{
    public partial class Add : Form
    {
        SqlConnection con = new SqlConnection(Sir.GetConnection());
        public Add()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"INSERT INTO employees VALUES 
                (@EmployeeNo, @EmpLN, @EmpFN,
                @Department, @Mobile, @DateCreated)";
            cmd.Parameters.AddWithValue("@EmployeeNo", txtNum.Text);
            cmd.Parameters.AddWithValue("@EmpLN", txtLN.Text);
            cmd.Parameters.AddWithValue("@EmpFN", txtFN.Text);
            cmd.Parameters.AddWithValue("@Department", txtDep.Text);
            cmd.Parameters.AddWithValue("@Mobile", txtCell.Text);
            cmd.Parameters.AddWithValue("@DateCreated", dtpDC.Value);
            cmd.ExecuteNonQuery();
           

            con.Close();

            MessageBox.Show("Record added!");

            Quiz.View form = new View();
            this.Hide();
            form.Show();
        }

    }
}
