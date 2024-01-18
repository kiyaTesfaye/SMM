using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace markett
{

    public partial class category : Form
    {
        public category()
        {
            InitializeComponent();
        }
        private void populate()
        {
            con.Open();
            string query = " select * from CategoryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            catDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void category_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\512\Documents\supermarketdb.mdf;
        Integrated Security=True;Connect Timeout=30 ");
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into CategoryTbl values (" + catIDTb.Text + " , '" + catNameTb.Text + "', '" + catDescTB.Text +"')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("category added successfully");
                con.Close();
                populate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            catIDTb.Text = catDGV.SelectedRows[0].Cells[0].Value.ToString();
            catNameTb.Text = catDGV.SelectedRows[0].Cells[1].Value.ToString();
            catDescTB.Text = catDGV.SelectedRows[0].Cells[2].Value.ToString();


        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (catIDTb.Text == "") 
                {
                    MessageBox.Show("select the category to Delete");
                }
                else
                {
                    con.Open();
                    string query = "delete from categoryTbl where catId=" + catIDTb.Text + "";
                        SqlCommand cmd = new SqlCommand(query , con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("categry delete successfully");
                    con.Close();
                    populate();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
         Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (catIDTb.Text == "" || catNameTb.Text == "" || catDescTB.Text == "")
                {
                    MessageBox.Show("missing Information");
                }
                else { 
                con.Open();
                string query = "update CategoryTbl set CatName='" + catNameTb.Text + "',CatDesc'" + catDescTB.Text + "'where Catid=" + catIDTb.Text + ";";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Category successfuly updated");
                con.Close();
                populate();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            product pro = new product();
            pro.Show();
            this.Hide();
        }
    }
}
