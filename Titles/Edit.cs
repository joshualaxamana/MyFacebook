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
    public partial class Edit : Form
    {
        SqlConnection con = new SqlConnection(Sir.GetConnection());
        public Edit()
        {
            InitializeComponent();
            GetPublishers();
            GetAuthors();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            
        }

        public void GetInfo(string ID)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"SELECT titleID, pubID, authorID, titleName, 
                titlePrice, titlePubDate, titleNotes FROM titles 
                WHERE titleID=@titleID";
            cmd.Parameters.AddWithValue("@titleID", ID);
            SqlDataReader data = cmd.ExecuteReader();
            while (data.Read())
            {
                txtID.Text = data["titleID"].ToString();
                cbPublishers.SelectedValue = data["pubID"].ToString();
                cbAuthor.SelectedValue = data["authorID"].ToString();
                txtTitle.Text = data["titleName"].ToString();
                nudPrice.Value = Decimal.Parse(data["titlePrice"].ToString());
                dtpPubDate.Value = DateTime.Parse(data["titlePubDate"].ToString());
                txtNotes.Text = data["titleNotes"].ToString();
            }

            con.Close();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
             con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = @"UPDATE titles SET 
                pubID=@pubID, authorID=@authorID, titleName=@titleName, 
                titlePrice=@titlePrice, titleNotes=@titleNotes
                WHERE titleID=@titleID";
            cmd.Parameters.AddWithValue("@pubID", cbPublishers.SelectedValue);
            cmd.Parameters.AddWithValue("@authorID", cbAuthor.SelectedValue);
            cmd.Parameters.AddWithValue("@titleName", txtTitle.Text);
            cmd.Parameters.AddWithValue("@titlePrice", nudPrice.Value);
            cmd.Parameters.AddWithValue("@titleNotes", txtNotes.Text);
            cmd.Parameters.AddWithValue("@titleID", txtID.Text);
            cmd.ExecuteNonQuery();
            //cmd.Parameters.Add("@authorLN", SqlDbType.VarChar).Value = txtLN.Text;

            con.Close();

            MessageBox.Show("Record updated!");

            Titles.View form = new View();
            this.Hide();
            form.Show();
        }
    }
}
