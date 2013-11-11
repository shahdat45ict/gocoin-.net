using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    [Serializable]
    public class GoCoinPageInfo
    {
        public int total { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
    }
}