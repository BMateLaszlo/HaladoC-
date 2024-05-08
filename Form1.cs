using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        
        public enum Player  // enum: custom data type
        {
            X, O            // enum can't be both at the same time
        }

        Player currentPlayer;
        Random random = new Random();
        int payerWinCount = 0;
        int CPUwinCount = 0;
        List<Button> buttons;
        



        public Form1()
        {
            InitializeComponent();
            RestartGame();              // If the game loads it will reset it
        }

        private void CPUmove(object sender, EventArgs e)
        {
            if (buttons.Count > 0) // if it still has some values inside of the list
            {
                int index = random.Next(buttons.Count); // select a random number between the existing buttons
                buttons[index].Enabled = false;
                currentPlayer = Player.O;           
                buttons[index].Text = currentPlayer.ToString();
                buttons[index].BackColor = Color.DarkSalmon; //change color
                buttons.RemoveAt(index);        //remove the that random number from the list
                CheckGame();
                CPUTimer.Stop();
            
            }
                    
        }

        private void PlayerClickButton(object sender, EventArgs e)
        {
            // have to identify which button is the sender of the click
            var button = (Button)sender;

            currentPlayer = Player.X;
            
            button.Text = currentPlayer.ToString(); // converting the X information to a string
            button.Enabled = false;     //making sure to disable the button  so it can't be clicked again in the same position
            button.BackColor = Color.Cyan;
            buttons.Remove(button); // CPU and the player can't select the same button
            CheckGame(); // check if the any of the 3 button mashed in a similar pattern
            CPUTimer.Start();  // if it isn't 
        }

        private void RestartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void CheckGame()
        {
            if ((button1.Text == "X" && button2.Text =="X" && button3.Text =="X")
               
            || (button4.Text == "X" && button5.Text == "X" && button6.Text == "X")
            || (button7.Text == "X" && button8.Text == "X" && button9.Text == "X")
            || (button1.Text == "X" && button4.Text == "X" && button7.Text == "X")
            || (button2.Text == "X" && button5.Text == "X" && button8.Text == "X")
            || (button3.Text == "X" && button6.Text == "X" && button9.Text == "X")
            || (button1.Text == "X" && button5.Text == "X" && button9.Text == "X")
            || (button3.Text == "X" && button5.Text == "X" && button7.Text == "X")

            )
            {
                CPUTimer.Stop();
                MessageBox.Show("Player Wins");
                payerWinCount++;
                label1.Text = $"Player wins:{  payerWinCount }";
                RestartGame();


            }
            else if ((button1.Text == "O" && button2.Text == "O" && button3.Text == "O")

            || (button4.Text == "O" && button5.Text == "O" && button6.Text == "O")
            || (button7.Text == "O" && button8.Text == "O" && button9.Text == "O")
            || (button1.Text == "O" && button4.Text == "O" && button7.Text == "O")
            || (button2.Text == "O" && button5.Text == "O" && button8.Text == "O")
            || (button3.Text == "O" && button6.Text == "O" && button9.Text == "O")
            || (button1.Text == "O" && button5.Text == "O" && button9.Text == "O")
            || (button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            )
            {
                CPUTimer.Stop();
                MessageBox.Show("CPU Wins");
                CPUwinCount++;
                label2.Text = $"CPU wins:{CPUwinCount}";
                RestartGame();
            }
        }

        private void RestartGame()
        {
            buttons = new List<Button> { button1, button2, button3, button4,
            button5, button6, button7, button8, button9};

            foreach (Button x in buttons)  // will go trough all the buttons
            {
                x.Enabled = true;
                x.Text = "?";
                x.BackColor = DefaultBackColor;
            
            }
        }
    }
}
