using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerSimulator
{
    public class Transaction
    {
        private Customer _customer;
        private TransactionType _transactionType; 
        private decimal _transactionAmt;

        public Transaction(Customer customer, TransactionType transactionType, decimal transactionAmt)
        {
            _customer = customer;
            _transactionType = transactionType;
            _transactionAmt = transactionAmt;
        }

        #region Public Properties
        public Customer Customer
        {
            get { return _customer; }
            set { _customer = value; }
        }

        public TransactionType TransactionType
        {
            get { return _transactionType; }
            set { _transactionType = value; }
        }

        public decimal TransactionAmt
        {
            get { return _transactionAmt; }
            set { _transactionAmt = value; }
        }
        #endregion
    }
}
