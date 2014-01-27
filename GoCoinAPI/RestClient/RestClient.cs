using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using Logger;

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
        public string Token { get; set; }
        private ErrorManager _errLog = new ErrorManager("File");

        public RestClient()
        {

        }
       
        public RestClient(string endpoint, HttpVerb method, string postData, string callType, string token)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "application/json";
            CallType = callType;
            PostData = postData;
            Token = token;
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
          
            if (!string.IsNullOrEmpty(PostData) && Method == HttpVerb.POST || Method == HttpVerb.PATCH)
            {
                if (!string.IsNullOrEmpty(Token))
                    request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Token);
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;

                using (var writeStream = request.GetRequestStream())
                {
                    writeStream.Write(bytes, 0, bytes.Length);
                }
            }
            if (!string.IsNullOrEmpty(Token))
            {
                request.Headers.Remove(HttpRequestHeader.Authorization);
                request.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + Token);
            }
            var responseValue = string.Empty;
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {         
                   if ((response.StatusCode != HttpStatusCode.OK) && (response.StatusCode != HttpStatusCode.Created) && (response.StatusCode != HttpStatusCode.NoContent))
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
            catch (Exception _ex)
            {

                _errLog.LogError("GoCoinAPI", _ex, "  Received response from server in method: " + "MakeRequest: " + request);
                responseValue = "Error occure due Exception from : MakeRequest";
            }

            return responseValue;
        }
    }
}