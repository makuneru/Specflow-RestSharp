using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharpAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Specflow_RestSharp
{
    [Binding]
    public class UserSuccessfulLoginStepDefinitions
    {
        RegistrationAndLogin login = new RegistrationAndLogin();
        RegistrationAndLogin loggedInUser;
        APIRequests user = new APIRequests();
        private IConfiguration _config;

        public UserSuccessfulLoginStepDefinitions(IConfiguration config)
        {
            _config = config;
        }

        [Given(@"I would like to login using email and password")]
        public void GivenIWouldLikeToLoginUsingEmailAndPassword()
        {
            login.email = _config["secret_email"];
            login.email = _config["secret_password"];
        }

        [When(@"I POST request to login using email and password")]
        public void WhenIPOSTRequestToLoginUsingEmailAndPassword()
        {
            loggedInUser = user.RegisterUser(login);
        }

        [Then(@"Validate that user is successfully logged in")]
        public void ThenValidateThatUserIsSuccessfullyLoggedIn()
        {
            //Verify token response
            Assert.IsNotNull(loggedInUser.Token);
        }
    }
}
