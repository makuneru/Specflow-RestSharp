using TechTalk.SpecFlow;
using RestSharpAPI;
using NUnit.Framework;

namespace Specflow_RestSharp
{
    [Binding]
    public class UserSuccessfulRegistrationSteps
    {
        RegistrationAndLogin regUser = new RegistrationAndLogin();
        RegistrationAndLogin registration = new RegistrationAndLogin();
        APIRequests getUser = new APIRequests();

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
