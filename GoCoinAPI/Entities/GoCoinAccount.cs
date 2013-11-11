using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    [Serializable]
    public class GoCoinAccount
    {
        public string id { get; set; }
        public string currency_code { get; set; }
        public float balance { get; set; }
    }
}