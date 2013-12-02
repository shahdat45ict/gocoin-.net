using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    [Serializable]
    public class GoCoinMerchant
    {
        public string id { get; set; }
        public string name { get; set; }
        public string address_1 { get; set; }
        public string address_2 { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string country_code { get; set; }
        public string postal_code { get; set; }
        public string contact_name { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public string description { get; set; }
        public string tax_id { get; set; }
        public string logo_url { get; set; }
        public string btc_payout_split { get; set; }
        public string usd_payout_split { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }
}