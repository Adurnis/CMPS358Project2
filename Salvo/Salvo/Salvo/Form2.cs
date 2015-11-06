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

public enum gameState { Start, PlacingShips, ReadyToPlay, YourTurn, OppenentTurn, End };

namespace Salvo
{
    public partial class Form2 : Form
    {
        private gameState State = gameState.Start;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private String TextReceived;
        private List<Button> buttons;
        private List<Button> ChosenButtons = new List<Button>();

        public Form2(String type, String ipAddress)
        {
            InitializeComponent();


            //set up this connection as a host waiting for someone to connect
            if (type == "Host")
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 51111);
                listener.Start();
                client = listener.AcceptTcpClient();
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;

                backgroundWorker1.RunWorkerAsync();     //start receiving data in the background

                this.Text = "Salvo Game Host";
                State = gameState.OppenentTurn;
            }

            //set up this connecion as a client connecting to a host via their ip address
            if (type == "Salvo Game Client")
            {
                client = new TcpClient();
                IPEndPoint IpEnd = new IPEndPoint(IPAddress.Parse(ipAddress), 51111);

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
                        this.Text = "Client";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                State = gameState.YourTurn;
            }
        }

        private void backgroundWorker1_dowork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    TextReceived = reader.ReadLine();
                    if (TextReceived == "YourTurn")
                        State = gameState.YourTurn;

                    if (State == gameState.OppenentTurn)
                    {
                        foreach (Button b in buttons)
                        {
                            if (b.Name.ToString() == TextReceived)
                            {
                                b.BackColor = Color.Blue;
                            }
                        }
                    }

                    TextReceived = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            State = gameState.End;
            Application.Exit();
        }
    }
}
