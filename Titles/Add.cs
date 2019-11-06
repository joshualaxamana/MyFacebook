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
    public partial class Add : Form
    {
        SqlConnection con = new SqlConnection(Sir.GetConnection());
        public Add()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            GetPublishers();
            GetAuthors();
        }

        void GetPublishers()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT pubID, pubName FROM publishers ORDER BY pubName";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbPublishers.DataSource = dt;
            cbPublishers.DisplayMember = "pubName";
            cbPublishers.ValueMember = "pubID";
            con.Close();

        }

        void GetAuthors()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT authorID, authorLN + ', ' + authorFN as authorName FROM authors ORDER BY authorLN";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cbAuthor.DataSource = dt;
            cbAuthor.DisplayMember = "authorName";
            cbAuthor.ValueMember = "authorID";
            con.Close();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"INSERT INTO titles VALUES (@pubID, @authorID,
                @titleName, @titlePrice, @titlePubDate, @titleNotes)";
            cmd.Parameters.AddWithValue("@pubID", cbPublishers.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@authorID", cbAuthor.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@titleName", txtTitle.Text);
            cmd.Parameters.AddWithValue("@titlePrice", nudPrice.Value);
            cmd.Parameters.AddWithValue("@titlePubDate", dtpPubDate.Value);
            cmd.Parameters.AddWithValue("@titleNotes", txtNotes.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Added a record!");
        }
    }
}
