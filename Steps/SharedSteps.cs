using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;
using RestSharp_SpecFlow.Hooks;

namespace RestSharp_SpecFlow.Steps
{
    [Binding]
    public sealed class SharedSteps
    {

        private readonly RestClient client;
        private readonly string accessToken;
        private string endPoint;

        public RestRequest request;
        public RestResponse response;

        public SharedSteps(Hook hook)
        {
            client = hook.RestClient();
            accessToken = hook.AccessToken();
        }

        public RestResponse Response()
        {
            return response;
        }

        [Given(@"Create Request ""([^""]*)"" with ""([^""]*)"" method")]
        public void CreateRequestWithMethod(string _endpoint, Method _method)
        {
            endPoint = _endpoint;

            request = new RestRequest(endPoint, _method);
            request.AddHeader("Authorization", "Bearer " + accessToken);

            request.RequestFormat = DataFormat.Json;
        }

        [When(@"Create URL segment for ""([^""]*)"" with parameter ""([^""]*)""")]
        public void WhenCreateURLSegmentForWithParameter(string _segment, string _parameter)
        {
            request.AddUrlSegment(_segment, _parameter);
        }

        [When(@"Execute API request")]
        public void WhenExecuteAPIRequest()
        {
            response = client.Execute(request);
        }

        [Given(@"Execute API request")]
        public void GivenExecuteAPIRequest()
        {
            response = client.Execute(request);
        }


        [Then(@"Returned status code will be ""(.*)""")]
        public void ReturnedStatusCodeWillBe(string _status)
        {
            var code = response.StatusCode;
            Assert.AreEqual(code.ToString(), _status);
        }
    }
}
