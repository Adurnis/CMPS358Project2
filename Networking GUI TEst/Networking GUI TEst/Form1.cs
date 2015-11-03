using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.IO;


namespace Networking_GUI_TEst
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private String buttonTextReceived;
        private List<Button> buttons;

        public Form1()
        {
            InitializeComponent();  //needs to be the first line

            this.button1.Click += new System.EventHandler(this.SendShot);
            this.button2.Click += new System.EventHandler(this.SendShot);
            this.button3.Click += new System.EventHandler(this.SendShot);

            buttons = this.Controls.OfType<Button>().ToList();  //puts all the buttons on the form into a list


            //buttons.Add(button1);
            //buttons.Add(button2);
            //buttons.Add(button3);

            foreach (Button b in buttons)
            {
                MessageBox.Show(b.Text);
            }
        
        }

        public void SendShot(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Red;
            MessageBox.Show(button.Text);
            dataSender(button.Text);            
        }

        private async void dataSender(String toSend)
        {
            await writer.WriteLineAsync(toSend);
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 51111);
            listener.Start();
            client = listener.AcceptTcpClient();
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
            writer.AutoFlush = true;

            backgroundWorker1.RunWorkerAsync();     //start receiving data in the background
        }

        private void StartClientButton_Click(object sender, EventArgs e)
        {
            client = new TcpClient();
            IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 51111);

            try
            {
                client.Connect(IpEnd);
                if (client.Connected)
                {
                    MessageBox.Show("Connected!");
                    writer = new StreamWriter(client.GetStream());
                    reader = new StreamReader(client.GetStream());
                    writer.AutoFlush = true;

                    backgroundWorker1.RunWorkerAsync(); //start receiving data in the background
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_doWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    buttonTextReceived = reader.ReadLine();
                    foreach (Button b in buttons)
                    {
                        if (b.Name.ToString() == buttonTextReceived)
                        {
                            
                            b.BackColor = Color.Blue;
                        }
                    }
                    buttonTextReceived = "";
                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
