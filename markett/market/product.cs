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
using System.Security.Cryptography;

namespace markett
{
    public partial class product : Form
    {
        public product()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\512\Documents\supermarketdb.mdf;
        Integrated Security=True;Connect Timeout=30 ");
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fillcombo()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select catName from CategoryTbl" ,con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("catName", typeof(string));
            dt.Load(rdr);
  
            CatCb.ValueMember = "catName";
           CatCb.DataSource = dt;

            con.Close();
        }
        private void populate()
        {
            con.Open();
            string query = "select * from ProductTbl1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            guna2DataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
        private void product_Load(object sender, EventArgs e)
        {
            fillcombo();
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            category cat = new category();
            cat.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into ProductTbl1 values (" + prodid.Text + " , " + prodName.Text + ", " + prodQty.Text + " , "+prodPrice.Text +" ,"+CatCb.SelectedValue.ToString()+")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("product added successfully");
                con.Close();
               populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            prodid.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            prodName.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            prodQty.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            prodPrice.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            CatCb.SelectedValue = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        





        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (prodid.Text == "")
                {
                    MessageBox.Show("select the category to Delete");
                }
                else
                {
                    con.Open();
                    string query = "delete from ProductTbl1 where proid=" + prodid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("product delete successfully");
                    con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (prodid.Text == "" || prodName.Text == "" || prodQty.Text == "" || prodPrice.Text== "")
                {
                    MessageBox.Show("missing Information");
                }
                else
                {
                    con.Open();
                    string query = "update ProductTbl1 set prodName='" + prodName.Text + "',prodQyt='" + prodQty.Text + "' , prodPrice='" + prodPrice.Text + "', prodCat='" + CatCb.SelectedValue.ToString() + "' ,where prodid=" + prodid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("product successfuly updated");
                    con.Close();
                   populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "select * from ProductTbl where ProdCat='" + SearchCb.selectedValue.ToString();
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
