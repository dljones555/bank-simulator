using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTellerSimulator
{
    public class Vault
    {
        private decimal _balance;    
        private List<Transaction> _transactionHistory;

        public Vault(ManualResetEvent _workReadyEvent, Bank _bank)
        {
            _transactionHistory = new List<Transaction>();
        }

        public decimal Balance
        {
            get 
            { 
                return _balance; 
            }
            set 
            {
                _balance = value;
            }
        }

        public bool Withdrawl(Transaction trans)
        {
            AddTransaction(trans);

            if (_balance - trans.TransactionAmt < 0.0M)
            {
                return false;
            }
            else
            {
                // Withdrawl
                _balance = _balance - trans.TransactionAmt;
            }

            return true;
        }

        public bool Deposit(Transaction trans)
        {
            AddTransaction(trans);
            _balance = _balance + trans.TransactionAmt;
            return true;
        }

        private void AddTransaction(Transaction trans)
        {
            _transactionHistory.Add(trans);
        }
    }
}
