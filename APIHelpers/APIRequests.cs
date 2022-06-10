using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace RestSharpAPI
{
    [Binding]
    public class APIRequests {
        private string baseUrl, devBaseURL, prodBaseURL, stgBaseURL;

        public string getBaseURL()
        {
            //Default base url
            devBaseURL = "https://reqres.in";

            //Modify the base url based on environment used
            stgBaseURL = "https://reqres.in";
            prodBaseURL = "https://reqres.in";

            //Default Development Environment
            string environment = Environment.GetEnvironmentVariable("Environment") ?? "Development";
            switch (environment)
            {
                case "Development":
                    return baseUrl = devBaseURL;
                case "Staging":
                    return baseUrl = stgBaseURL;
                case "Production":
                    return baseUrl = prodBaseURL;
                default:
                    throw new ArgumentException("Environment not yet implemented");
            }
        }

        public Pages GetListUsers(int page)
        {
            var client = new RestClient(getBaseURL());
            var request = new RestRequest("/api/users?page=" + page, Method.Get);
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;

            var users = JsonConvert.DeserializeObject<Pages>(content);

            return users;
        }

        public Datas GetUser(int id)
        {
            var client = new RestClient(getBaseURL());
            var request = new RestRequest("/api/users/" + id, Method.Get);
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<Datas>(content);

            return user;
        }

        public int UserNotFound(int id)
        {
            var client = new RestClient(getBaseURL());
            var request = new RestRequest("/api/users/" + id, Method.Get);
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var statusCode = (int)response.StatusCode;

            return statusCode;
        }

        public User CreateUser(User userDetails)
        {
            var client = new RestClient(getBaseURL());
            var request = new RestRequest("/api/users/", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(userDetails);

            RestResponse response = client.Execute(request);
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        public User UpdateUserPutRequest(User userDetails, int id)
        {
            var client = new RestClient(getBaseURL());
            var request = new RestRequest("/api/users/" + id, Method.Put);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(userDetails);

            RestResponse response = client.Execute(request);
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        public User UpdateUserPatchRequest(User userDetails, int id)
        {
            var client = new RestClient(getBaseURL());
            var request = new RestRequest("/api/users/" + id, Method.Patch);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(userDetails);

            RestResponse response = client.Execute(request);
            var content = response.Content;

            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        public int DeleteUser(int id)
        {
            var client = new RestClient(getBaseURL());
            var request = new RestRequest("/api/users/" + id, Method.Delete);
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var statusCode = (int)response.StatusCode;

            return statusCode;
        }

        public RegistrationAndLogin RegisterUser(RegistrationAndLogin regUser)
        {
            var client = new RestClient(getBaseURL());
            var request = new RestRequest("/api/register", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(regUser);

            RestResponse response = client.Execute(request);
            var content = response.Content;

            var registration = JsonConvert.DeserializeObject<RegistrationAndLogin>(content);

            return registration;
        }

        public RegistrationAndLogin LoginUser(RegistrationAndLogin loginUser)
        {
            var client = new RestClient(getBaseURL());
            var request = new RestRequest("/api/login", Method.Post);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(loginUser);

            RestResponse response = client.Execute(request);
            var content = response.Content;

            var login = JsonConvert.DeserializeObject<RegistrationAndLogin>(content);

            return login;
        }
    }
}
