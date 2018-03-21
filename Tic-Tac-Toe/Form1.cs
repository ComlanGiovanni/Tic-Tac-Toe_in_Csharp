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
        bool playerTurn = true;// X Turn -> true , O Turn -> false
        int turnCount = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoNewGame();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();//Close the App if we click on exit on the strip menu
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe");//About Section
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button theButtton = (Button)sender;

            if (playerTurn)
            {
                theButtton.Text = "X";
                theButtton.Enabled = false;
            }
            else
            {
                theButtton.Text = "O";
                theButtton.Enabled = false;
            }

            turnCount++;//for the draws, the maxium play is 9
            playerTurn = !playerTurn;
            checkWinner();
        }

        private void checkWinner()
        {
            /*
            foreach(Control x in Controls)//emunmeration of all controls{}
            */
            bool weHaveWinner = false;

            //Switch possible ?

            //---
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A2.Enabled))
                weHaveWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B2.Enabled))
                weHaveWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C2.Enabled))
                weHaveWinner = true;

            // |||
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!B1.Enabled))
                weHaveWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!B2.Enabled))
                weHaveWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!B3.Enabled))
                weHaveWinner = true;

            //X
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!B2.Enabled))
                weHaveWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!B2.Enabled))
                weHaveWinner = true;
              

            if (weHaveWinner)
            {
                //disableAllbtn();

                String winner = "";

                if (playerTurn)
                    winner = "0";
                else
                    winner = "X";

                MessageBox.Show(winner + " Wins!", "GG");
                autoNewGame();
            }
            else
            {
                if(turnCount == 9)
                {
                    MessageBox.Show("Draw");
                    //disableAllbtn();
                    autoNewGame();
                }

            }

        }

        /*
        private void disableAllbtn()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }//Ignoring the menu strip (is not a button)
        }*/

        private void autoNewGame()
        {
            playerTurn = true;
            turnCount = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button theButtton = (Button)c;
                    theButtton.Enabled = true;
                    theButtton.Text = "";
                }
            }
            catch { }
        } 
    }
}
