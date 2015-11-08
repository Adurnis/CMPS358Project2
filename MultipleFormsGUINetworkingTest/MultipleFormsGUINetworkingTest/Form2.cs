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

public enum gameState { Start, PlacingShips, ReadyToPlay, YourTurn, OppenentTurn, End};

namespace MultipleFormsGUINetworkingTest
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
            this.button1.Click += new System.EventHandler(this.sendShot);
            this.button2.Click += this.sendShot;
            this.button3.Click += this.sendShot;

            buttons = this.Controls.OfType<Button>().ToList();

            //foreach (Button b in buttons)
            //{
            //    MessageBox.Show(b.Text);
            //}

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
            if (type == "Client")
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
                        this.Text = "Salvo Game Client";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                State = gameState.YourTurn;
            }

            //-----*&*&$%^$&#$^@#%$@#^&%^^$%^&^%$#@!@#$^&*()(*&^%$#@!!@#$%^*()(*&^%$#-----
            //State = gameState.PlacingShips; //logic for placing ships will come "here"
            //after placing ships, radomly decide who goes first and set the states to the proper values
        }

        //send the "shot" or button click information 
        public void sendShot(object sender, EventArgs e)
        {
            if(State == gameState.YourTurn)
            {

                Button button = sender as Button;
                //add the selected button to the list of locations the user has fired at already
                //this will protect against the user wasting a turn by shooting somewhere they already have
                if (ChosenButtons.Contains(button))
                    MessageBox.Show("You have alredy fired at " + button.Text);
                else
                {
                    ChosenButtons.Add(button);
                    button.BackColor = Color.Red;
                    dataSender(button.Text);
                    State = gameState.OppenentTurn;
                }
            }
            else
            {
                MessageBox.Show("It is not your turn!");
            }
        }

        private async void dataSender(String ToSend)
        {
            await writer.WriteLineAsync(ToSend);
            await writer.WriteLineAsync("YourTurn");
        }

        private void backgroundWorkder1_dowork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    TextReceived = reader.ReadLine();
                    if (TextReceived == "YourTurn")
                        State = gameState.YourTurn;

                    if(State == gameState.OppenentTurn)
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
