using System;
using System.Configuration;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BankTellerSimulator
{
    public partial class Form1 : Form
    {
        private BankSimulator bankSimulator;
        private ListBoxHelper listBoxHelper;

        public Form1()
        {
            InitializeComponent();
            listBoxHelper = new ListBoxHelper(listBox1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBankAmount.Text = ConfigurationManager.AppSettings["InitialVaultAmt"];
            txtGoalAmt.Text = ConfigurationManager.AppSettings["CustomerFinancialGoalAmt"];
            txtInitialAmt.Text = ConfigurationManager.AppSettings["CustomerInitialBalanceAmt"];
            txtMaxTransAmt.Text = ConfigurationManager.AppSettings["MaxCustomerTransactionAmt"];
            txtNumTellers.Text = ConfigurationManager.AppSettings["Tellers"];
            txtNumCustomers.Text = ConfigurationManager.AppSettings["Customers"];
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (bankSimulator == null)
                {
                    bankSimulator = new BankSimulator();
                }
    
                bankSimulator.Initialize(listBoxHelper, Convert.ToDecimal(txtBankAmount.Text), Convert.ToInt32(txtNumCustomers.Text),
                                         Convert.ToInt32(txtNumTellers.Text), Convert.ToDecimal(txtGoalAmt.Text), 
                                         Convert.ToDecimal(txtMaxTransAmt.Text), Convert.ToDecimal(txtInitialAmt.Text) );
                bankSimulator.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured:\n" + ex.Message);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (bankSimulator != null)
            {
                bankSimulator.Stop();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (bankSimulator != null)
            {
                bankSimulator.Stop();
            }
        }
    }
}