using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class CurrencyInfo
    {
        public string name { get; set; }
        public string circulating_supply { get; set; }
        public CurrencyPrice quotes { get; set; }
    }
}
