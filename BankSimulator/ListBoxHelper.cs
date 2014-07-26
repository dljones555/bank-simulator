using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BankTellerSimulator
{
    public class ListBoxHelper
    {
        private ListBox listBox;
        private delegate void AddListBoxItem(string message);

        public ListBoxHelper(ListBox listBox)
        {
            this.listBox = listBox;
        }

        public void AddString(string message)
        {
            if (listBox.InvokeRequired == true)
            {
                listBox.Invoke(new AddListBoxItem(AddString), new Object[] { message });
            }
            else
            {
                listBox.Items.Add(message);
            }
        }
    }
}
