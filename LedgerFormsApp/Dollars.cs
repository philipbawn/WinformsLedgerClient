using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LedgerFormsApp
{
    public class Dollars
    {
        public decimal Dollar { get; set; }
        public decimal Cent { get; set; }

        public Dollars(long cents)
        {
            this.Dollar = Math.Floor(cents / 100m);
            this.Cent = cents % 100;
        }

        public override string ToString()
        {
            return this.Dollar + "." + this.Cent;
        }
    }
}
