using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    [Serializable]
    public class GoCoinUser
    {
        public string id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string merchant_id { get; set; }
        public string current_password { get; set; }
        public string password { get; set; }
        public string password_confirmation { get; set; }
    }
}