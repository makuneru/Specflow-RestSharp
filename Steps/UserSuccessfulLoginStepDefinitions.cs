using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharpAPI;

namespace Specflow_RestSharp
{
    [Binding]
    public class UserSuccessfulLoginStepDefinitions
    {
        RegistrationAndLogin login = new RegistrationAndLogin();
        RegistrationAndLogin loggedInUser;
        APIRequests user = new APIRequests();
        

        [Given(@"I would like to login email ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIWouldLikeToLoginEmailAndPassword(string email, string password)
        {
            login.email = email;
            login.password = password;
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
