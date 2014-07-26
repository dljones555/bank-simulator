using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTellerSimulator
{
    public class Teller
    {
        private ListBoxHelper _listBoxHelper;
        private ManualResetEvent _quitEvent;
        private ManualResetEvent _workToDoEvent;
        private Bank _bank;

        private string _name;
        private int _ID;

        private Thread thread;

        public Teller(int ID, string name, ListBoxHelper listBoxHelper, ManualResetEvent quitEvent, ManualResetEvent workToDoEvent, Bank bank)
        {
            this._name = name;
            this._ID = ID;
            this._listBoxHelper = listBoxHelper;
            this._quitEvent = quitEvent;
            this._workToDoEvent = workToDoEvent;
            this._bank = bank;

            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();
        }

        private void ThreadProc()
        {
            while (true)
            {
                try
                {
                    int signal = WaitHandle.WaitAny( new WaitHandle[] { this._quitEvent, this._workToDoEvent }, 50, false);

                    if (signal == 0)
                    {
                        _listBoxHelper.AddString(string.Format("Teller Worker: {0} is stopping.", this.ID));
                        break;
                    }
                    else if (signal == 1)
                    {
                        bool continueSimulation;
                        Transaction transaction = _bank.BankQueue.Dequeue();

                        if (transaction != null)
                        {
                            lock (transaction.Customer)
                            {
                                transaction.Customer.IsAvailable = false;
                                continueSimulation = ProcessTransaction(transaction);
                                transaction.Customer.IsAvailable = true;
                            }

                            if (continueSimulation == false)
                            {
                                _quitEvent.Set();
                            }
                        }
                    }
                }
                catch (ThreadInterruptedException tie)
                {
                    _listBoxHelper.AddString("Thread Interrupted Exception: \n" + tie.Message);
                }
                catch (ThreadAbortException tae)
                {
                    _listBoxHelper.AddString("Thread Abort Exception: \n" + tae.Message);
                }
                catch (Exception ex)
                {
                    _listBoxHelper.AddString("Exception: \n" + ex.Message);
                }
            }
        }

        public void Join()
        {
            thread.Join(500);
        }

        private bool ProcessTransaction(Transaction transaction)
        {
            bool continueSimulation = false;
            Customer cust = transaction.Customer;

            if (transaction.TransactionType == TransactionType.Withdrawl)
            {
                lock (_bank.Vault)
                {
                    continueSimulation = _bank.Vault.Withdrawl(transaction);
                }

                if ( continueSimulation == true )
                {
                    cust.Withdrawl(transaction);
                    DisplayTransactionResult(true, transaction);
                }
                else if ( continueSimulation == false ) // Withdrawl failed
                {
                    DisplayTransactionResult(false, transaction);

                    lock (_bank.Vault)
                    {
                        _listBoxHelper.AddString(string.Format("BANK OUT OF FUNDS: Customer: {0}, " +
                                                 "customer balance: {1:c}, bank balance: {2:c}.", cust.Name, cust.Balance, _bank.Vault.Balance));

                    }
                    _listBoxHelper.AddString ( string.Format("Teller Worker [" + this.ID + "] stopping, the last transaction failed.") );
                    
                }        
            }
            else if (transaction.TransactionType == TransactionType.Deposit) 
            {
                lock (_bank.Vault)
                {
                    continueSimulation = _bank.Vault.Deposit(transaction);
                }

                cust.Deposit(transaction);
                DisplayTransactionResult(true, transaction);

                if (cust.Balance >= _bank.GoalAmt)
                {
                    continueSimulation = false;
                    _listBoxHelper.AddString( string.Format( "CUSTOMER GOAL ACHIEVED: {0}, current balance: {1:c}",
                                                            cust.Name, cust.Balance) );

                    // Display transaction history to show how customer arrived at goal
                    List<Transaction> transHistory = cust.TransactionHistory;

                    decimal runningTotal = 0.0M;
                    foreach (Transaction trans in transHistory)
                    {
                        decimal transAmt = trans.TransactionType == TransactionType.Withdrawl ? trans.TransactionAmt * -1 : trans.TransactionAmt;
                        runningTotal += transAmt;
                        string transDesc = string.Format("- Transaction: {0}, transaction amount: {1:c}, running total: {2:c}", trans.TransactionType.ToString(), 
                                           trans.TransactionAmt, runningTotal);
                        _listBoxHelper.AddString(transDesc);
                    }
                }
            }

            return continueSimulation;
        }

        private void DisplayTransactionResult(bool success, Transaction trans)
        {
            string transStatus;

            if (success)
            {
                transStatus = "SUCCEEDED";
            }
            else
            {
                transStatus = "FAILED";
            }
          
            _listBoxHelper.AddString( string.Format( "{0}: {1} (Cust ID: {2}, Teller ID: {7}), {3}, transaction amt: {4:c}, " +
                                     "customer balance: {5:c}, bank balance: {6:c}", 
                                     transStatus, trans.Customer.Name, trans.Customer.ID, trans.TransactionType.ToString(),
                                     trans.TransactionAmt, trans.Customer.Balance, _bank.Vault.Balance, this.ID) );
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}