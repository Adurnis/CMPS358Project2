using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;
using System.Net;
using System.IO;

public enum gameState { Start, PlacingShips, ReadyToPlay, YourTurn, OpponentTurn};

namespace Salvo
{
    public partial class SalvoGame : Form
    {

        bool placingShip2 = true, placingShip3 = false, placingShip4 = false, placingShip5 = false;
        bool vertical = false;
        bool opponentReady = false;
        Dictionary<string, Button> buttonDic = new Dictionary<string, Button>();
        Dictionary<Button, string> opponentDic = new Dictionary<Button, string>();
        List<Button> fireList = new List<Button>();
        List<Button> shipList = new List<Button>();
        List<Button> ship2List = new List<Button>();
        List<Button> ship3List = new List<Button>();
        List<Button> ship4List = new List<Button>();
        List<Button> ship5List = new List<Button>();
        gameState state = gameState.Start;
        private TcpClient client;
        private StreamReader reader;
        private StreamWriter writer;
        private String TextReceived;
        Button lastShot;
        int score = 0;

        //initializer function to start the game
        public SalvoGame(string type, string ipAddress)
        {
            InitializeComponent();
            this.buttonDic.Add("A1", this.Player_A1);
            this.buttonDic.Add("A2", this.Player_A2);
            this.buttonDic.Add("A3", this.Player_A3);
            this.buttonDic.Add("A4", this.Player_A4);
            this.buttonDic.Add("A5", this.Player_A5);
            this.buttonDic.Add("A6", this.Player_A6);
            this.buttonDic.Add("A7", this.Player_A7);
            this.buttonDic.Add("A8", this.Player_A8);
            this.buttonDic.Add("A9", this.Player_A9);
            this.buttonDic.Add("A10", this.Player_A10);
            this.buttonDic.Add("B1", this.Player_B1);
            this.buttonDic.Add("B2", this.Player_B2);
            this.buttonDic.Add("B3", this.Player_B3);
            this.buttonDic.Add("B4", this.Player_B4);
            this.buttonDic.Add("B5", this.Player_B5);
            this.buttonDic.Add("B6", this.Player_B6);
            this.buttonDic.Add("B7", this.Player_B7);
            this.buttonDic.Add("B8", this.Player_B8);
            this.buttonDic.Add("B9", this.Player_B9);
            this.buttonDic.Add("B10", this.Player_B10);
            this.buttonDic.Add("C1", this.Player_C1);
            this.buttonDic.Add("C2", this.Player_C2);
            this.buttonDic.Add("C3", this.Player_C3);
            this.buttonDic.Add("C4", this.Player_C4);
            this.buttonDic.Add("C5", this.Player_C5);
            this.buttonDic.Add("C6", this.Player_C6);
            this.buttonDic.Add("C7", this.Player_C7);
            this.buttonDic.Add("C8", this.Player_C8);
            this.buttonDic.Add("C9", this.Player_C9);
            this.buttonDic.Add("C10", this.Player_C10);
            this.buttonDic.Add("D1", this.Player_D1);
            this.buttonDic.Add("D2", this.Player_D2);
            this.buttonDic.Add("D3", this.Player_D3);
            this.buttonDic.Add("D4", this.Player_D4);
            this.buttonDic.Add("D5", this.Player_D5);
            this.buttonDic.Add("D6", this.Player_D6);
            this.buttonDic.Add("D7", this.Player_D7);
            this.buttonDic.Add("D8", this.Player_D8);
            this.buttonDic.Add("D9", this.Player_D9);
            this.buttonDic.Add("D10", this.Player_D10);
            this.buttonDic.Add("E1", this.Player_E1);
            this.buttonDic.Add("E2", this.Player_E2);
            this.buttonDic.Add("E3", this.Player_E3);
            this.buttonDic.Add("E4", this.Player_E4);
            this.buttonDic.Add("E5", this.Player_E5);
            this.buttonDic.Add("E6", this.Player_E6);
            this.buttonDic.Add("E7", this.Player_E7);
            this.buttonDic.Add("E8", this.Player_E8);
            this.buttonDic.Add("E9", this.Player_E9);
            this.buttonDic.Add("E10", this.Player_E10);
            this.buttonDic.Add("F1", this.Player_F1);
            this.buttonDic.Add("F2", this.Player_F2);
            this.buttonDic.Add("F3", this.Player_F3);
            this.buttonDic.Add("F4", this.Player_F4);
            this.buttonDic.Add("F5", this.Player_F5);
            this.buttonDic.Add("F6", this.Player_F6);
            this.buttonDic.Add("F7", this.Player_F7);
            this.buttonDic.Add("F8", this.Player_F8);
            this.buttonDic.Add("F9", this.Player_F9);
            this.buttonDic.Add("F10", this.Player_F10);
            this.buttonDic.Add("G1", this.Player_G1);
            this.buttonDic.Add("G2", this.Player_G2);
            this.buttonDic.Add("G3", this.Player_G3);
            this.buttonDic.Add("G4", this.Player_G4);
            this.buttonDic.Add("G5", this.Player_G5);
            this.buttonDic.Add("G6", this.Player_G6);
            this.buttonDic.Add("G7", this.Player_G7);
            this.buttonDic.Add("G8", this.Player_G8);
            this.buttonDic.Add("G9", this.Player_G9);
            this.buttonDic.Add("G10", this.Player_G10);
            this.buttonDic.Add("H1", this.Player_H1);
            this.buttonDic.Add("H2", this.Player_H2);
            this.buttonDic.Add("H3", this.Player_H3);
            this.buttonDic.Add("H4", this.Player_H4);
            this.buttonDic.Add("H5", this.Player_H5);
            this.buttonDic.Add("H6", this.Player_H6);
            this.buttonDic.Add("H7", this.Player_H7);
            this.buttonDic.Add("H8", this.Player_H8);
            this.buttonDic.Add("H9", this.Player_H9);
            this.buttonDic.Add("H10", this.Player_H10);
            this.buttonDic.Add("I1", this.Player_I1);
            this.buttonDic.Add("I2", this.Player_I2);
            this.buttonDic.Add("I3", this.Player_I3);
            this.buttonDic.Add("I4", this.Player_I4);
            this.buttonDic.Add("I5", this.Player_I5);
            this.buttonDic.Add("I6", this.Player_I6);
            this.buttonDic.Add("I7", this.Player_I7);
            this.buttonDic.Add("I8", this.Player_I8);
            this.buttonDic.Add("I9", this.Player_I9);
            this.buttonDic.Add("I10", this.Player_I10);
            this.buttonDic.Add("J1", this.Player_J1);
            this.buttonDic.Add("J2", this.Player_J2);
            this.buttonDic.Add("J3", this.Player_J3);
            this.buttonDic.Add("J4", this.Player_J4);
            this.buttonDic.Add("J5", this.Player_J5);
            this.buttonDic.Add("J6", this.Player_J6);
            this.buttonDic.Add("J7", this.Player_J7);
            this.buttonDic.Add("J8", this.Player_J8);
            this.buttonDic.Add("J9", this.Player_J9);
            this.buttonDic.Add("J10", this.Player_J10);

            opponentDic.Add(A1, "A1");
            opponentDic.Add(A2, "A2");
            opponentDic.Add(A3, "A3");
            opponentDic.Add(A4, "A4");
            opponentDic.Add(A5, "A5");
            opponentDic.Add(A6, "A6");
            opponentDic.Add(A7, "A7");
            opponentDic.Add(A8, "A8");
            opponentDic.Add(A9, "A9");
            opponentDic.Add(A10, "A10");
            opponentDic.Add(B1, "B1");
            opponentDic.Add(B2, "B2");
            opponentDic.Add(B3, "B3");
            opponentDic.Add(B4, "B4");
            opponentDic.Add(B5, "B5");
            opponentDic.Add(B6, "B6");
            opponentDic.Add(B7, "B7");
            opponentDic.Add(B8, "B8");
            opponentDic.Add(B9, "B9");
            opponentDic.Add(B10, "B10");
            opponentDic.Add(C1, "C1");
            opponentDic.Add(C2, "C2");
            opponentDic.Add(C3, "C3");
            opponentDic.Add(C4, "C4");
            opponentDic.Add(C5, "C5");
            opponentDic.Add(C6, "C6");
            opponentDic.Add(C7, "C7");
            opponentDic.Add(C8, "C8");
            opponentDic.Add(C9, "C9");
            opponentDic.Add(C10, "C10");
            opponentDic.Add(D1, "D1");
            opponentDic.Add(D2, "D2");
            opponentDic.Add(D3, "D3");
            opponentDic.Add(D4, "D4");
            opponentDic.Add(D5, "D5");
            opponentDic.Add(D6, "D6");
            opponentDic.Add(D7, "D7");
            opponentDic.Add(D8, "D8");
            opponentDic.Add(D9, "D9");
            opponentDic.Add(D10, "D10");
            opponentDic.Add(E1, "E1");
            opponentDic.Add(E2, "E2");
            opponentDic.Add(E3, "E3");
            opponentDic.Add(E4, "E4");
            opponentDic.Add(E5, "E5");
            opponentDic.Add(E6, "E6");
            opponentDic.Add(E7, "E7");
            opponentDic.Add(E8, "E8");
            opponentDic.Add(E9, "E9");
            opponentDic.Add(E10, "E10");
            opponentDic.Add(F1, "F1");
            opponentDic.Add(F2, "F2");
            opponentDic.Add(F3, "F3");
            opponentDic.Add(F4, "F4");
            opponentDic.Add(F5, "F5");
            opponentDic.Add(F6, "F6");
            opponentDic.Add(F7, "F7");
            opponentDic.Add(F8, "F8");
            opponentDic.Add(F9, "F9");
            opponentDic.Add(F10, "F10");
            opponentDic.Add(G1, "G1");
            opponentDic.Add(G2, "G2");
            opponentDic.Add(G3, "G3");
            opponentDic.Add(G4, "G4");
            opponentDic.Add(G5, "G5");
            opponentDic.Add(G6, "G6");
            opponentDic.Add(G7, "G7");
            opponentDic.Add(G8, "G8");
            opponentDic.Add(G9, "G9");
            opponentDic.Add(G10, "G10");
            opponentDic.Add(H1, "H1");
            opponentDic.Add(H2, "H2");
            opponentDic.Add(H3, "H3");
            opponentDic.Add(H4, "H4");
            opponentDic.Add(H5, "H5");
            opponentDic.Add(H6, "H6");
            opponentDic.Add(H7, "H7");
            opponentDic.Add(H8, "H8");
            opponentDic.Add(H9, "H9");
            opponentDic.Add(H10, "H10");
            opponentDic.Add(I1, "I1");
            opponentDic.Add(I2, "I2");
            opponentDic.Add(I3, "I3");
            opponentDic.Add(I4, "I4");
            opponentDic.Add(I5, "I5");
            opponentDic.Add(I6, "I6");
            opponentDic.Add(I7, "I7");
            opponentDic.Add(I8, "I8");
            opponentDic.Add(I9, "I9");
            opponentDic.Add(I10, "I10");
            opponentDic.Add(J1, "J1");
            opponentDic.Add(J2, "J2");
            opponentDic.Add(J3, "J3");
            opponentDic.Add(J4, "J4");
            opponentDic.Add(J5, "J5");
            opponentDic.Add(J6, "J6");
            opponentDic.Add(J7, "J7");
            opponentDic.Add(J8, "J8");
            opponentDic.Add(J9, "J9");
            opponentDic.Add(J10, "J10");

           

            //--------------------------------------------------------------------------------
            //start the listener for the host computer and accept a client from any ipAddress
            //--------------------------------------------------------------------------------
            if (type == "Host")
            {
                TcpListener listener = new TcpListener(IPAddress.Any, 51111);
                listener.Start();
                client = listener.AcceptTcpClient();
                reader = new StreamReader(client.GetStream());
                writer = new StreamWriter(client.GetStream());
                writer.AutoFlush = true;
                state = gameState.PlacingShips;
                MessageBox.Show("Connected!");
                backgroundWorker1.RunWorkerAsync();     //start receiving data in the background
            }
            
            if(type == "Client")
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
                        state = gameState.PlacingShips;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //Logic for placing the ships at the start of the game
        private void PlaceShips_Clicks(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            string text = button.Text;



            if (placingShip2)
            {
                if (vertical)
                {
                    if (text.Length == 3)
                        return;
                    for (int i = 0; i < 2; i++)
                    {
                        // : is the ascii code right after 9
                        if (text[1] == ':')
                        {
                            text = text.Replace(":", "10");
                            buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                            shipList.Add(buttonDic[text]);
                            break;
                        }
                        buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                        shipList.Add(buttonDic[text]);
                        ship2List.Add(buttonDic[text]);

                        byte[] asciiByte = Encoding.ASCII.GetBytes(text);
                        asciiByte[1] += 1;
                        text = Encoding.ASCII.GetString(asciiByte);


                    }
                }
                else
                {
                    if (text[0] == 'J')
                        return;
                    for (int i = 0; i < 2; i++)
                    {

                        buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                        shipList.Add(buttonDic[text]);
                        ship2List.Add(buttonDic[text]);

                        byte[] asciiByte = Encoding.ASCII.GetBytes(text);
                        asciiByte[0] += 1;
                        text = Encoding.ASCII.GetString(asciiByte);


                    }

                }
                placingShip2 = false;
                placingShip3 = true;
                messageBoard.Text = "Place Ship 3";
            }

            else if (placingShip3)
            {
                if (vertical)
                {
                    if (text.Length == 3 || text[1] == '9')
                        return;
                    for (int i = 0; i < 3; i++)
                    {

                        if (text[1] == ':')
                        {
                            text = text.Replace(":", "10");
                            buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                            shipList.Add(buttonDic[text]);
                            break;
                        }
                        buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                        shipList.Add(buttonDic[text]);
                        ship3List.Add(buttonDic[text]);

                        byte[] asciiByte = Encoding.ASCII.GetBytes(text);
                        asciiByte[1] += 1;
                        text = Encoding.ASCII.GetString(asciiByte);
                    }
                }
                else
                {
                    if (text[0] == 'J' || text[0] == 'I')
                        return;
                    for (int i = 0; i < 3; i++)
                    {


                        buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                        shipList.Add(buttonDic[text]);
                        ship3List.Add(buttonDic[text]);

                        byte[] asciiByte = Encoding.ASCII.GetBytes(text);
                        asciiByte[0] += 1;
                        text = Encoding.ASCII.GetString(asciiByte);


                    }

                }
                placingShip3 = false;
                placingShip4 = true;
                messageBoard.Text = "Place Ship 4";
            }

            else if (placingShip4)
            {
                if (vertical)
                {
                    if (text.Length == 3 || text[1] == '9' || text[1] == '8')
                        return;
                    for (int i = 0; i < 4; i++)
                    {
                        if (text[1] == ':')
                        {
                            text = text.Replace(":", "10");
                            buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                            shipList.Add(buttonDic[text]);
                            break;
                        }
                        buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                        shipList.Add(buttonDic[text]);
                        ship4List.Add(buttonDic[text]);

                        byte[] asciiByte = Encoding.ASCII.GetBytes(text);
                        asciiByte[1] += 1;
                        text = Encoding.ASCII.GetString(asciiByte);
                    }
                }
                else
                {
                    if (text[0] == 'J' || text[0] == 'I' || text[0] == 'H')
                        return;
                    for (int i = 0; i < 4; i++)
                    {

                        buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                        shipList.Add(buttonDic[text]);
                        ship4List.Add(buttonDic[text]);

                        byte[] asciiByte = Encoding.ASCII.GetBytes(text);
                        asciiByte[0] += 1;
                        text = Encoding.ASCII.GetString(asciiByte);


                    }

                }
                placingShip4 = false;
                placingShip5 = true;
                messageBoard.Text = "Place Ship 5";
            }

            else if (placingShip5)
            {

                if (vertical)
                {
                    if (text.Length == 3 || text[1] == '9' || text[1] == '8' || text[1] == '7')
                        return;
                    for (int i = 0; i < 5; i++)
                    {
                        if (text[1] == ':')
                        {
                            text = text.Replace(":", "10");
                            buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                            shipList.Add(buttonDic[text]);
                            break;
                        }
                        buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                        shipList.Add(buttonDic[text]);
                        ship5List.Add(buttonDic[text]);

                        byte[] asciiByte = Encoding.ASCII.GetBytes(text);
                        asciiByte[1] += 1;
                        text = Encoding.ASCII.GetString(asciiByte);
                    }
                }
                else
                {
                    if (text[0] == 'J' || text[0] == 'I' || text[0] == 'H' || text[0] == 'G')
                        return;
                    for (int i = 0; i < 5; i++)
                    {

                        buttonDic[text].BackColor = System.Drawing.Color.LightGreen;
                        shipList.Add(buttonDic[text]);
                        ship5List.Add(buttonDic[text]);

                        byte[] asciiByte = Encoding.ASCII.GetBytes(text);
                        asciiByte[0] += 1;
                        text = Encoding.ASCII.GetString(asciiByte);


                    }

                }
                placingShip5 = false;
                messageBoard.Text = "";
                state = gameState.ReadyToPlay;
                dataSender("readyToPlay");

                if (opponentReady)
                {
                    Random rand = new Random();
                    int randInt = rand.Next(100);

                    if (randInt % 2 == 0)
                    {
                        state = gameState.YourTurn;
                        MessageBox.Show("Your First!");
                        dataSender("YourSecond");
                    }
                    else
                    {
                        state = gameState.OpponentTurn;
                        MessageBox.Show("Your Second.");
                        dataSender("YourFirst");
                    }
                }
                else
                {
                    messageBoard.Text = "Once your opponent is ready, the game will start!";
                }
            }

        }

        //place the current ship horizontally
        private void horiz_CheckedChanged(object sender, EventArgs e)
        {
            vertical = false;
        }

        //place the current ship vertically
        private void verti_CheckedChanged(object sender, EventArgs e)
        {
            vertical = true;
        }

        //send the players chosen shot location to their opponent
        private void send_Shot(object sender, EventArgs e)
        {
            if(state == gameState.YourTurn)
            {
                Button button = sender as Button;
                if (fireList.Contains(button))
                {
                    messageBoard.Text = "You have alredy fired there!";
                    return;
                }

                //add the button to the list of locations the player has fired at
                fireList.Add(button);
                //get the string to send to the opponent 
                string textToSend = opponentDic[button];
                //call the function to send information to the opponent
                lastShot = button;  //what needs to be marked as a hit or miss
                dataSender(textToSend);
            }
            else
            {
                messageBoard.Text = "It is not your turn.";
            }
        }

        private async void dataSender(string textToSend)
        {
            //send the information to th opponent. 
            //It is not the opponents turn until they get a message saying "YourTurn"
            await writer.WriteLineAsync(textToSend);
        }

        //send and recieve messages from the opponent
        private void backgroundWorker1_doWork(object sender, DoWorkEventArgs e)
        {
            while (client.Connected)
            {
                try
                {
                    TextReceived = reader.ReadLine();
                    
                    if(TextReceived == "readyToPlay")
                    {
                        opponentReady = true;
                    }

                    if (TextReceived == "YourTurn")
                    {
                        state = gameState.YourTurn;
                    }
                    if(TextReceived == "win")
                    {
                        MessageBox.Show("You Lose!");
                        Application.Exit();
                        
                    }
                    switch (state)
                    {
                        case gameState.ReadyToPlay:
                            if (TextReceived == "YourFirst")
                            {
                                state = gameState.YourTurn;
                                MessageBox.Show("Your first!");
                            }

                            if (TextReceived == "YourSecond")
                            {
                                state = gameState.OpponentTurn;
                                MessageBox.Show("Your second!");
                            }
                            break;

                        case gameState.YourTurn:
                            if (TextReceived == "hit")
                            {
                                MessageBox.Show("Hit!");
                                lastShot.BackColor = Color.Red;
                                dataSender("YourTurn");
                                state = gameState.OpponentTurn;
                            }

                            if (TextReceived == "miss")
                            {
                                MessageBox.Show("Miss!");
                                lastShot.BackColor = Color.LightBlue;
                                dataSender("YourTurn");
                                state = gameState.OpponentTurn;
                            }
                            if(TextReceived == "hitsunk")
                            {
                                MessageBox.Show("Sunk!");
                                lastShot.BackColor = Color.Red;
                                
                                score++;
                                if(score == 4)
                                {
                                    dataSender("win");
                                    MessageBox.Show("You Win!");
                                    Application.Exit();
                                }
                                else
                                {
                                    dataSender("YourTurn");
                                    state = gameState.OpponentTurn;
                                }
                            }
                            break;

                        case gameState.OpponentTurn:
                            Button b = new Button();
                            buttonDic.TryGetValue(TextReceived, out b);
                            if (shipList.Contains(b))
                            {
                                if(ship2List.Contains(b))
                                {
                                    ship2List.Remove(b);
                                    if(ship2List.Count == 0)
                                    {
                                        b.BackColor = Color.Red;
                                        dataSender("hitsunk");
                                        MessageBox.Show("Sunk");
                                        break;
                                    }
                                    
                                }
                                else if (ship3List.Contains(b))
                                {
                                    ship3List.Remove(b);
                                    if (ship3List.Count == 0)
                                    {
                                        b.BackColor = Color.Red;
                                        dataSender("hitsunk");
                                        MessageBox.Show("Sunk");
                                        break;
                                    }

                                }
                                else if (ship4List.Contains(b))
                                {
                                    ship4List.Remove(b);
                                    if (ship4List.Count == 0)
                                    {
                                        b.BackColor = Color.Red;
                                        dataSender("hitsunk");
                                        MessageBox.Show("Sunk");
                                        break;
                                    }

                                }
                                else if (ship5List.Contains(b))
                                {
                                    ship5List.Remove(b);
                                    if (ship5List.Count == 0)
                                    {
                                        b.BackColor = Color.Red;
                                        dataSender("hitsunk");
                                        MessageBox.Show("Sunk");
                                        break;
                                    }

                                }
                                b.BackColor = Color.Red;
                               
                                MessageBox.Show("Hit");
                                dataSender("hit");
                            }
                            else
                            {
                                b.BackColor = Color.LightBlue;
                                MessageBox.Show("Miss");
                                dataSender("miss");
                            }
                            break;
                        
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}