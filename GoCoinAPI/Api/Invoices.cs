using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Logger;

namespace GoCoinAPI
{
    [Serializable]
    public class Invoices
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string merchant_id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string status { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string payment_address{get; set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float price { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string price_currency { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float base_price { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string base_price_currency { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float btc_spot_rate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public float usd_spot_rate { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int confirmations_required { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string notification_level { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string callback_url { get; set; }
        //public string notification_email { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string redirect_url { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string order_id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string item_name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string item_sku { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string item_description { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string physical { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string customer_name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string customer_address_1 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string customer_address_2 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string customer_city { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string customer_region { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string customer_country { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string customer_postal_code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string customer_email { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string customer_phone { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user_defined_1 {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user_defined_2 {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user_defined_3 {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user_defined_4 {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user_defined_5 {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user_defined_6 {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user_defined_7 {get;set;}
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string user_defined_8 {get;set;}
        //todo: add a customerdata class for customer details.
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string data { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string expires_at { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string created_at { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string updated_at { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string server_time { get; set; }


        RestClient restClient;
        private Client _client;
        private Api _api;

        public Invoices()
        {
       
        }


        public Invoices(Api api) {
            this._api = api;
        }

        private ErrorManager _errLog = new ErrorManager("File");
        private string Callbackurl = null;

        /// <summary>
        /// Create a new invoice.
        /// </summary>
        /// <param name="_merchantid">Merchant's id.</param>
        /// <param name="_invoice">New invoice data.</param>
        /// <returns>The created Invoice.</returns>
        public Invoices create(string  _merchantid, Invoices _invoice)
        {             
            Callbackurl = "merchants/" + _merchantid + "/invoices";
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.POST, SerializeJson(_invoice), Callbackurl, this._api.client.token);
            Invoices Invoices_create = DeserializeJson(restClient.MakeRequest());
            return Invoices_create;
        }

        /// <summary>
        /// Searches invoices.
        /// </summary>
        /// <param name="_invoiceparams">Querystring with the invoice parameters.</param>
        /// <returns>The invoices that match the search parameters.</returns>
        public Invoices[] search(string _invoiceparams)
        {

            Callbackurl = "invoices/search?" + _invoiceparams + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
            Invoices[] Invoices_update = DeserializeJsonArray(restClient.MakeRequest());
            return Invoices_update;
        }

        /// <summary>
        /// Gets an invoice.
        /// </summary>
        /// <param name="id">Invoice id.</param>
        /// <returns>The invoice data.</returns>
        public Invoices get(string id)
        {
            Callbackurl = "invoices/" + id + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
            Invoices Invoices_getbyid = DeserializeJson(restClient.MakeRequest());
            return Invoices_getbyid;
        }


        //Todo: Deserialize Json to type T
        private Invoices DeserializeJson(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject<Invoices>(jsonObjectString);
        }

        private Invoices[] DeserializeJsonArray(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject<Invoices[]>(jsonObjectString);
        }

        // Todo: Searialize type T to Json
        private string SerializeJson(Invoices obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

    }
}