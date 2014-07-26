using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTellerSimulator
{
    public class Customer
    {
        private string _name;
        private int _id;

        private decimal _openingBalance;
        private decimal _balance;

        private List<Transaction> _transactionHistory;
        private bool _isAvailable;

        public Customer(int id, string name, decimal balance)
        {
            _id = id;
            _name = name;
            _balance = balance;
            _openingBalance = balance;
            _isAvailable = true;

            _transactionHistory = new List<Transaction>();

            Transaction t = new Transaction(this, TransactionType.Deposit, _openingBalance);
            AddTransaction(t);            
        }

        public bool Withdrawl(Transaction trans)
        {
            AddTransaction(trans);

            if (_balance - trans.TransactionAmt < 0.0M)
            {
                return false;
            }
            else // Withdrawl
            {
                _balance = _balance - trans.TransactionAmt;
                return true;
            }
        }

        public bool Deposit(Transaction trans)
        {
            _balance = _balance + trans.TransactionAmt;
            AddTransaction(trans);
            return true;
        }

        private void AddTransaction(Transaction trans)
        {
            _transactionHistory.Add(trans);
        }

        public List<Transaction> TransactionHistory
        {
            get { return _transactionHistory; }
        }
         
        #region Public Properties
        public decimal Balance
        {
            get { return _balance; }
            set { _balance = value; }
        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }

        #endregion
    }
}
