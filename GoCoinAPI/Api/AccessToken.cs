using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoCoinAPI
{
    [Serializable]
    public class AccessToken
    {
        RestClient restClient;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string access_token { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string token_type { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string expires_in { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string refresh_token { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string scope { get; set; }

        public AccessToken getAccessToken(string url ,AuthorizationCode authCode)
        {
            restClient = new RestClient(url, HttpVerb.POST, SerializeJson(authCode), "", "");
            AccessToken accessTokenObj = DeserializeJson(restClient.MakeRequest());
            return accessTokenObj;
        }

        //Todo: Deserialize Json to type T
        private AccessToken DeserializeJson(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject<AccessToken>(jsonObjectString);
        }

        // Todo: Searialize type T to Json
        private string SerializeJson(AuthorizationCode obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }


}