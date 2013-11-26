using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace GoCoinAPI
{
    class GoCoinAccessTokenService
    {
        RestClient restUsers;
        public GoCoinAccessToken getAccessToken(GoCoinAuthorizationCode authCode)
        {
            restUsers = new RestClient("http://api.llamacoin.com/api/v1/oauth/token/", HttpVerb.POST, SerializeJson(authCode), "");
            GoCoinAccessToken accessTokenObj = DeserializeJson(restUsers.MakeRequest());
            return accessTokenObj;
        }

        //Todo: Deserialize Json to type T
        private GoCoinAccessToken DeserializeJson(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject<GoCoinAccessToken>(jsonObjectString);
        }

        // Todo: Searialize type T to Json
        private string SerializeJson(GoCoinAuthorizationCode obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}