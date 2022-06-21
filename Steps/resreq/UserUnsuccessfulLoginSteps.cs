using TechTalk.SpecFlow;
using SmooveAPI;
using NUnit.Framework;

namespace RestSharp_SpecFlow.Steps.resreq
{
    [Binding]
    public class UserUnsuccessfulLoginSteps
    {
        RegistrationAndLogin login = new RegistrationAndLogin();
        RegistrationAndLogin loggedInUser = new RegistrationAndLogin();
        BaseService user = new BaseService();

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
