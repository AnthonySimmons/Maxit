namespace Maxit
{
    partial class MaxitForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnter = new System.Windows.Forms.Button();
            this.tbxSize = new System.Windows.Forms.TextBox();
            this.lblPlayerScore = new System.Windows.Forms.Label();
            this.lblCompScore = new System.Windows.Forms.Label();
            this.lblChose = new System.Windows.Forms.Label();
            this.rdobtnEasy = new System.Windows.Forms.RadioButton();
            this.rdobtnHard = new System.Windows.Forms.RadioButton();
            this.cbxSim = new System.Windows.Forms.CheckBox();
            this.btnTests = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(133, 35);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 23);
            this.btnEnter.TabIndex = 0;
            this.btnEnter.Text = "Create Grid";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.UseWaitCursor = true;
            this.btnEnter.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbxSize
            // 
            this.tbxSize.Location = new System.Drawing.Point(182, 10);
            this.tbxSize.Name = "tbxSize";
            this.tbxSize.Size = new System.Drawing.Size(26, 20);
            this.tbxSize.TabIndex = 1;
            // 
            // lblPlayerScore
            // 
            this.lblPlayerScore.AutoSize = true;
            this.lblPlayerScore.Location = new System.Drawing.Point(12, 12);
            this.lblPlayerScore.Name = "lblPlayerScore";
            this.lblPlayerScore.Size = new System.Drawing.Size(89, 13);
            this.lblPlayerScore.TabIndex = 2;
            this.lblPlayerScore.Text = "Player\'s Score:  0";
            // 
            // lblCompScore
            // 
            this.lblCompScore.AutoSize = true;
            this.lblCompScore.Location = new System.Drawing.Point(12, 35);
            this.lblCompScore.Name = "lblCompScore";
            this.lblCompScore.Size = new System.Drawing.Size(105, 13);
            this.lblCompScore.TabIndex = 3;
            this.lblCompScore.Text = "Computer\'s Score:  0";
            // 
            // lblChose
            // 
            this.lblChose.AutoSize = true;
            this.lblChose.Location = new System.Drawing.Point(12, 60);
            this.lblChose.Name = "lblChose";
            this.lblChose.Size = new System.Drawing.Size(75, 13);
            this.lblChose.TabIndex = 4;
            this.lblChose.Text = "Player Chose: ";
            // 
            // rdobtnEasy
            // 
            this.rdobtnEasy.AutoSize = true;
            this.rdobtnEasy.Checked = true;
            this.rdobtnEasy.Location = new System.Drawing.Point(230, 11);
            this.rdobtnEasy.Name = "rdobtnEasy";
            this.rdobtnEasy.Size = new System.Drawing.Size(48, 17);
            this.rdobtnEasy.TabIndex = 5;
            this.rdobtnEasy.TabStop = true;
            this.rdobtnEasy.Text = "Easy";
            this.rdobtnEasy.UseVisualStyleBackColor = true;
            // 
            // rdobtnHard
            // 
            this.rdobtnHard.AutoSize = true;
            this.rdobtnHard.Location = new System.Drawing.Point(230, 34);
            this.rdobtnHard.Name = "rdobtnHard";
            this.rdobtnHard.Size = new System.Drawing.Size(48, 17);
            this.rdobtnHard.TabIndex = 6;
            this.rdobtnHard.Text = "Hard";
            this.rdobtnHard.UseVisualStyleBackColor = true;
            // 
            // cbxSim
            // 
            this.cbxSim.AutoSize = true;
            this.cbxSim.Location = new System.Drawing.Point(301, 11);
            this.cbxSim.Name = "cbxSim";
            this.cbxSim.Size = new System.Drawing.Size(97, 17);
            this.cbxSim.TabIndex = 7;
            this.cbxSim.Text = "Run Simulation";
            this.cbxSim.UseVisualStyleBackColor = true;
            // 
            // btnTests
            // 
            this.btnTests.Location = new System.Drawing.Point(301, 35);
            this.btnTests.Name = "btnTests";
            this.btnTests.Size = new System.Drawing.Size(75, 23);
            this.btnTests.TabIndex = 8;
            this.btnTests.Text = "Run Tests";
            this.btnTests.UseVisualStyleBackColor = true;
            this.btnTests.Click += new System.EventHandler(this.btnTests_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(146, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Size:";
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(404, 8);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(75, 23);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // MaxitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 388);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTests);
            this.Controls.Add(this.cbxSim);
            this.Controls.Add(this.rdobtnHard);
            this.Controls.Add(this.rdobtnEasy);
            this.Controls.Add(this.lblChose);
            this.Controls.Add(this.lblCompScore);
            this.Controls.Add(this.lblPlayerScore);
            this.Controls.Add(this.tbxSize);
            this.Controls.Add(this.btnEnter);
            this.Name = "MaxitForm";
            this.Text = "Maxit Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnter;
        public System.Windows.Forms.TextBox tbxSize;
        private System.Windows.Forms.Label lblPlayerScore;
        private System.Windows.Forms.Label lblCompScore;
        private System.Windows.Forms.Label lblChose;
        public System.Windows.Forms.RadioButton rdobtnEasy;
        public System.Windows.Forms.RadioButton rdobtnHard;
        public System.Windows.Forms.CheckBox cbxSim;
        private System.Windows.Forms.Button btnTests;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAbout;
    }
}

