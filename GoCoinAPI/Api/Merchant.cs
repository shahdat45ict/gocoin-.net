using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Logger;

namespace GoCoinAPI
{
    [Serializable]
    public class Merchant
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string address_1 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string address_2 { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string city { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string region { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string country_code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string postal_code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string contact_name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string phone { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string website { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string description { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string tax_id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string logo_url { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string btc_payout_split { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string usd_payout_split { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string created_at { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string updated_at { get; set; }

        RestClient restClient;

        private ErrorManager _errLog = new ErrorManager("File");
        private string Callbackurl = null;
        private Api _api;

        public Merchant(Api api) {
            this._api = api;
        }

        public Merchant list()
        {
            Callbackurl = "merchants?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
            Merchant Merchant_list = DeserializeJson(restClient.MakeRequest());
            return Merchant_list;
        }

        public Merchant create(Merchant _merchant)
        {
            Callbackurl = "merchants?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.POST, SerializeJson(_merchant), Callbackurl, this._api.client.token);
            Merchant Merchant_create = DeserializeJson(restClient.MakeRequest());
            return Merchant_create;
        }

        public Merchant update(Merchant _merchant)
        {

            Callbackurl = "merchants/" + _merchant.id + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.PATCH, SerializeJson(_merchant), Callbackurl, this._api.client.token);
            Merchant Merchant_update = DeserializeJson(restClient.MakeRequest());
            return Merchant_update;
        }

        public Merchant delete(Merchant _merchant)
        {

            Callbackurl = "merchants/" + _merchant.id + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.DELETE, "", Callbackurl, this._api.client.token);
            Merchant Merchant_Created = DeserializeJson(restClient.MakeRequest());
            return Merchant_Created;
        }

        public Merchant get(string id)
        {
            Callbackurl = "merchants/" + id + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
            Merchant Merchant_getbyid = DeserializeJson(restClient.MakeRequest());
            return Merchant_getbyid;
        }


        //Todo: Deserialize Json to type T
        private Merchant DeserializeJson(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject<Merchant>(jsonObjectString);
        }

        // Todo: Searialize type T to Json
        private string SerializeJson(Merchant obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}