using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MyFacebook_LaxamanaJ.Titles
{
    
    public partial class View : Form
    {
        SqlConnection con = new SqlConnection(Sir.GetConnection());
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            GetTitles();
        }

        void GetTitles()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT t.titleID, p.pubName,
            a.authorLN + ', ' + a.authorFN AS authorName, 
            t.titleName, t.titlePrice, t.titlePubDate,
            t.titleNotes FROM titles t
            INNER JOIN publishers p ON t.pubID = p.pubID
            INNER JOIN authors a ON t.authorID = a.authorID";
            SqlDataReader data = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(data);
            dgvTitles.DataSource = dt;
            con.Close();

            dgvTitles.Columns[0].HeaderText = "#";
            dgvTitles.Columns[1].HeaderText = "Publisher";
            dgvTitles.Columns[2].HeaderText = "Author";
            dgvTitles.Columns[3].HeaderText = "Title Name";
            dgvTitles.Columns[4].HeaderText = "Price";
            dgvTitles.Columns[5].HeaderText = "Publication Date";
            dgvTitles.Columns[6].HeaderText = "Notes";
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Titles.Edit form = new Edit();
            form.Show();
            string titleID = dgvTitles.SelectedRows[0].Cells[0].Value.ToString();
            form.GetInfo(titleID);
        }
    }
}
