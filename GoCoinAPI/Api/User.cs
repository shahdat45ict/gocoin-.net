using System;
using Logger;
using Newtonsoft.Json;

namespace GoCoinAPI
{
    [Serializable]
    public class User
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string email { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string first_name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string last_name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string merchant_id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string current_password { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string password { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string password_confirmation { get; set; }

        RestClient restClient;     
        private ErrorManager _errLog = new ErrorManager("File");
        private string Callbackurl = null;
        private Client _client;
        private Api _api;

        public User()
        {
            
        }

        public User(Api api)
        {
            this._api = api;
        }

        
        public User self()
        {
            Callbackurl = "user/?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
            User User_self = DeserializeJson(restClient.MakeRequest());
            return User_self;
        }

        public User update(User _user)
        {

            Callbackurl = "users/" + _user.id + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.PATCH, SerializeJson(_user), Callbackurl, this._api.client.token);
            User User_update = DeserializeJson(restClient.MakeRequest());
            return User_update;
        }

        public User get(string id)
        {
            Callbackurl = "users/" + id + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
            User User_getbyid = DeserializeJson(restClient.MakeRequest());
            return User_getbyid;
        }
       
        public User update_password(User _user)
        {
            Callbackurl = "users/" + _user.id + "/password" + "?access_token=" + this._api.client.token;
            restClient = new RestClient(this._api.Baseapiurl, HttpVerb.PATCH, SerializeJson(_user), Callbackurl, this._api.client.token);
            User User_update_password = DeserializeJson(restClient.MakeRequest());
            return User_update_password;
        }

        //Todo: Deserialize Json to type T
        private User DeserializeJson(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject<User>(jsonObjectString);
        }

        // Todo: Searialize type T to Json
        private string SerializeJson(User obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

    }
}