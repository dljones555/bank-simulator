using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTellerSimulator
{
    public class BankQueue
    {
        private Queue<Transaction> m_queue;
        private ManualResetEvent workReadyEvent;

        public BankQueue(ManualResetEvent workReadyEvent)
        {
            this.workReadyEvent = workReadyEvent;
            m_queue = new Queue<Transaction>();
        }

        public void Enqueue(Transaction transaction)
        {
            lock (m_queue)
            {
                m_queue.Enqueue(transaction);
                workReadyEvent.Set();
            }
        }

        public Transaction Dequeue()
        {
            lock (m_queue)
            {
                if (m_queue.Count > 0)
                {
                    return m_queue.Dequeue();
                }
                else
                {
                    workReadyEvent.Reset();
                    return null;
                }
            }
        }

        public void Clear()
        {
            lock (m_queue)
            {
                m_queue.Clear();
            }
        }
    }
}
