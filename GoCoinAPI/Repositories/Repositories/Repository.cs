using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GoCoinAPI;
using Newtonsoft.Json;
using System.Configuration;

namespace GoCoinAPI
{
    public class Repository<T> : IRepository<T> where T : class
    {
        RestClient restClient;
         private string _strURI = "http://api.gocoin.com/api/v1/";
        //Todo: Get list of T Type entities
        public List<T> GetAll(string callType,string _accessToken)
        {
            restClient = new RestClient(_strURI, HttpVerb.GET, "", callType, _accessToken);
            List<T> resultUser;
            resultUser = DeserializeJsonList(restClient.MakeRequest());
            return resultUser;
        }

        public List<T> GetListById(string callType, string _accessToken)
        {
            restClient = new RestClient(_strURI, HttpVerb.GET, "", callType, _accessToken);
            List<T> resultUser;
            resultUser = DeserializeJsonList(restClient.MakeRequest());
            return resultUser;
        }


        //Todo: Get T Type by ID
        //public T GetByContents(string callType)
        //{
        //    restUsers = new RestClient(_strURI, HttpVerb.GET, callType);
        //    T resultUser = DeserializeJson(restUsers.MakeRequest());
        //    return resultUser;
        //}


        //Todo: Get T Type by ID
        public T GetById(string callType, string _accessToken)
        {
            restClient = new RestClient(_strURI, HttpVerb.GET,"", callType, _accessToken);
            T resultUser = DeserializeJson(restClient.MakeRequest());
            return resultUser;
        }


        public T GetByIdPostRequest(string callType, string datatopost, string _accessToken)
        {
            restClient = new RestClient(_strURI, HttpVerb.POST, datatopost, callType, _accessToken);
            T resultUser = DeserializeJson(restClient.MakeRequest());
            return resultUser;
        }


        //Todo: Create new instance of type T
        public T Create(T obj, string callType, string _accessToken)
        {
            restClient = new RestClient(_strURI, HttpVerb.POST, SerializeJson(obj), callType, _accessToken);
            T newUser = DeserializeJson(restClient.MakeRequest());
            return newUser;
        }

        //Todo: Updates type T
        public T Edit(T editObj, string callType, string _accessToken)
        {
            restClient = new RestClient(_strURI, HttpVerb.PATCH, SerializeJson(editObj),callType, _accessToken);
            T editUser = DeserializeJson(restClient.MakeRequest());
            return editUser;
        }

        //Todo: Search data using type T
        public T Search(string callType, string _accessToken)
        {
            restClient = new RestClient(_strURI, HttpVerb.GET,"", callType,_accessToken);
            T search = DeserializeJson(restClient.MakeRequest());
            return search;
        }

        //Todo: Delete type T by ID.
        public string Delete(string id, string callType, string _accessToken)
        {
            restClient = new RestClient(_strURI, HttpVerb.DELETE,"", callType + id, _accessToken);
            return restClient.MakeRequest();
        }

        //Todo: Deserialize Json collection to list of type T
        private List<T> DeserializeJsonList(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject<List<T>>(jsonObjectString);
        }

        //Todo: Deserialize Json to type T
        private T DeserializeJson(string jsonObjectString)
        {
            return JsonConvert.DeserializeObject<T>(jsonObjectString);
        }

        // Todo: Searialize type T to Json
        private string SerializeJson(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }


       
    }
}