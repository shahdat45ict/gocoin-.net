using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;

namespace GoCoinAPI
{
    public class  Client
    {
        private string _client_id;
        private string _client_secret;
        private string _host = "api.gocoin.com";// "api.gocoin.com";
        private string _dashboard_host = "dashboard.gocoin.com";//"dashboard.gocoin.com";
        private Int32 _port;
        private string _path = "/api";
        private string _api_version = "v1";
        private string _headers;
        private string _request_id ;
        private string _redirect_uri;
        private string _auth_code;
        private string _token;
        private string _scope;
        private Boolean _secure = false;

        // Class Call
        Auth _auth;
        AccessToken auth_result;
        Api _api;
        User _user;
        Invoices _invoices;
        Merchant _merchants;
        Accounts _accounts;
        Apps _apps;


        public User user
        {
            get { return _user; }
            set { _user = value; }
        }
        public Api api
        {
            get { return _api; }
            set { _api = value; }
        }

        public Invoices invoices
        {
            get { return _invoices; }
            set { _invoices = value; }
        }

        public Merchant merchants
        {
            get { return _merchants; }
            set { _merchants = value; }
        }

        public Accounts accounts
        {
            get { return _accounts; }
            set { _accounts = value; }
        }

        public Apps apps
        {
            get { return _apps; }
            set { _apps = value; }
        }


        public string client_id
        {
            get { return _client_id; }
            set { _client_id = value; }
        }

        public string client_secret
        {
            get { return _client_secret; }
            set { _client_secret = value; }
        }

        public string host
        {
            get { return _host; }
            set { _host = value; }
        }

        public string dashboard_host
        {
            get { return _dashboard_host; }
            set { _dashboard_host = value; }
        }

        public Int32 port
        {
            get { return _port; }
            set { _port = value; }
        }

        public string path
        {
            get { return _path; }
            set { _path = value; }
        }

        public string api_version
        {
            get { return _api_version; }
            set { _api_version = value; }
        }

        public string headers
        {
            get { return _headers; }
            set { _headers = value; }
        }

        public string request_id
        {
            get { return _request_id; }
            set { _request_id = value; }
        }

        public string redirect_uri
        {
            get { return _redirect_uri; }
            set { _redirect_uri = value; }
        }

        public Boolean secure
        {
            get { return _secure; }
            set { _secure = value; }
        }

        public string auth_code
        {
            get { return _auth_code; }
            set { _auth_code = value; }
        }

        public string token
        {
            get { return _token; }
            set { _token = value; }
        }

        public string scope
        {
            get { return _scope; }
            set { _scope = value; }
        }

        public Client()
        {
            this._auth = new Auth(this);
            this._api = new Api(this);
            this.user = this.api.user;
        }

       

    /**
    * Authorization process
    * @return boolean    
    */
   
    public bool authorize_api() {
      // if (string.IsNullOrEmpty(this.getToken()) == false)
        if (this.getToken() != null) {
            return true;
        }        
        return this.get_token_from_request();        
    }

    /**
    * Initialize access token and session data
    * 
    */
    
    public void initToken() {
        HttpContext.Current.Session["gocoin_access_token"] = null;
        this.token = null;
       
    }

    /**
    * Return client id
    *  @return String $client_id
    */
    
    public string getClientId() {
        return this.client_id;
    }
    
    /**
    * Set client_id in options array
    * 
    * @param mixed $client_id
    * @return Client
    */
    
    public string setClientId(string setclient_id) {
        this.client_id = setclient_id;
        return this.client_id;
    }
    
    /**
    * Return client secret 
    *  @return String $client_secret
    */
    
    public string getClientSecret() {
        return this.client_secret;  
    }
    
    /**
    * Set client secret in options array
    * 
    * @param mixed $secret
    * @return Client
    */

    public Client setClientSecret(string secret)
    {
        this.client_secret = secret;
        return this;
    }

    /**
    * Get authorization code and setToken
    *  if process is done successfully, return true else return false
    * @return boolean
    */
    
    public bool get_token_from_request() {  
        string authcode = HttpContext.Current.Request.QueryString["code"];
        if (authcode != null)
        {
            auth_code = authcode;
            AuthorizationCode code = new AuthorizationCode();
            code.client_id = this.client_id;
            code.client_secret = this.client_secret;
            code.code = this.auth_code;
            code.grant_type = "authorization_code";
            code.redirect_uri = this.redirect_uri;
            auth_result = new AccessToken();
            this._auth = new Auth(this);
            auth_result = _auth.authenticate(code);
            this.setToken(auth_result);
            return true;
        }
        else
        {
            return false;
        }
    }

    /**
    * Return Api's url
    * 
    * @param mixed $options  The Array value including api options
    * @return string
    */
    
    public string get_api_url( string options) {
        string api_url = null;
        api_url = this.request_client(this.secure) + "://" + this.host.TrimEnd('/') + "/" + this.path.TrimEnd('/') + "/" + this.api_version;
        return  api_url;
    }


    /**
    * Set access token
    * 
    * @param string $token
    */
    
    public void setToken( AccessToken token) {
       HttpContext.Current.Session["gocoin_access_token"] = token.access_token;
       this.token = token.access_token;
    }
    
    /**
    * Return access token
    *  @return String $token
    */
    
    public string getToken() {
        if (this.token == null) {
            if ( HttpContext.Current.Session["gocoin_access_token"] !=null) {
                this.token = HttpContext.Current.Session["gocoin_access_token"].ToString();
            }
        }
        return this.token;
    }



    /**
    * Return dashboard api's url
    * @return string
    */
    
    public string get_dashboard_url() {
        return this.dashboard_host;
    }

    /**
    * Return Authorization url
    *  @return string
    */
    
    public string get_auth_url() {        
        string returnurl = null;
        string url = this.get_dashboard_url() + "/auth";
        var param = new { response_type = "code", client_id = this.client_id, redirect_uri = this.get_current_url(), scope = this.scope, state="1234" };
        returnurl = this.create_get_url(url, param);
        //_auth = new Auth();
        //string authurl = _auth.get_auth_url();
        return returnurl;
    }



     /**
    * Return protocol string for http
    * 
    * @param mixed secure
    * @return mixed
    */
    
    public string request_client(Boolean _secure) {

        string strhttps = "https";
        string strhttp = "http";

        if (_secure == null) {
            _secure = true;
        }
        if (_secure) {
            return strhttps;
        } else {
            return strhttp;
        }
    }


   /**
     * create_get_url
     * Create complete url for GET method with auth parameters     
     * @param String $url The base URL for api
     * @param Array $params The parameters to pass to the URL
     * @return string
     */    
    public string create_get_url(string url, object _params){
        string result =null;
        string _url = url;
        var a  = _params;
      //  if(string.IsNullOrEmpty(_params.ToString())){
             var type = a.GetType();
             var props = type.GetProperties();
             var pairs = props.Select(x => x.Name + "=" + x.GetValue(a, null)).ToArray();
            result = string.Join("&", pairs);

            _url = url.Trim() + "?" + result;
       // }        
        return _url;
    }



    /* Return api port
    * 
    * @param mixed $secure
    * @return int
    */

    public Int32 check_port(Boolean secure)
    {
        if (secure == null) {
            secure = true;
        }
        if (this.port == null) {
            return this.port;
        } else if (secure) {
            return 443;
        } else {
            return 80;
        }
    }

    /**
    * get_current_url
    * Returns the Current URL, drop params what is included in default params
    *  @return string
    */
    public string  get_current_url() {
        string current_url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority +
    HttpContext.Current.Request.ApplicationPath.TrimEnd('/') + "/";
      
        if (HttpContext.Current.Request.ServerVariables["HTTPS"] == "on" || HttpContext.Current.Request.IsSecureConnection)
        {
            current_url = "https://" + current_url;
        }
        //else
        //{
        //    current_url = "http://" + current_url;
        //}
        return current_url;
    }

   /**
    * Get result from curl and process it
    * 
    * @param mixed $config configuration parameter
    *
    * @return Object
    */

    //public User user_self()
    //{
    //    _user = _api.User_Self();
    //    return _user;

    //}




    }
}