using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BankTellerSimulator
{
    public class BankSimulator
    {
        private decimal _bankAmt;
        private int _numCustomers;
        private int _numTellers;
        private decimal _goalAmt;
        private decimal _maxTransAmt;
        private decimal _initialAmt;

        private ListBoxHelper _listBoxHelper;
        private TransactionGenerator _tg;

        public Bank _bank;
        public ManualResetEvent _workQuitEvent;

        public BankSimulator()
        {

        }

        public void Initialize(ListBoxHelper listBoxHelper, decimal bankAmt, int numCustomers, int numTellers, decimal goalAmt, decimal maxTransAmt, decimal initialAmt) 
        {
            this._bankAmt = bankAmt;
            this._numCustomers = numCustomers;
            this._numTellers = numTellers;
            this._goalAmt = goalAmt;
            this._maxTransAmt = maxTransAmt;
            this._initialAmt = initialAmt;
            this._listBoxHelper = listBoxHelper;

            _workQuitEvent = new ManualResetEvent(false);
        }

        public void Start()
        {
            _workQuitEvent.Reset();

            _bank = new Bank(this, _listBoxHelper, _workQuitEvent, _bankAmt, _numCustomers, _numTellers, _goalAmt, _maxTransAmt, _initialAmt);
            _tg = new TransactionGenerator(_listBoxHelper, _workQuitEvent, _bank);
        }

        public void Stop()
        {
            _workQuitEvent.Set();
            _tg.Join();
            _bank.Join();
        }
    }
}
