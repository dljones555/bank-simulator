namespace BankTellerSimulator
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBankAmount = new System.Windows.Forms.TextBox();
            this.txtNumTellers = new System.Windows.Forms.TextBox();
            this.txtMaxTransAmt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumCustomers = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGoalAmt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInitialAmt = new System.Windows.Forms.TextBox();
            this.lblTransDisplay = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bank Amount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of Tellers:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Maximum Transaction Amount:";
            // 
            // txtBankAmount
            // 
            this.txtBankAmount.Location = new System.Drawing.Point(197, 35);
            this.txtBankAmount.Name = "txtBankAmount";
            this.txtBankAmount.Size = new System.Drawing.Size(100, 20);
            this.txtBankAmount.TabIndex = 3;
            // 
            // txtNumTellers
            // 
            this.txtNumTellers.Location = new System.Drawing.Point(197, 68);
            this.txtNumTellers.Name = "txtNumTellers";
            this.txtNumTellers.Size = new System.Drawing.Size(100, 20);
            this.txtNumTellers.TabIndex = 4;
            // 
            // txtMaxTransAmt
            // 
            this.txtMaxTransAmt.Location = new System.Drawing.Point(197, 99);
            this.txtMaxTransAmt.Name = "txtMaxTransAmt";
            this.txtMaxTransAmt.Size = new System.Drawing.Size(100, 20);
            this.txtMaxTransAmt.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(340, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Number of Customers:";
            // 
            // txtNumCustomers
            // 
            this.txtNumCustomers.Location = new System.Drawing.Point(471, 38);
            this.txtNumCustomers.Name = "txtNumCustomers";
            this.txtNumCustomers.Size = new System.Drawing.Size(100, 20);
            this.txtNumCustomers.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Goal Amount:";
            // 
            // txtGoalAmt
            // 
            this.txtGoalAmt.Location = new System.Drawing.Point(471, 67);
            this.txtGoalAmt.Name = "txtGoalAmt";
            this.txtGoalAmt.Size = new System.Drawing.Size(100, 20);
            this.txtGoalAmt.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Initial Amount:";
            // 
            // txtInitialAmt
            // 
            this.txtInitialAmt.Location = new System.Drawing.Point(471, 99);
            this.txtInitialAmt.Name = "txtInitialAmt";
            this.txtInitialAmt.Size = new System.Drawing.Size(100, 20);
            this.txtInitialAmt.TabIndex = 11;
            // 
            // lblTransDisplay
            // 
            this.lblTransDisplay.AutoSize = true;
            this.lblTransDisplay.Location = new System.Drawing.Point(38, 145);
            this.lblTransDisplay.Name = "lblTransDisplay";
            this.lblTransDisplay.Size = new System.Drawing.Size(103, 13);
            this.lblTransDisplay.TabIndex = 12;
            this.lblTransDisplay.Text = "Transaction Display:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(41, 161);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(811, 303);
            this.listBox1.TabIndex = 13;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(312, 481);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 14;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(393, 481);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(475, 481);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 552);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lblTransDisplay);
            this.Controls.Add(this.txtInitialAmt);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtGoalAmt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNumCustomers);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMaxTransAmt);
            this.Controls.Add(this.txtNumTellers);
            this.Controls.Add(this.txtBankAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Bank Teller Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBankAmount;
        private System.Windows.Forms.TextBox txtNumTellers;
        private System.Windows.Forms.TextBox txtMaxTransAmt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumCustomers;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGoalAmt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInitialAmt;
        private System.Windows.Forms.Label lblTransDisplay;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnClear;
    }
}

