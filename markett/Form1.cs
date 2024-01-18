using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace markett
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

            if (UnameTB.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("enter the user name and password");
            }
            else
            {
                if (RoleCB.SelectedItem.ToString() == "Admin")
                {
                    if (UnameTB.Text == "Admin" && PassTb.Text == "Admin")
                    {
                        product prod = new product();
                        prod.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(" If you are the Admin , enter the correct Id  and Password ");
                    }
                }
                else if (RoleCB.SelectedItem.ToString() == "Seller")
                {
                    MessageBox.Show("you are a Seller");
                }
                else
                {
                    MessageBox.Show("select a Role");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
