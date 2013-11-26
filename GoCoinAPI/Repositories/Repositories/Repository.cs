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
        RestClient restUsers;
        private string _strURI = "http://api.llamacoin.com/api/v1/";
        //Todo: Get list of T Type entities
        public List<T> GetAll(string callType)
        {
            restUsers = new RestClient(_strURI, HttpVerb.GET, callType);
            List<T> resultUser;
            resultUser = DeserializeJsonList(restUsers.MakeRequest());
            return resultUser;
        }

        //Todo: Get T Type by ID
        public T GetById(string callType)
        {
            restUsers = new RestClient(_strURI, HttpVerb.GET, callType);
            T resultUser = DeserializeJson(restUsers.MakeRequest());
            return resultUser;
        }

        //Todo: Create new instance of type T
        public T Create(T obj, string callType)
        {
            restUsers = new RestClient(_strURI, HttpVerb.POST, SerializeJson(obj), callType);
            T newUser = DeserializeJson(restUsers.MakeRequest());
            return newUser;
        }

        //Todo: Updates type T
        public T Edit(T editObj, string callType)
        {
            restUsers = new RestClient(_strURI, HttpVerb.GET, SerializeJson(editObj), callType);
            T editUser = DeserializeJson(restUsers.MakeRequest());
            return editUser;
        }

        //Todo: Search data using type T
        public T Search(string callType)
        {
            restUsers = new RestClient(_strURI, HttpVerb.GET, callType);
            T search = DeserializeJson(restUsers.MakeRequest());
            return search;
        }

        //Todo: Delete type T by ID.
        public string Delete(string id, string callType)
        {
            restUsers = new RestClient(_strURI, HttpVerb.DELETE, callType + id);
            return restUsers.MakeRequest();
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