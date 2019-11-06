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
    
    public partial class View : Form
    {
        SqlConnection con = new SqlConnection(Sir.GetConnection());
        public View()
        {
            InitializeComponent();
        }

        private void dgvQuiz_Load(object sender, EventArgs e)
        {
            GetQuiz();
        }

        void GetQuiz()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT EmployeeID, EmployeeNO, EmpLN + ', ' +
                EmpFN AS EmpName, Department, Mobile, DateCreated
                FROM employees";

            SqlDataReader data = cmd.ExecuteReader();


            DataTable dt = new DataTable();
            dt.Load(data);

            dgvView.DataSource = dt;
            con.Close();

            dgvView.Columns[0].HeaderText = "#";
            dgvView.Columns[1].HeaderText = "Employee Number";
            dgvView.Columns[2].HeaderText = "Full Name";
            dgvView.Columns[3].HeaderText = "Department";
            dgvView.Columns[4].HeaderText = "Mobile";
            dgvView.Columns[5].HeaderText = "Date Created";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Confirmation",
                MessageBoxButtons.YesNo) == DialogResult.Yes)

                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM employees WHERE EmployeeID=@EmployeeID";
            cmd.Parameters.AddWithValue("@EmployeeID",
                dgvView.SelectedRows[0].Cells[0].Value);
            cmd.ExecuteNonQuery();
            con.Close();

            GetQuiz();
        }
    }
}
