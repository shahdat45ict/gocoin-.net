using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoCoinAPI
{
    [Serializable]
    public class AuthorizationCode
    {
        private string _grant_type;
        private string _code;
        private string _username;
        private string _password;
        private string _client_id;
        private string _client_secret;
        private string _redirect_uri;


        public string grant_type
        {
            get { return _grant_type; }
            set { _grant_type = value; }
        }
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
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
        public string redirect_uri
        {
            get { return _redirect_uri; }
            set { _redirect_uri = value; }
        }

    }
}