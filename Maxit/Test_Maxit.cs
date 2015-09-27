/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 7, 2013					            		*
* Description: Maxit Testing Class that provides complete branch*
*       coverage for all essential functions of Maxit Game      * 
****************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Maxit
{
    public class Test_Maxit
    {
        public MaxitForm testForm = new MaxitForm();
        string result = "";
        Form form = new Form();
        string[] testNames = {"CompAI_1", "CompAI_2", "CompAI_3", "GameOver_1", "GameOver_2", "GameOver_3", "PossibleSelection_1", 
                             "ButtonClick_1", "ButtonClick_2", "ButtonClick_3", "StartGame_1", "StartGame_2", "StartGame_3",
                             "StartGame_4", "RandomNums_1", "RandomNums_2", "InitButtons_1"};
        RadioButton[] rdoBtns = new RadioButton[18];

        public Test_Maxit()
        {
            testForm = new MaxitForm();
            initForm();
        }

/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit Game  				*
* Course: CptS 422 - Software Testing							*
* Date: September 9, 2013			            				*
* Function Name: initForm()									    *
* Description: Initializes Testing Form, adds controls          *
* Preconditions: None											*
* Postconditions: None			        						*
****************************************************************/
        void initForm()
        {
            form = new Form();
            form.Height = 500;
            form.Width = 300;
            form.BackColor = Color.CornflowerBlue;
            form.Text = "Maxit Testing";

            
            for (int i = 0; i < rdoBtns.Length; i++)
            {
                rdoBtns[i] = new RadioButton();
                rdoBtns[i].Width = 120;
                rdoBtns[i].Location = new Point(50, 20 * i + 30);
                if (i < rdoBtns.Length - 1)
                {
                    rdoBtns[i].Text = testNames[i];
                }
                else
                { rdoBtns[i].Text = "Run All Tests"; }
                form.Controls.Add(rdoBtns[i]);
            }
            Button btn = new Button();
            btn.Location = new Point(200, 100);
            btn.Click += new EventHandler(btn_Click);
            btn.Text = "Run Test";
            form.Controls.Add(btn);

            form.Show();
        }



        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit Game  				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013			            				*
        * Function Name: findSelectedTest()							    *
        * Description: Finds the selected test and returns its index    *
        * Preconditions: Form is initialized							*
        * Postconditions: selected Test can be executed 				*
        ****************************************************************/
        int findSelectedTest()
        {
            for (int i = 0; i < rdoBtns.Length; i++)
            {
                if (rdoBtns[i].Checked)
                {
                    return i;
                }
            }
            return -1;
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit Game  				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013			            				*
        * Function Name: runSelectedTest()							    *
        * Description: Runs the selected test by the given index        *
        * Preconditions: None											*
        * Postconditions: User can see the selected test run			*
        ****************************************************************/
        void runSelectedTest(int selectedTest)
        {
            bool passed = false;
            switch (selectedTest)
            {
                case 0: passed = testCompAI_1();
                    break;
                case 1: passed = testCompAI_2();
                    break;
                case 2: passed = testCompAI_3();
                    break;
                case 3: passed = testGameOver_1();
                    break;
                case 4: passed = testGameOver_2();
                    break;
                case 5: passed = testGameOver_3();
                    break;
                case 6: passed = testPossibleSelection_1();
                    break;
                case 7: passed = testBtnClick_1();
                    break;
                case 8: passed = testBtnClick_2();
                    break;
                case 9: passed = testBtnClick_3();
                    break;
                case 10: passed = testStartGame_1();
                    break;
                case 11: passed = testStartGame_2();
                    break;
                case 12: passed = testStartGame_3();
                    break;
                case 13: passed = testStartGame_4();
                    break;
                case 14: passed = testRandomNums_1();
                    break;
                case 15: passed = testRandomNums_2();
                    break;
                case 16: passed = testInitBtns_1();
                    break;
                case 17: runAllTests();
                    break;
            }
            if (selectedTest < 17)
            {
                MessageBox.Show("Test: " + testNames[selectedTest] + " Passed = " + passed.ToString());
            }
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit Game  				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013			            				*
        * Function Name: btn_click()									*
        * Description: Handler that finds and runs the selected test    *
        * Preconditions: None											*
        * Postconditions: Test can be run        						*
        ****************************************************************/
        void btn_Click(object sender, EventArgs e)
        {
            int test = findSelectedTest();
            if (test >= 0)
            {
                runSelectedTest(test);
            }
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit Game  				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013			            				*
        * Function Name: runAllTests()									*
        * Description: Runs All Tests                                   *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        void runAllTests()
        {
            for (int i = 0; i < 17; i++)
            {
                runSelectedTest(i);
            }
        }

/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 9, 2013								        *
* Function Name: testCompAI_1()									*
* Description: Executes Test Case for 1.1                       *
* Preconditions: None											*
* Postconditions: None			        						*
****************************************************************/
        bool testCompAI_1()
        {
            //1
            testForm = new MaxitForm();
            testForm.game.playersTurn = true;
            testForm.game.compAI();
            
            return true;
        }
        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testCompAI_2()									*
        * Description: Executes Test Case for 1.2                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testCompAI_2()
        {
            //2
            testForm = new MaxitForm();
            testForm.game.playersTurn = false;
           
            testForm.game.n = 3;
            testForm.initBtns(testForm.game.n);
            

            testForm.game.btns[0].Text = "1";
            testForm.game.btns[1].Text = "9";
            testForm.game.btns[2].Text = "4";
            testForm.game.btns[3].Text = "1";
            testForm.game.btns[4].Text = "7";
            testForm.game.btns[5].Text = "6";
            testForm.game.btns[6].Text = "-2";
            testForm.game.btns[7].Text = "12";
            testForm.game.btns[8].Text = "-3";

            
            testForm.game.currentPos = 3;
            testForm.game.enableRowsColumns();
            testForm.Show();
            
            bool passed = (testForm.game.compAI() == 7);
            result += "CompAI_2() - "+ "Passed = " +passed.ToString() + "\n";
            
            return passed;
        }

        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testCompAI_3()									*
        * Description: Executes Test Case for 1.3                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testCompAI_3()
        {
            //3
            testForm = new MaxitForm();
            testForm.game.playersTurn = false;

            testForm.game.n = 3;
            testForm.initBtns(testForm.game.n);


            testForm.game.btns[0].Text = "1";
            testForm.game.btns[1].Text = "9";
            testForm.game.btns[2].Text = "4";
            testForm.game.btns[3].Text = "1";
            testForm.game.btns[4].Text = "7";
            testForm.game.btns[5].Text = "6";
            testForm.game.btns[6].Text = "-2";
            testForm.game.btns[7].Text = "12";
            testForm.game.btns[8].Text = "-3";

            testForm.game.difficulty = 1;
            testForm.game.currentPos = 3;
            testForm.game.enableRowsColumns();
            testForm.Show();

            bool passed = (testForm.game.compAI() == 6);
            result += "CompAI_3() - " + "Passed = " +passed.ToString() + "\n";
            
            return passed;
        }

        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testGameOver_1()									*
        * Description: Executes Test Case for 2.1                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testGameOver_1()
        {
            //Player should win
            testForm = new MaxitForm();
            testForm.game.n = 3;
            testForm.initBtns(3);
            foreach (Button btn in testForm.game.btns)
            { btn.Visible = false; btn.Enabled = false; }
            testForm.game.playerScore = 100;
            testForm.game.compScore = 50;
            string str = "";
            testForm.Show();
            str = testForm.game.checkGameOver(false);
            bool pass = (str == "Player Wins!!!\n");
            result += "GameOver_1() - " + "Passed = " +pass.ToString() + "\n";
            
            return pass;
        }

        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testGameOver_2()   							*
        * Description: Executes Test Case for 2.2                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testGameOver_2()
        {
            //Comp should win
            testForm = new MaxitForm();
            testForm.game.n = 3;
            testForm.initBtns(3);
            foreach (Button btn in testForm.game.btns)
            { btn.Visible = false; btn.Enabled = false; }
            testForm.game.playerScore = 50;
            testForm.game.compScore = 100;
            string str = "";
            testForm.Show();
            str = testForm.game.checkGameOver(false);
            bool pass = (str == "Computer Wins!!!\n");
            result += "GameOver_2() - " + "Passed = " +pass.ToString() + "\n";
            
            return pass;
        }

/****************************************************************
* Author: Anthony Simmons                                       *
* Assignment: Homework #1 - Testing Maxit		 				*
* Course: CptS 422 - Software Testing							*
* Date: September 9, 2013								        *
* Function Name: testGameOver_3()							    *
* Description: Execute test cases for 2.3                       *
* Preconditions: None											*
* Postconditions: None			        						*
****************************************************************/
        bool testGameOver_3()
        {
            //Game Not Over
            testForm = new MaxitForm();
            testForm.game.n = 3;
            testForm.initBtns(3);
            testForm.game.btns[1].Visible = true;
            testForm.game.btns[1].Enabled = true;
            testForm.game.btns[3].Visible = true;
            testForm.game.btns[3].Enabled = true;
            string str = "";
            testForm.Show();
            str = testForm.game.checkGameOver(false);
            bool pass = (str == "");
            result += "GameOver_3() - " + "Passed = " +pass.ToString() + "\n";
            
            return pass;
        }

        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testPossibleSelection_1()					    *
        * Description: Execute test cases for 3.1                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testPossibleSelection_1()
        {
            testForm = new MaxitForm();

            testForm.game.n = 3;
            testForm.initBtns(testForm.game.n);

            testForm.game.btns[3].Visible = false;
            testForm.game.btns[8].Visible = false;

            testForm.game.btns[0].Text = "1";
            testForm.game.btns[1].Text = "9";
            testForm.game.btns[2].Text = "4";
            testForm.game.btns[3].Text = "1";
            testForm.game.btns[4].Text = "7";
            testForm.game.btns[5].Text = "6";
            testForm.game.btns[6].Text = "-2";
            testForm.game.btns[7].Text = "12";
            testForm.game.btns[8].Text = "-3";

            testForm.game.currentPos = 3;
            testForm.game.enableRowsColumns();
            testForm.Show();


            int mindiff = testForm.game.possibleSelection(5);
            bool pass = (mindiff == -1);
            result += "PossibleSelection_1() - "+pass.ToString() + "\n";
            
            return pass;
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testBtnClick_1()							    *
        * Description: Execute test cases for 4.1                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testBtnClick_1()
        {
            testForm = new MaxitForm();
            testForm.game.n = 3;
            testForm.game.playersTurn = true;
            testForm.initBtns(testForm.game.n);
            testForm.game.randomNums();
            testForm.game.selectInitialPos();
            testForm.game.enableRowsColumns();
            testForm.Show();
            
            testForm.handleBtnClick(testForm.game.btns[2]);
            bool pass = (!testForm.game.btns[2].Visible && 2 != testForm.game.currentPos);
            result += "BtnClick_1() - " + "Passed = " +pass.ToString() + "\n";
            
            return pass;
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testBtnClick_2()							        *
        * Description: Execute test cases for 4.2                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testBtnClick_2()
        {
            testForm = new MaxitForm();
            testForm.game.n = 3;
            testForm.game.playersTurn = false;
            testForm.initBtns(testForm.game.n);
            testForm.game.randomNums();
            testForm.game.selectInitialPos();
            testForm.game.enableRowsColumns();
            testForm.Show();
            int cpos = testForm.game.currentPos;
            testForm.handleBtnClick(testForm.game.btns[2]);
            bool pass = (testForm.game.btns[2].Visible && cpos == testForm.game.currentPos);
            result += "BtnClick_2() - " + "Passed = " +pass.ToString() + "\n";
            
            return pass;
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testBtnClick_3()							    *
        * Description: Execute test cases for 4.3                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testBtnClick_3()
        {
            testForm = new MaxitForm();
            testForm.game.n = 10;
            testForm.game.playersTurn = true;
            testForm.initBtns(testForm.game.n);
            testForm.cbxSim.Checked = true;
            testForm.game.randomNums();
            testForm.game.selectInitialPos();
            testForm.game.enableRowsColumns();
            testForm.Show();
            int cpos = testForm.game.currentPos;
            testForm.handleBtnClick(testForm.game.btns[2]);
            bool pass = (testForm.game.checkGameOver(false) != "");
            result += "BtnClick_3() - " + "Passed = " +pass.ToString() + "\n";
            
            return pass;
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testStartGame_1()							    *
        * Description: Execute test cases for 5.1                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testStartGame_1()
        {
            testForm = new MaxitForm();
            testForm.tbxSize.Text = "";
            testForm.startGame();
            bool pass = (testForm.game.n == 3);
            
            result += "StartGame_1() - " + "Passed = " +pass.ToString() + "\n";
            return pass;
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testStartGame_2()							    *
        * Description: Execute test cases for 5.2                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testStartGame_2()
        {
            testForm = new MaxitForm();
            testForm.tbxSize.Text = "8";
            testForm.rdobtnHard.Checked = true;
            testForm.startGame();
            bool pass = (testForm.game.n == 8 && testForm.game.difficulty == 1);
            
            result += "StartGame_2() - " + "Passed = " +pass.ToString() + "\n";
            return pass;
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testStartGame_3()							    *
        * Description: Execute test cases for 5.3                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testStartGame_3()
        {
            testForm = new MaxitForm();
            testForm.tbxSize.Text = "8";
            testForm.rdobtnEasy.Checked = true;
            testForm.startGame();
            bool pass = (testForm.game.n == 8 && testForm.game.difficulty == 0);
            
            result += "StartGame_3() - " + "Passed = " +pass.ToString() + "\n";
            return pass;
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testStartGame_4()							    *
        * Description: Execute test cases for 5.4                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testStartGame_4()
        {
            testForm = new MaxitForm();
            testForm.tbxSize.Text = "-8";
            testForm.rdobtnEasy.Checked = true;
            testForm.startGame();
            bool pass = (testForm.game.n == 8);
            
            result += "StartGame_4() - " + "Passed = " +pass.ToString() + "\n";
            return pass;
        }


        /****************************************************************
     * Author: Anthony Simmons                                       *
     * Assignment: Homework #1 - Testing Maxit		 				*
     * Course: CptS 422 - Software Testing							*
     * Date: September 9, 2013								        *
     * Function Name: testRandomNums_1()						    *
     * Description: Execute test cases for 6.1                       *
     * Preconditions: None											*
     * Postconditions: None			        						*
     ****************************************************************/
        bool testRandomNums_1()
        {
            testForm = new MaxitForm();
            testForm.game.btns = null;
            bool pass = false;
            testForm.game.randomNums();
            pass = true;
            result += "RandomNums_1() - " + "Passed = " + pass.ToString() + "\n";

            return pass;
        }


        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testRandomNums_2()							    *
        * Description: Execute test cases for 6.2                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testRandomNums_2()
        {
            testForm = new MaxitForm();
            testForm.initBtns(20);
            bool pass = true;
            testForm.game.randomNums();
            foreach (Button btn in testForm.game.btns)
            {
                if (Convert.ToInt32(btn.Text) >= 0 && btn.ForeColor != Color.ForestGreen)
                {
                    pass = false;
                }
                if (Convert.ToInt32(btn.Text) < 0 && btn.ForeColor != Color.Crimson)
                {
                    pass = false;
                }
            }

            result += "RandomNums_2() - " + "Passed = " + pass.ToString() + "\n";

            return pass;
        }

        /****************************************************************
        * Author: Anthony Simmons                                       *
        * Assignment: Homework #1 - Testing Maxit		 				*
        * Course: CptS 422 - Software Testing							*
        * Date: September 9, 2013								        *
        * Function Name: testInitBtns_1()							    *
        * Description: Execute test cases for 7.1                       *
        * Preconditions: None											*
        * Postconditions: None			        						*
        ****************************************************************/
        bool testInitBtns_1()
        {
            testForm = new MaxitForm();
            testForm.initBtns(5);
            bool pass = (testForm.game.n == 5 && testForm.game.btns[24] != null);

            result += "InitBtns_1() - " + "Passed = " +pass.ToString() + "\n";
            
            return pass;
        }


     

    }
}
