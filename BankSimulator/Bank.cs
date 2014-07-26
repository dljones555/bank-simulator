using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTellerSimulator
{
    public class Bank
    {
        private Vault _vault;
        private ManualResetEvent _workReadyEvent;

        private int _numCustomers;
        private int _numTellers;

        private decimal _goalAmt;
        private decimal _maxTransAmt;
        private decimal _initialCustAmt;

        private BankQueue _bankQueue;
        private List<Teller> _tellers = new List<Teller>();
        private List<Customer> _customers = new List<Customer>();
        private ListBoxHelper _listBoxHelper;

        private ManualResetEvent _workQuitEvent;
        private BankSimulator _bankSim;

        public Bank(BankSimulator bankSim, ListBoxHelper listBoxHelper, ManualResetEvent workQuitEvent, decimal bankAmt, int numCustomers, int numTellers, decimal goalAmt, decimal maxTransAmt, decimal initialCustAmt)
        {
            _bankSim = bankSim;
            _numCustomers = numCustomers;
            _numTellers = numTellers;

            _goalAmt = goalAmt;
            _maxTransAmt = maxTransAmt;
            _initialCustAmt = initialCustAmt;

            _workQuitEvent = workQuitEvent;
            _listBoxHelper = listBoxHelper;
            _workReadyEvent = new ManualResetEvent(false);
            _workReadyEvent.Reset(); 

            _bankQueue = new BankQueue(_workReadyEvent);

            CreateTellerList(_numTellers);
            CreateCustomerList(_numCustomers);

            _vault = new Vault(_workReadyEvent, this);
            _vault.Balance = bankAmt;        
        }

        public void Join()
        {
            foreach (Teller t in Tellers)
            {
                t.Join();
            }
        }

        private void CreateCustomerList(int numCustomers)
        {
            RandomNameGenerator rng = new RandomNameGenerator(numCustomers);

            List<string> custNames = rng.RandomNameList;

            for (int i=0; i< custNames.Count; i++)
            {
                _customers.Add( new Customer(i, custNames[i], _initialCustAmt) );
            }
        }

        private void CreateTellerList(int numTellers)
        {
            RandomNameGenerator rng = new RandomNameGenerator(numTellers);
            List<string> tellerNames = rng.RandomNameList;

            for (int i=0; i < tellerNames.Count; i++)
            {
                Teller tellerWorker = new Teller(i, tellerNames[i], _listBoxHelper, _workQuitEvent, _workReadyEvent, this);
                _tellers.Add(tellerWorker);
            }
        }

        #region Public Properties
        public decimal InitialCustAmt
        {
            get { return _initialCustAmt; }
            set { _initialCustAmt = value; }
        }

        public decimal GoalAmt
        {
            get { return _goalAmt; }
            set { _goalAmt = value; }
        }

        public decimal MaxTransAmt
        {
            get { return _maxTransAmt; }
            set { _maxTransAmt = value; }
        }

        public BankQueue BankQueue
        {
            get { return _bankQueue; }
            set { _bankQueue = value; }
        }

        public List<Teller> Tellers
        {
            get { return _tellers; }
            set { _tellers = value; }
        }

        public List<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value; }
        }

        public BankSimulator BankSimulator
        {
            get { return _bankSim; }
            set { _bankSim = value; }
        }

        public Vault Vault
        {
            get { return _vault; }
        }
        #endregion 
    }
}
