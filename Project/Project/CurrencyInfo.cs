﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class CurrencyInfo
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public string circulating_supply { get; set; }
        public CurrencyPrice quote { get; set; }
    }
}
