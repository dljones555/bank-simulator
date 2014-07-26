using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows;

namespace BankTellerSimulator
{
    public class TransactionGenerator
    {
        private ListBoxHelper listBoxHelper;
        private ManualResetEvent quitEvent;
        private Bank _bank;

        private Thread thread;

        public TransactionGenerator(ListBoxHelper listBoxHelper, ManualResetEvent quitEvent, Bank bank)
        {
            this.listBoxHelper = listBoxHelper;
            this.quitEvent = quitEvent;
            this._bank = bank;

            thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();
        }

        private void ThreadProc()
        {
            // Create a random transaction

            Random r  = new Random();

            Customer randomCust = null; 
          
            try
            {
                while (true)
                {
                    decimal randomTransAmt = Convert.ToDecimal(r.Next(1, Convert.ToInt32(_bank.MaxTransAmt)));
                    int rndTransType = r.Next(2);

                    TransactionType randomTransType = (TransactionType)rndTransType; 

                    // Acquire next available customer
                    int i = r.Next(1, _bank.Customers.Count);
                    randomCust = _bank.Customers[i];

                    while (randomCust.IsAvailable == false)
                    {
                        Thread.Sleep(1);
                        randomCust = _bank.Customers[r.Next(1, _bank.Customers.Count)];
                    }

                    Transaction transaction = new Transaction(randomCust, randomTransType, randomTransAmt);

                    _bank.BankQueue.Enqueue(transaction);
                    if (quitEvent.WaitOne(50, true) == true)
                    {
                        listBoxHelper.AddString("Master: ThreadProc requested to stop.");
                        break;
                    }
                }
            }
            catch (ThreadInterruptedException tie)
            {
                listBoxHelper.AddString("Thread Interrupted Exception: \n" + tie.Message);
            }
            catch (ThreadAbortException tae)
            {
                listBoxHelper.AddString("Thread Abort Exception: \n" + tae.Message);
            }
        }

        public void Join()
        {
            thread.Join(500);
        }
    }
}
