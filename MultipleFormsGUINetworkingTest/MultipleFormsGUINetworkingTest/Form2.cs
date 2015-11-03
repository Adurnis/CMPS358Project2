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

namespace MultipleFormsGUINetworkingTest
{
    public partial class Form2 : Form
    {
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private String buttonTextReceived;
        private List<Button> buttons;

        public Form2(String type)
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.sendShot);
            this.button2.Click += new System.EventHandler(this.sendShot);
            this.button3.Click += this.sendShot;

            buttons = this.Controls.OfType<Button>().ToList();

            foreach (Button b in buttons)
            {
                MessageBox.Show(b.Text);
            }

            if (type == "Host")
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 51111);
                listener.Start();
                client = listener.AcceptTcpClient();
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;

                backgroundWorker1.RunWorkerAsync();     //start receiving data in the background
            }

            if (type == "Client")
            {
                client = new TcpClient();
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse("10.88.69.128"), 51111);

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
        }

        public void sendShot(object sender, EventArgs e)
        {
            Button button = sender as Button;
            button.BackColor = Color.Red;
            MessageBox.Show(button.Text);
            dataSender(button.Text);
        }

        private async void dataSender(String ToSend)
        {
            await writer.WriteLineAsync(ToSend);
        }

        private void backgroundWorkder1_dowork(object sender, DoWorkEventArgs e)
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
