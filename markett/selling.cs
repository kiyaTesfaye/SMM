using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace markett
{
    public partial class selling : Form
    {
        public selling()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void PrdoDGV1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            prodName.Text = PrdoDGV1.SelectedRows[0].Cells[0].Value.ToString();
            prodPrice.Text = PrdoDGV1.SelectedRows[0].Cells[1].Value.ToString();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;
        AttachDbFilename=C:\Users\512\Documents\supermarketdb.mdf;
        Integrated Security=True;Connect Timeout=30 ");

        private void populate()
        {
            con.Open();
            string query = "select proName , proQty  from ProductTbl1";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PrdoDGV1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void populatebills()
        {
            con.Open();
            string query = "select *  from BillTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillsDGV.DataSource = ds.Tables[0];
            con.Close();
        }
        private void selling_Load(object sender, EventArgs e)
        {
            populate();
            populatebills();
        }
        int flag = 0;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Datelbl.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }

        private void Datelbl_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            int Grdtotal=0;
            int n = 0;
            if (prodName.Text == " " || prodQty.Text == "")
            {
                MessageBox.Show("missing Data");
            }
            else
            {
              
                int total = Convert.ToInt32(prodPrice.Text) * Convert.ToInt32(prodQty.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ORDERDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = prodName.Text;
                newRow.Cells[2].Value = prodPrice.Text;
                newRow.Cells[3].Value = prodQty.Text;
                newRow.Cells[4].Value = Convert.ToInt32(prodPrice.Text) * Convert.ToInt32(prodQty.Text);
                ORDERDGV.Rows.Add(newRow);
                n++;
                Grdtotal = Grdtotal + total;
                Amtlbl.Text = " " + Grdtotal;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (BillId.Text == "")
            {
                MessageBox.Show("missing Bill Id");
            }
            else
            {


                try
                {
                    con.Open();
                    string query = "insert into BillTbl1 values (" + BillId.Text + " , " + sellerNamelbl.Text + ", " + Datelbl.Text + " , " + Amtlbl.Text + " )";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("order added successfully");
                    con.Close();
                    populatebills();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void BillsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            flag = 1;
        }

        private void ORDERDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            e.Graphics.DrawString("HABESHASUPERMARKET", new Font("Century Gothic", 25, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Bill ID: "+BillsDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100,70));
            e.Graphics.DrawString("Seller Name: " + BillsDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 100));
            e.Graphics.DrawString("Date: " + BillsDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 130));
            e.Graphics.DrawString("Total Amount: " + BillsDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Blue, new Point(100, 160));
            e.Graphics.DrawString("CodeSpace", new Font("Century Gothic", 20, FontStyle.Italic), Brushes.Red, new Point(270,230));

        }


        private void button7_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void CatCb_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
