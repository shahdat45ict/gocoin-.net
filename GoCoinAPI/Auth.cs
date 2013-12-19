using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;

namespace GoCoinAPI
{
    public class Auth
    {
        public Client _client;
       public AccessToken _accesstoken;

       public Auth()
        {
            
        }

       public Auth(Client client)
       {
           this._client = client;
       }

    /**
    * Return Authorization url to get auth_code 
    *
    * @return string 
    */

    public string  get_auth_url() {  
        _client  = new Client();
        string url = _client.get_dashboard_url() + "/auth";
        var param = new { response_type = "code", client_id =_client.client_id , redirect_uri = _client.get_current_url(),scope=_client.scope };
        url = _client.create_get_url(url, param);
        return url;
    }

    /**
    * do process authorization
    * 
    * @param array $options  Authorization options
    */

    public AccessToken authenticate(AuthorizationCode options)
    {
        string authenticate_url = null;
        authenticate_url = _client.request_client(_client.secure) + "://" + _client.host + _client.path + "/" + _client.api_version + "/oauth/token/";
        _accesstoken = new AccessToken();
        return _accesstoken.getAccessToken(authenticate_url, options);
    }


    }
}
