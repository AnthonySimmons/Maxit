/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 7, 2013					            		*
* Description: Maxit Form Class that holds the GUI Controls     *
*   and Maxit Game Class                                        *
****************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;

namespace Maxit
{
    public partial class MaxitForm : Form
    {
        public maxit game = new maxit();
        
        public MaxitForm()
        {
            InitializeComponent();
            this.BackColor = Color.CornflowerBlue;
            lblChose.Visible = false;
            game = new maxit();
            game.n = 3;
            //initBtns(game.n);
        }

/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: deleteButtons()								*
* Description: Removes all buttons from the form                *
* Preconditions: None											*
* Postconditions: No more buttons                               *
****************************************************************/
        public void deleteButtons()
        {
            foreach (Button btn in game.btns)
            {
                this.Controls.Remove(btn);
            }
        }


/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: resizeForm()								    *  
* Description: Resized Form based on board size                 *
* Preconditions: None											*
* Postconditions: Game board easier to see                      *
****************************************************************/
        public void resizeForm()
        {
            this.Height = Math.Max(this.Height, game.n * game.btns[0].Height + 135);
            this.Width = Math.Max(this.Width, game.n * game.btns[0].Width + 60);
        }

        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 6, 2013								        *
        * Function Name: handleBtnClick()								*
        * Description: Finds the button that is clicked and runs the    *
        *           Next move according to game settings                * 
        * Preconditions: None											*
        * Postconditions: Scores updated, next turn enabled             *
        ****************************************************************/
        public void handleBtnClick(object sender)
        {
            if (game.playersTurn)
            {
                foreach (Button btn in game.btns)
                {//Find the button that was pressed
                    if (Object.Equals(sender, btn))
                    {
                        game.playerScore += System.Convert.ToInt32(btn.Text);
                        game.playersTurn = !game.playersTurn;
                        game.currentPos = System.Convert.ToInt32(btn.Name);
                        game.btns[game.currentPos].Visible = false;
                    }
                }
                if (cbxSim.Checked)
                {//Run Simulation
                    do
                    {
                        game.disableBtns();
                        game.enableRowsColumns();
                        game.compAI();
                        game.maxStrategy();
                        //updateLabels();
                        game.checkGameOver(false);
                    } while (game.checkGameOver(true) == "");
                    updateLabels();
                }
                else
                {//Run one move
                    //game.disableRowsColumns();
                    //game.enableRowsColumns();
                    game.disableBtns();
                    game.enableRowsColumns();
                    game.compAI();
                    updateLabels();
                    game.checkGameOver(true);
                }
            }
        }

/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: initBtns()								        *
* Description: Initializes all buttons on the form              *
* Preconditions: Positive nSize									*
* Postconditions: Buttons are available                         *
****************************************************************/
        public void initBtns(int nSize)
        {
            game.btns = new Button[nSize * nSize];
            game.n = nSize;
            for (int i = 0; i < nSize * nSize; i++)
            {
                int j = i % nSize;
                int k = i / nSize;
                int x = (j * 28) + 20;
                int y = (k * 22) + 80;
                game.btns[i] = new Button();
                game.btns[i].Visible = true;
                game.btns[i].Name = i.ToString();
                game.btns[i].Enabled = false;
                game.btns[i].Location = new Point(x, y);
                game.btns[i].FlatStyle = FlatStyle.Flat;
                game.btns[i].Width = 28;
                game.btns[i].Height = 22;
                game.btns[i].Text = i.ToString();
                game.btns[i].Click += new EventHandler(btnClick);
                this.Controls.Add(game.btns[i]);
            }
            resizeForm();
        }
/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: updateLabels()								    *
* Description: Updates all labels on form, score, selections    *
* Preconditions: None											*
* Postconditions: User sees game status                         *
****************************************************************/
        private void updateLabels()
        {
            int row = game.currentPos / game.n;
            int column = game.currentPos % game.n;

            lblChose.Visible = true;
            if (game.playersTurn)
            { lblChose.Text = "Player Chose: " + game.btns[game.currentPos].Text + " at [" + row.ToString() + "," + column.ToString() + "]"; }
            else { lblChose.Text = "Computer Chose: " + game.btns[game.currentPos].Text + " at [" + row.ToString() + "," + column.ToString() + "]"; }
            lblCompScore.Text = "Computer's Score: " + game.compScore.ToString();
            lblPlayerScore.Text = "Player's Score: " + game.playerScore.ToString();
        }

        public void btnClick(object sender, EventArgs e)
        {
            handleBtnClick(sender);
        }

/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: startGame()								    *
* Description: Sets Initial Game settings, and starts game      *
* Preconditions: None											*
* Postconditions: Game is ready to play                         *
****************************************************************/
        public void startGame()
        {
            if (tbxSize.Text != "" && tbxSize.Text != null)
            {
                game.playersTurn = true;
                if (rdobtnHard.Checked) { game.difficulty++; }
                game.playerScore = 0;
                game.compScore = 0;
                deleteButtons();
                game.n = Math.Abs(System.Convert.ToInt32(tbxSize.Text));
                game.n = Math.Max(1, game.n);
                initBtns(game.n);
                game.randomNums();
                game.selectInitialPos();
                game.enableRowsColumns();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void btnTests_Click(object sender, EventArgs e)
        {
            Test_Maxit tests = new Test_Maxit();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string str = "";
            str += "*************************************************************************\n";
            str += "********************************* Maxit *********************************\n"; ;
            str += "*************************************************************************\n\n";
            str += "Easy - Computer chooses the Largest Value Available\n\n";
            str += "Hard - Computer looks ahead one move and finds the \n";
            str += "    largest difference between its selection and the\n";
            str += "    largest possible selection on the player's next turn\n\n";
            str += "Run Tests - Opens a new window, prompting the user to select a\n";
            str += "    test case to run. Select a test then click 'Run Test'. \n";
            str += "    Once test test has been completed, the results will be shown.\n\n";
            str += "Run Simulation - Will Simulate the player's selections by choosing\n";
            str += "    the largest possible value. Runs until the game is over\n";
            str += "    If this button is checked, the user must select one value to start\n";
            str += "    (Running the simulation on hard with a large board Size usually\n";
            str += "     results with the Computer Winning)\n\n";
            str += "\t  Designed by Anthony Simmons\n";
            str += "\t  Washington State University - Fall 2013\n";
            MessageBox.Show(str);
        }

    }
}
