using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoConverterMVC.Models
{
    public class Currencies
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string currency { get; set; }
        public Dictionary<string,string> rates { get; set; }
    }

   
}
