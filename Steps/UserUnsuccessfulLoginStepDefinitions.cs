using TechTalk.SpecFlow;
using RestSharpAPI;
using NUnit.Framework;

namespace Specflow_RestSharp
{
    [Binding]
    public class UserUnsuccessfulLoginStepDefinitions
    {
        RegistrationAndLogin login = new RegistrationAndLogin();
        RegistrationAndLogin loggedInUser = new RegistrationAndLogin();
        APIRequests user = new APIRequests();

        [Given(@"I input password ""([^""]*)""")]
        public void GivenIInputPassword(string password)
        {
            login.password = password;
        }

        [When(@"I POST request to send using password")]
        public void WhenIPOSTRequestToSendUsingPassword()
        {
            loggedInUser = user.RegisterUser(login);
        }

        [Then(@"Validate that user is not loggedin due to missing Email or username")]
        public void ThenValidateThatUserIsNotLoggedinDueToMissingEmailOrUsername()
        {
            //Verify error message
            Assert.AreEqual(loggedInUser.Error, "Missing email or username");
        }
    }
}
