using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Logger;
using Newtonsoft.Json;

namespace GoCoinAPI
{
     [Serializable]
    public class Apps
    {
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string id { get; set; }
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string name { get; set; }
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string secret { get; set; }
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string redirect_uri { get; set; }
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string created_at { get; set; }
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string updated_at { get; set; }
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string owner_id { get; set; }
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string owner_type { get; set; }
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string allow_grant_type_password { get; set; }
         [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
          public string allow_grant_type_authorization_code { get; set; }

          RestClient restClient;
          private ErrorManager _errLog = new ErrorManager("File");
          private string Callbackurl = null;
          private Client _client;
          private Api _api;

          public Apps(Api api) {
              this._api = api;
          }

          public Apps create(Apps _apps)
          {
              Callbackurl = "/oauth/applications?access_token=" + this._api.client.token;
              restClient = new RestClient(this._api.Baseapiurl, HttpVerb.POST, SerializeJson(_apps), Callbackurl, this._api.client.token);
              Apps Apps_create = DeserializeJson(restClient.MakeRequest());
              return Apps_create;
          }

          public Apps create_code(Apps _Apps)
          {
              Callbackurl = "/oauth/authorize?access_token=" + this._api.client.token;
              restClient = new RestClient(this._api.Baseapiurl, HttpVerb.POST, SerializeJson(_Apps), Callbackurl, this._api.client.token);
              Apps Apps_create_code = DeserializeJson(restClient.MakeRequest());
              return Apps_create_code;
          }

          public Apps delete_authorized(string id, string callback)
          {

              Callbackurl = "/oauth/authorized_applications/" + id + "?access_token=" + this._api.client.token;
              restClient = new RestClient(this._api.Baseapiurl, HttpVerb.DELETE, "", Callbackurl, this._api.client.token);
              Apps Apps_delete_authorized = DeserializeJson(restClient.MakeRequest());
              return Apps_delete_authorized;
          }

          public Apps delete(string id, string callback)
          {

              Callbackurl = "/oauth/applications/" + id + "?access_token=" + this._api.client.token;
              restClient = new RestClient(this._api.Baseapiurl, HttpVerb.DELETE, "", Callbackurl, this._api.client.token);
              Apps Apps_delete = DeserializeJson(restClient.MakeRequest());
              return Apps_delete;
          }

          public Apps get(Int32 id, string callback)
          {
              Callbackurl = "/oauth/applications/" + id + "?access_token=" + this._api.client.token;
              restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
              Apps Apps_getbyid = DeserializeJson(restClient.MakeRequest());
              return Apps_getbyid;
          }

          public List<Apps> alist(string id, string callback)
          {
              Callbackurl = "/users/" + id + "?access_token=" + this._api.client.token;
              restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
              List<Apps> Apps_alist = DeserializeListJson(restClient.MakeRequest());
              return Apps_alist;
          }

          public Apps list_authorized(string id, string callback)
          {
              Callbackurl = "/users/" + id + "?access_token=" + this._api.client.token;
              restClient = new RestClient(this._api.Baseapiurl, HttpVerb.GET, "", Callbackurl, this._api.client.token);
              Apps Apps_list_authorized = DeserializeJson(restClient.MakeRequest());
              return Apps_list_authorized;
          }

          public Apps update(Apps _pps)
          {

              Callbackurl = "/oauth/applications/" + _pps.id + "?access_token=" + this._api.client.token;
              restClient = new RestClient(this._api.Baseapiurl, HttpVerb.PATCH, SerializeJson(_pps), Callbackurl, this._api.client.token);
              Apps Apps_update = DeserializeJson(restClient.MakeRequest());
              return Apps_update;
          }

          public Apps new_secret(string id, string callback)
          {
              Callbackurl = "/oauth/applications/" + id + "/request_new_secret" + "?access_token=" + this._api.client.token;
              restClient = new RestClient(this._api.Baseapiurl, HttpVerb.POST, "", Callbackurl, this._api.client.token);
              Apps Apps_list_authorized = DeserializeJson(restClient.MakeRequest());
              return Apps_list_authorized;
          }


          //Todo: Deserialize Json to type T
          private Apps DeserializeJson(string jsonObjectString)
          {
              return JsonConvert.DeserializeObject<Apps>(jsonObjectString);
          }
          //Todo: Deserialize List Json to type T
          private List<Apps> DeserializeListJson(string jsonObjectString)
          {
              return JsonConvert.DeserializeObject<List<Apps>>(jsonObjectString);
          }


          // Todo: Searialize type T to Json
          private string SerializeJson(Apps obj)
          {
              return JsonConvert.SerializeObject(obj);
          }


    }
}
