using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using RestSharp_SpecFlow.Hooks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SmooveAPI
{
    [Binding]
    public class BaseService {
       
        private RestClient GetRestClient()
        {
            RestClient restClient = new RestClient();
            
            return restClient;

        }

        private RestRequest GetRestRequest(string url, Dictionary<string, string> headers, Method method, object? body)
        {
            RestRequest restRequest = new RestRequest()
            {
                Method = method,
                Resource = url
            };

            if (headers != null)
            {
                foreach (string key in headers.Keys)
                {
                    restRequest.AddHeader(key, headers[key]);
                }
            }

            restRequest.RequestFormat = DataFormat.Json;
            restRequest.AddBody(body);

            return restRequest;
        }

        private RestResponse SendRequest(RestRequest restRequest)
        {
            RestClient restClient = GetRestClient();
            RestResponse restResponse = restClient.Execute(restRequest);

            return restResponse;
        }

        public RestResponse PerformGetRequest(string url, Dictionary<string, string> headers)
        {
            RestRequest restRequest = GetRestRequest(url, headers, Method.Get, null);
            RestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }


        public RestResponse PerformPostRequest(string url, Dictionary<string, string> headers, object body)
        {
            RestRequest restRequest = GetRestRequest(url, headers, Method.Post, body);
            RestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }

        public RestResponse PerformPutRequest(string url, Dictionary<string, string> headers, object body)
        {
            RestRequest restRequest = GetRestRequest(url, headers, Method.Put, body);
            RestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }

        public RestResponse PerformDeleteRequest(string url, Dictionary<string, string> headers)
        {
            RestRequest restRequest = GetRestRequest(url, headers, Method.Delete, null);
            RestResponse restResponse = SendRequest(restRequest);
            return restResponse;
        }


        public readonly string _apiBaseUrl = "https://reqres.in/";
        public Pages GetListUsers(int page)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("/api/users?page=" + page, Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = client.GetAsync(request).GetAwaiter().GetResult();
            var content = response.Content;

            var users = JsonConvert.DeserializeObject<Pages>(content);

            return users;
        }

        public Datas GetUser(int id)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("/api/users/" + id, Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = client.GetAsync(request).GetAwaiter().GetResult();
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<Datas>(content);

            return user;
        }

        public int UserNotFound(int id)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("/api/users/" + id, Method.Get);
            request.RequestFormat = DataFormat.Json;

            var response = client.GetAsync(request).GetAwaiter().GetResult();
            var statusCode = (int)response.StatusCode;

            return statusCode;
        }

        public User CreateUser(User userDetails)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("/api/users/", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(userDetails);

            var response = client.PostAsync(request).GetAwaiter().GetResult();
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        public User UpdateUserPutRequest(User userDetails, int id)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("/api/users/" + id, Method.Put);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(userDetails);

            var response = client.PutAsync(request).GetAwaiter().GetResult();
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        public User UpdateUserPatchRequest(User userDetails, int id)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("/api/users/" + id, Method.Patch);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(userDetails);

            var response = client.PatchAsync(request).GetAwaiter().GetResult();
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        public int DeleteUser(int id)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("/api/users/" + id, Method.Delete);
            request.RequestFormat = DataFormat.Json;

            var response = client.DeleteAsync(request).GetAwaiter().GetResult();
            var statusCode = (int)response.StatusCode;

            return statusCode;
        }

        public RegistrationAndLogin RegisterUser(RegistrationAndLogin regUser)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("/api/register", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(regUser);

            var response = client.ExecuteAsync(request).GetAwaiter().GetResult();
            var content = response.Content;

            var registration = JsonConvert.DeserializeObject<RegistrationAndLogin>(content);

            return registration;
        }

        public RegistrationAndLogin LoginUser(RegistrationAndLogin loginUser)
        {
            var client = new RestClient(_apiBaseUrl);
            var request = new RestRequest("/api/login", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(loginUser);

            var response = client.ExecuteAsync(request).GetAwaiter().GetResult();
            var content = response.Content;

            var login = JsonConvert.DeserializeObject<RegistrationAndLogin>(content);

            return login;
        }
    }
}
