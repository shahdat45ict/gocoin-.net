using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Logger;

namespace GoCoinAPI
{
    [Serializable]
    public class Accounts
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string currency_code { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string balance { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string merchantid { get; set; }
        

        RestClient restClient;

        private ErrorManager _errLog = new ErrorManager("File");
        private string Callbackurl = null;
        private Api _api;

        public Accounts(Api api)
        {
            this._api = api;
        }
       
        /// <summary>
        /// Gets a list of accounts and balances associated with a merchant.
        /// </summary>
        /// <param name="id">Merchant's id</param>
        /// <returns>List of accounts of the given merchant.</returns>
        public List<Accounts> alist(string id)
        {
            Callbackurl = "merchants/" + id + "/accounts"+ "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
            List<Accounts> Accounts_list = DeserializeListJson(restClient.MakeRequest());
            return Accounts_list;
        }

        //Todo: Deserialize Json to type T
        private Accounts DeserializeJson(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject<Accounts>(jsonObjectString);
        }

        //Todo: Deserialize List Json to type T
        private List<Accounts> DeserializeListJson(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject <List<Accounts>>(jsonObjectString);
        }

        // Todo: Searialize type T to Json
        private string SerializeJson(Accounts obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        // Todo: Searialize type T to Json
        private string SerializeJson(Merchant obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}