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
    public partial class View : Form
    {
        SqlConnection con = new SqlConnection(Sir.GetConnection());

        public View()
        {
            InitializeComponent();
            GetAuthors();
        }

        private void View_Load(object sender, EventArgs e)
        {
            GetAuthors();
        }

        void GetAuthors()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT authorID, authorLN + ', ' +
                authorFN AS authorName, authorPhone, authorAddress + ', ' +
                authorCity + ', ' + authorState + ', '+ authorZip AS authorAddress
                FROM authors";

            SqlDataReader data = cmd.ExecuteReader();

            //SqlDateAdapter da = new SqlDataAdapter(cmd);
            //DataSet ds = new DataSet();
            //da.Fill(ds, "authors");

            DataTable dt = new DataTable();
            dt.Load(data);

            dgvAuthors.DataSource = dt;
            con.Close();

            dgvAuthors.Columns[0].HeaderText = "#";
            dgvAuthors.Columns[1].HeaderText = "Full Name";
            dgvAuthors.Columns[2].HeaderText = "Contact #";
            dgvAuthors.Columns[3].HeaderText = "Address";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Confirmation",
                MessageBoxButtons.YesNo) == DialogResult.Yes)

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE FROM authors WHERE authorID=@authorID";
            cmd.Parameters.AddWithValue("@authorID",
                dgvAuthors.SelectedRows[0].Cells[0].Value);
            cmd.ExecuteNonQuery();
            con.Close();

            GetAuthors();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Authors.Edit form = new Edit();
            form.Show();
            form.txtID.Text = dgvAuthors.SelectedRows[0].Cells[0].Value.ToString();
            form.GetInfo(form.txtID.Text);
        }

        private void dgvAuthors_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Authors.Edit form = new Edit();
            //form.Show();
            //form.txtID.Text = dgvAuthors.SelectedRows[0].Cells[0].Value.ToString();

            editToolStripMenuItem_Click(null, null);
        }
    }
}
