using TechTalk.SpecFlow;
using SmooveAPI;
using NUnit.Framework;

namespace RestSharp_SpecFlow.Steps.resreq
{
    [Binding]
    public class UserSuccessfulRegistrationSteps
    {
        RegistrationAndLogin regUser = new RegistrationAndLogin();
        RegistrationAndLogin registration = new RegistrationAndLogin();
        BaseService getUser = new BaseService();

        [Given(@"I input email ""([^""]*)"" and password ""([^""]*)""")]
        public void GivenIInputEmailAndPassword(string email, string password)
        {
            registration.email = email;
            registration.password = password;
        }

        [When(@"I POST request to register user")]
        public void WhenIPOSTRequestToRegisterUser()
        {
            regUser = getUser.RegisterUser(registration);
        }

        [Then(@"Validate that user is successfully registered")]
        public void ThenValidateThatUserIsSuccessfullyRegistered()
        {
            //Verify id and token response
            Assert.IsNotNull(regUser.Id);
            Assert.IsNotNull(regUser.Token);
        }
    }
}
