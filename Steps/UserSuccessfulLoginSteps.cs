using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharpAPI;

namespace Specflow_RestSharp
{
    [Binding]
    public class UserSuccessfulLoginSteps
    {
        RegistrationAndLogin login = new RegistrationAndLogin();
        RegistrationAndLogin loggedInUser;
        APIRequests user = new APIRequests();


        [Given(@"I would like to login using email and password")]
        public void GivenIWouldLikeToLoginUsingEmailAndPassword()
        {
            login.email = "eve.holt@reqres.in";
            login.password = "cityslicka";
        }

        [When(@"I POST request to login using email and password")]
        public void WhenIPOSTRequestToLoginUsingEmailAndPassword()
        {
            loggedInUser = user.LoginUser(login);
        }

        [Then(@"Validate that user is successfully logged in")]
        public void ThenValidateThatUserIsSuccessfullyLoggedIn()
        {
            //Verify token response
            Assert.IsNotNull(loggedInUser.Token);
        }
    }
}
