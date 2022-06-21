using TechTalk.SpecFlow;
using SmooveAPI;
using NUnit.Framework;

namespace RestSharp_SpecFlow.Steps.resreq
{
    [Binding]
    public class UserUnsuccessfulRegistrationSteps
    {
        RegistrationAndLogin registration = new RegistrationAndLogin();
        RegistrationAndLogin regUser = new RegistrationAndLogin();
        BaseService user = new BaseService();

        [Given(@"I input email ""([^""]*)""")]
        public void GivenIInputEmail(string email)
        {
            registration.email = email;
        }

        [When(@"I POST request to send only the email")]
        public void WhenIPOSTRequestToSendOnlyTheEmail()
        {
            regUser = user.RegisterUser(registration);
        }

        [Then(@"Validate that user is not registered due to missing password")]
        public void ThenValidateThatUserIsNotRegisteredDueToMissingPassword()
        {
            //Verify error message
            Assert.AreEqual(regUser.Error, "Missing password");
        }
    }
}
