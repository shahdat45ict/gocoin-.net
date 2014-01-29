using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace GoCoinAPI
{
    public class Api
    {
        private Client _client;
        private User _user;
        private Invoices _invoices;
        private Merchant _merchants;
        private Accounts _accounts;
        private string _Baseapiurl;
        private string _accesstoken;
        private string _baseapiSecureUrl;


        public Client client
        {
            get { return _client; }
            set { _client = value; }
        }

        public User user
        {
            get { return _user; }
            set { _user = value; }
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

        public string BaseapiSecureUrl
        {
            get { return _baseapiSecureUrl; }
            set { _baseapiSecureUrl = value; }
        }

        public string Baseapiurl
        {
            get { return _Baseapiurl; }
            set { _Baseapiurl = value; }
        }

        public string accesstoken
        {
            get { return _accesstoken; }
            set { _accesstoken = value; }
        }

        public Api()
        {

        }
        public Api(Client client)
        {
           this._client = client;
           this._user = new User(this);
           this._merchants = new Merchant(this);
           this._invoices = new Invoices(this);
           this._accounts = new Accounts(this);
           this.Baseapiurl = client.request_client(client.secure) + "://" + client.host.Trim('/') + "/" + client.path.Trim('/') + "/" + client.api_version.Trim('/') + "/";
            this.BaseapiSecureUrl = this.Baseapiurl.Replace("http://", "https://");
        }

        
    }
}
