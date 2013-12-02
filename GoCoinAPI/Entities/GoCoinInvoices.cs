using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    [Serializable]
    public class GoCoinInvoices
    {
        public string id { get; set; }
        public string merchant_id { get; set; }
        public string status { get; set; }
        public string payment_address{get; set;}
        public string price { get; set; }
        public string price_currency { get; set; }
        public string base_price { get; set; }
        public string base_price_currency { get; set; }
        public float btc_spot_rate { get; set; }
        public float usd_spot_rate { get; set; }
        public int confirmations_required { get; set; }
        public string notification_level { get; set; }
        public string callback_url { get; set; }
        //public string notification_email { get; set; }
        public string redirect_url { get; set; }
        public string order_id { get; set; }
        public string item_name { get; set; }
        public string item_sku { get; set; }
        public string item_description { get; set; }
        public string physical { get; set; }
        public string customer_name { get; set; }
        public string customer_address_1 { get; set; }
        public string customer_address_2 { get; set; }
        public string customer_city { get; set; }
        public string customer_region { get; set; }
        public string customer_country { get; set; }
        public string customer_postal_code { get; set; }
        public string customer_email { get; set; }
        public string customer_phone { get; set; }
        public string user_defined_1 {get;set;}
        public string user_defined_2 {get;set;} 
        public string user_defined_3 {get;set;} 
        public string user_defined_4 {get;set;} 
        public string user_defined_5 {get;set;} 
        public string user_defined_6 {get;set;}    
        public string user_defined_7 {get;set;}        
        public string user_defined_8 {get;set;}
        //todo: add a customerdata class for customer details.
        public string data { get; set; }
        public string expires_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string server_time { get; set; }

    }
}