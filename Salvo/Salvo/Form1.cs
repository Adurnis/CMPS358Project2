using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Salvo
{
    public partial class Form1 : Form
    {
        private SalvoGame sg;

        public Form1()
        {
            InitializeComponent();
        }

        private void StartClient_Click(object sender, EventArgs e)
        {
            if(ipAddressBox.Text == "")
            {
                MessageBox.Show("You need to enter an IP address in order to connect.");
                return;
            }
            sg = new SalvoGame("Client", ipAddressBox.Text);
            sg.Show();
        }

        private void StartHost_Click(object sender, EventArgs e)
        {
            sg = new SalvoGame("Host", "");
            sg.Show();
        }
    }
}
