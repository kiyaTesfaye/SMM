using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace markett
{
    public partial class seller : Form
    {
        public seller()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sid.Text = guna2DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            sname.Text = guna2DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            sage.Text = guna2DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            sphone.Text = guna2DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            spass.Text = guna2DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (sid.Text == "")
                {
                    MessageBox.Show("select the seller to Delete");
                }
                else
                {
                    Con.open();
                   
                    string query = "delete from sellerTbl where sellerId=" + sid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("seller delete successfully");

                    con.Close();
                   //  populate();
                    sid.Text = "";
                    sname.Text = "";
                    sphone.Text = "";
                    spass.Text = "";
                    sage.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string query = "insert into sellerTbl values (" + sid.Text + " , '" + sname.Text + "', '" + sage.Text + "' ,"+sphone.Text + ", "+spass.Text+ "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("seller added successfully");
                con.Close();
               // populate();
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
                if (sid.Text == "" || sname.Text == "" || sphone.Text == "" || sage.Text == "" || sphone.Text == "" || spass.Text == "")
                {
                    MessageBox.Show("missing Information");
                }
                else
                {
                    con.Open();
                    string query = "update sellerTbl set sallerName='" + sname.Text + "',sellerAge='" + sage.Text + "' , sellerPhone='" + sphone.Text + "', sellerpass='" + spass.Text + "' ,where sellerId=" + sid.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("seller successfuly updated");
                    Con.Close();
                   
                    //populate();
                }
            
            }
        }

        private void seller_Load(object sender, EventArgs e)
        {

        }
    }
}
