using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
       
        public List<Accounts> alist(string id)
        {
            Callbackurl = "merchants/" + id + "/accounts"+ "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
            List<Accounts> Accounts_list = DeserializeListJson(restClient.MakeRequest());
            return Accounts_list;
        }

        public Accounts create(Accounts _accounts)
        {
            Callbackurl = "merchants" + _accounts.id + "/accounts" + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.POST, SerializeJson(_accounts), Callbackurl, this._api.client.token);
            Accounts Accounts_create = DeserializeJson(restClient.MakeRequest());
            return Accounts_create;
        }

        public Accounts update(Accounts _accounts)
        {

            Callbackurl = "accounts/" + _accounts.id + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.PATCH, SerializeJson(_accounts), Callbackurl, this._api.client.token);
            Accounts Accounts_update = DeserializeJson(restClient.MakeRequest());
            return Accounts_update;
        }

        public Accounts delete(Accounts _accounts)
        {

            Callbackurl = "accounts/" + _accounts.id + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.DELETE, "", Callbackurl, this._api.client.token);
            Accounts Accounts_Created = DeserializeJson(restClient.MakeRequest());
            return Accounts_Created;
        }

        public Accounts get(string id)
        {
            Callbackurl = "accounts/" + id + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
            Accounts Accounts_getbyid = DeserializeJson(restClient.MakeRequest());
            return Accounts_getbyid;
        }

        public Accounts verify(Accounts _accounts)
        {
            Callbackurl = "accounts/" + _accounts.id + "/verifications" +"?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.POST, SerializeJson(_accounts), Callbackurl, this._api.client.token);
            Accounts Accounts_create = DeserializeJson(restClient.MakeRequest());
            return Accounts_create;
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