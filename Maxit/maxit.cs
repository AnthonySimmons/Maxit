/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 7, 2013					            			*
* Description: Maxit Class the runs the Maxit Game              *
****************************************************************/

using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Maxit
{
    public class maxit
    {
	//Variable Initialize
        public int n = 3;
        public int currentPos = 0;
        public Button[] btns = new Button[1];
        public int playerScore = 0;
        public int compScore = 0;
        public bool playersTurn = true;
        public int difficulty = 0;

        public maxit()
        { 
            n = 3;
            currentPos = 0;
            btns = new Button[1];
            playerScore = 0;
            compScore = 0;
            difficulty = 0;
            playersTurn = true;
        }

	//Copy Maxit from source
        public maxit(maxit source)
        {
            n = source.n;
            currentPos = source.currentPos;
            playerScore = source.playerScore;
            compScore = source.compScore;
            difficulty = source.difficulty;
            playersTurn = source.playersTurn;
            btns = new Button[n];
            for (int i = 0; i < n*n; i++)
            { 
                btns[i] = new Button();
                btns[i] = source.btns[i];
            }
        }



/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: disableBtns()								    *
* Description: Disables all buttons on the form                 *
* Preconditions: None											*
* Postconditions: Btns in new Row/Column can be initialized     *
****************************************************************/
        public void disableBtns()
        {
            foreach (Button btn in btns)
            {
                btn.Enabled = false;
                btn.BackColor = Color.Silver;
                //btn.FlatStyle = FlatStyle.Popup;
            }
        }

    /****************************************************************
    * Author: Anthony Simmons                                       *
    * Assignment: Homework #1 - Testing Maxit		 				*
    * Course: CptS 422 - Software Testing							*
    * Date: September 6, 2013								        *
    * Function Name: enableRowsColumns()							*
    * Description: Enables the buttons in the current row and column*
    * Preconditions: None											*
    * Postconditions: User can select next move                     *
    ****************************************************************/
        public void enableRowsColumns()
        {
		//Calculate Row and Column (Mailman Algorithm)
            int row = currentPos / n;
            int column = currentPos % n;
		//Iterate through current Row
            for (int i = row * n; i < row * n + n; i++)
            {
                //btns[i].FlatStyle = FlatStyle.Flat;
                btns[i].Enabled = true;
                btns[i].BackColor = Color.Gold;
            }
		//Iterate through current column
            for (int i = column; i < n * n; i += n)
            {
                //btns[i].FlatStyle = FlatStyle.Flat;
                btns[i].Enabled = true;
                btns[i].BackColor = Color.Gold;
            }
        }
/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: disableRowsColumns()							*
* Description: Disables buttons in current row and column       *
* Preconditions: None											*
* Postconditions: User cannot select these buttons next move    *
****************************************************************/
        public void disableRowsColumns()
        {
            /*foreach (Button btn in btns)
            {
                btn.Enabled = false;
                btn.FlatStyle = FlatStyle.Popup;
                btn.BackColor = Color.Silver;
            }*/
		//Calculate current row and column (Mailman Algorithm)
            int row = currentPos / n;
            int column = currentPos & n;
		
		//Iterate through row
            for (int i = row * n; i < row * n + n; i++)
            {
                btns[i].Enabled = false;
             //   btns[i].FlatStyle = FlatStyle.Popup;
                btns[i].BackColor = Color.Silver;
            }
		//Iterate through column
            for (int i = column; i < n * n; i += n)
            {
                btns[i].Enabled = false;
               // btns[i].FlatStyle = FlatStyle.Popup;
                btns[i].BackColor = Color.Silver;
            }
        }

	    //Same as compAI(), without looking ahead one move
        //and assigns value to player's score
        //Used when running simulation
/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: maxStrategy()		    						*
* Description: Used in simulation, selects the maximum value    *
 *      for the user's turn
* Preconditions: Running a simulation							*
* Postconditions: CompAI can run its next move                  *
****************************************************************/
        public void maxStrategy()
        {
            int newPos = 0;
            int row = currentPos / n;
            int column = currentPos % n;//1
            int maxNum = -100;
            for (int i = row*n; i < row*n+n; i++)
            {
                if (btns[i].Enabled && btns[i].Visible)
                {
                    int num = System.Convert.ToInt32(btns[i].Text);
                    if (maxNum < num)
                    {
                        maxNum = num;
                        newPos = i;
                    }
                }
            }
            for (int i = column; i < n*n; i+= n)
            {
                if (btns[i].Enabled && btns[i].Visible)
                {
                    int num = System.Convert.ToInt32(btns[i].Text);
                    if (maxNum < num)
                    {
                        maxNum = num;
                        newPos = i;
                    }
                }
            }
            playerScore += System.Convert.ToInt32(btns[newPos].Text);
            playersTurn = !playersTurn;
            //lblPlayerScore.Text = "Player's Score: " + playerScore.ToString();
            disableRowsColumns();
            currentPos = newPos;
            btns[currentPos].Visible = false;
            
            enableRowsColumns();
            //lblChose.Visible = true;
            //lblChose.Text = "Player Chose: " + btns[newPos].Text + " at " + newPos.ToString() + "\n Diff: " + maxNum.ToString();
        }




        /*Runs the computer's AI
         Easy - Comp Looks for Max Number
         Hard - Comp Looks ahead one turn and
         finds biggest difference between comp and player's next pick*/
/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: compAI()								*
* Description: Runs the comp's AI, depending on game settings   *
* Preconditions: None											*
* Postconditions: Allows user to select it's next move          *
****************************************************************/
        public int compAI()
        {
            int maxNum = 0, score = 0;
            if (!playersTurn)
            {
                //Calculate Row/Column
                int newPos = 0;
                int row = currentPos / n;
                int column = currentPos % n;
                maxNum = -100;//Small Value
                //for (int i = 0; i < n * n; i++)
                //Check Row
                for (int i = row * n; i < row * n + n; i++ )
                {
                    if (btns[i].Enabled && btns[i].Visible)
                    {
                        int num = System.Convert.ToInt32(btns[i].Text);
                        //Note: if difficulty != 0, then num = biggest difference
                        if (difficulty != 0)//Look Ahead One Move
                        { num = possibleSelection(i); }

                        if (maxNum < num)
                        {
                            maxNum = num;
                            newPos = i;
                        }
                    }
                }
                for (int i = column; i < n*n; i+=n)
                {
                    if (btns[i].Enabled && btns[i].Visible)
                    {
                        int num = System.Convert.ToInt32(btns[i].Text);
                        if (difficulty != 0)//Look Ahead One Move
                        { num = possibleSelection(i); }
                        if (maxNum < num)
                        {
                            maxNum = num;
                            newPos = i;
                        }
                    }
                }
                score = System.Convert.ToInt32(btns[newPos].Text);
                compScore += score;
                //Toggle Turns
                playersTurn = !playersTurn;
                
                //disableRowsColumns();//Gave Me some bugs
                //use disableBtns(), Slower but reliable
                disableBtns();
                currentPos = newPos;
                btns[currentPos].Visible = false;
                
                enableRowsColumns();
                
            }
            return score;
        }

        
        /*Check each button if none are visible or enabled then game is over*/
/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: checkGameOver()								*
* Description: Checks any buttons left, indicating game over    *
* Preconditions: None											*
* Postconditions: Tell the user when the game is over           *
****************************************************************/
        public string checkGameOver(bool show)
        {
            int count = 0;
            string str = "";
            //Slow Algorithm Too much time on large board
            //Use this because I have testing code for it already
            foreach (Button btn in btns)
            {
                if (btn.Visible && btn.Enabled) { count++; }
            }
            int row = currentPos / n;
            int column = currentPos % n;

            //Fast Algorithm - Check only the next possible selections
            /*for (int i = row * n; i < row * n + n; i++)
            {
                if (btns[i].Visible && btns[i].Enabled) { count++; }
            }
            for (int i = column; i < n * n; i+=n)
            {
                if(btns[i].Visible && btns[i].Enabled){count++;}
            }*/
            //Note: there may still be selections on the board, just not in the current row/column
                if (count == 0)
                {
                    //string str = "";
                    if (playerScore > compScore)
                    { str = "Player Wins!!!\n"; }
                    else { str = "Computer Wins!!!\n"; }
                    if (show) { MessageBox.Show("Game Over...\n" + str + "\nPlayer Score: "+playerScore.ToString()+"\nComputer Score: "+compScore.ToString()+"\n"); }
                }
            //return string for testing purposes
            return str;
        }

        /*Take a possible selection position (pos),
        Check each element in row and column of pos
        Find minimal difference between pos' value and player's next pick*/
/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: possibleSelection()							*
* Description: Checks the possible outcomes of selection (pos)  *
* Preconditions: None											*
* Postconditions: Allows CompAI to run on Hard                  *
****************************************************************/
        public int possibleSelection(int pos)
        {
            //Calculate Row/Column 
            int row = pos / n;
            int column = pos % n;
            int mindiff = 100;//assign large value
            //Value of computer's possible pick
            int compPick = System.Convert.ToInt32(btns[pos].Text);
         
            //Look ahead one move at player's next turn
            //iterate row
            for (int i = row * n; i < row * n + n; i++)
            {
                if (btns[i].Visible)//Visible = Not Selected Yet
                {
                    mindiff = Math.Min(mindiff, compPick - System.Convert.ToInt32(btns[i].Text));
                }
            }
            //iterate column
            for (int i = column; i < n * n; i += n)
            {
                if (btns[i].Visible)
                {
                    mindiff = Math.Min(mindiff, compPick - System.Convert.ToInt32(btns[i].Text));
                }
            }
            return mindiff;
        }

 

       /*Generate random numbers for each button*/

/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: randomNums()								    *
* Description: Generate random nums for button array            *
* Preconditions: None											*
* Postconditions: Game board is set randomly                    *
****************************************************************/
        public void randomNums()
        {
            if (btns != null)
            {
                Random rand = new Random();
                foreach (Button b in btns)
                {
                    int num = rand.Next(-9, 16);
                    b.Text = num.ToString();
                    b.BackColor = Color.Silver;
                    b.FlatStyle = FlatStyle.Popup;
                    if (num >= 0)
                    { b.ForeColor = Color.ForestGreen; }
                    else { b.ForeColor = Color.Crimson; }
                }
            }
        }
        /*Randomly Select the Initial Position*/
/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 6, 2013								        *
* Function Name: selectInitialPos()								*
* Description: Selects the Initial Position at game start       *
* Preconditions: None											*
* Postconditions: Starting position is random                   *
****************************************************************/
        public void selectInitialPos()
        {
            Random rand = new Random();
            int initial = rand.Next(0, n*n);
            btns[initial].FlatStyle = FlatStyle.Flat;
            btns[initial].Focus();
            currentPos = initial;
        }

    }
}
