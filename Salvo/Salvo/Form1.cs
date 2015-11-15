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

        //this button allows the user to start the game as a client who is connecting to another players game
        private void StartClient_Click(object sender, EventArgs e)
        {
            //make sure the user has entered 
            if(ipAddressBox.Text == "")
            {
                MessageBox.Show("You need to enter an IP address in order to connect.");
                return;
            }
            //start the game in a new form
            sg = new SalvoGame("Client", ipAddressBox.Text);
            sg.Show();
        }
        
        //this button allows the user to start the game as a host who is waiting for another player to connect
        private void StartHost_Click(object sender, EventArgs e)
        {
            //start the game in a new form
            sg = new SalvoGame("Host", "");
            sg.Show();
        }
    }
}
