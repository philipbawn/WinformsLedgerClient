using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerFormsApp.ViewModel
{
    public class TransactionLineItemForDisplay
    {
        public string DateEntry { get; set; }
        public Dollars Money { get; set; }
        public string AccountName { get; set; }
        public string Currency { get; set; }
        public string Description { get; set; }
        //public string Amount { get { return this.Money.ToString(); } }
    }
}
