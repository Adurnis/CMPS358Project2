using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultipleFormsGUINetworkingTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartClient_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Enter an IP address to connect");
            }
            else
            {
                Form2 fm = new Form2("Client", textBox1.Text);
                fm.Show();
            }
        }

        private void StartHost_Click(object sender, EventArgs e)
        {
            Form2 fm = new Form2("Host", "");
            fm.Show();
        }
    }
}
