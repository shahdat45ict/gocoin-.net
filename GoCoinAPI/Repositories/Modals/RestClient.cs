using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace GoCoinAPI
{
    // Http Verbs used to call Rest API
    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE,
        PATCH
    }
    //To call Rest API
    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }
        public string CallType { get; set; }

        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "application/json";
            CallType = "";
            PostData = "";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "application/json";
            CallType = "";
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method, string callType)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            CallType = callType;
            PostData = "";
        }

        public RestClient(string endpoint, HttpVerb method, string postData, string callType)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            CallType = callType;
            PostData = postData;
        }

        public string MakeRequest()
        {
            return MakeRequest("");
        }

        // Sends request to GoCoin API and returns data in Json format.
        public string MakeRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + CallType + parameters);

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;

            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST)
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if ((response.StatusCode != HttpStatusCode.OK) && (response.StatusCode != HttpStatusCode.Created))
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    throw new ApplicationException(message);
                }

                // grab the response
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                        using (var reader = new StreamReader(responseStream))
                        {
                            responseValue = reader.ReadToEnd();
                        }
                }
                return responseValue;
            }
        }
    }
}