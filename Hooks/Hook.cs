using OpenQA.Selenium;
using RestSharp;
using SmooveAPI;
using System;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;

namespace RestSharp_SpecFlow.Hooks
{
    [Binding]
    public sealed class Hook 
    {
        private readonly string _apiBaseUrl = "";
        private readonly string _tokenUrl = "";
        private readonly string _clientId = "";
        private readonly string _clientSecret = "";
        private readonly string _scope = "";
        private readonly string _username = "";
        private readonly string _password = "";
        private readonly string _smooveAuthCodeUrl = "";
        private readonly string _redirectUri = "";

        private string _accessToken = "";
        private string _code = "";

        private WebDriver driver = null!;

        private RestClient client;

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Hook req = new Hook();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            client = new RestClient(_apiBaseUrl);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            client = null;
        }

        public RestClient RestClient()
        {
            return client;
        }

        public String AccessToken()
        {
            return _accessToken;
        }

    
        public Hook()
        {
            _apiBaseUrl = "https://smoove-portal-dev-03-apiapp.azurewebsites.net/api";
            _smooveAuthCodeUrl = "https://smoovedev01.b2clogin.com/smoovedev01.onmicrosoft.com/B2C_1_NewUser/oauth2/v2.0/authorize?client_id=fa51e24f-de35-4668-9555-66202ef3f393&redirect_uri=https://jwt.ms/&scope=https://smoovedev01.onmicrosoft.com/fa51e24f-de35-4668-9555-66202ef3f393/user_access&response_type=code";
            _username = "joan.d.lee112@gmail.com";
            _password = "Smoove2022";
            _clientId = "fa51e24f-de35-4668-9555-66202ef3f393";
            _clientSecret = "hYA8Q~bQLwP~rP3OXRqUMtI8LJOz7JpoG34Rdbhp";
            _tokenUrl = "https://smoovedev01.b2clogin.com/smoovedev01.onmicrosoft.com/B2C_1_NewUser/oauth2/v2.0/token";
            _scope = "https://smoovedev01.onmicrosoft.com/fa51e24f-de35-4668-9555-66202ef3f393/user_access";
            _redirectUri = "https://jwt.ms/";
            _accessToken = GetAccessToken();
        }

        public string GetAccessToken()
        {
            // Get Access Token
            string grant_type = "authorization_code";

            var client = new RestClient(_tokenUrl);
            var request = new RestRequest("", Method.Post);
            request.AddParameter("grant_type", grant_type);
            request.AddParameter("client_id", _clientId);
            request.AddParameter("code", _code == "" ? GetAuthorizationCode() : _code);
            request.AddParameter("redirect_uri", _redirectUri);
            request.AddParameter("client_secret", _clientSecret);
            request.AddParameter("scope", _scope);
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;

            var token = JsonConvert.DeserializeObject<TokenDetails>(content);
            //Console.WriteLine("Access Token: " + authorization.AccessToken);

            _accessToken = token.AccessToken;

            return _accessToken;
        }

        public string GetAuthorizationCode()
        {
            // Setup Driver
            driver = GetChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(120);

            // Get Authoriation Code
            driver.Navigate().GoToUrl(_smooveAuthCodeUrl);
            driver.FindElement(By.Id("email")).SendKeys(_username);
            driver.FindElement(By.Id("password")).SendKeys(_password);
            driver.FindElement(By.Id("next")).Click();

            // Wait for the page to load
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement header = wait.Until(e => e.FindElement(By.ClassName("navbar-header")));
            Assert.AreEqual("jwt.ms: Welcome!", driver.Title);

            _code = driver.Url.Split("=")[1];
            driver.Quit();

            return _code;
        }

        private WebDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArguments("--headless");

            return new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), options);
        }
    }
}