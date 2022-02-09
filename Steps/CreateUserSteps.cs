using TechTalk.SpecFlow;
using RestSharpAPI;
using NUnit.Framework;

namespace Specflow_RestSharp
{
    [Binding]
    public class CreateUserSteps
    {
        User user = new User();
        User newUser = new User();
        APIRequests getUser = new APIRequests();

        [Given(@"I input name ""([^""]*)"" and job ""([^""]*)""")]
        public void GivenIInputNameAndJob(string name, string job)
        {
            user.Name = name;
            user.Job = job;
        }

        [When(@"I send create user POST request")]
        public void WhenISendCreateUserPOSTRequest()
        {
            newUser = getUser.CreateUser(user);
        }

        [Then(@"Validate that user is created")]
        public void ThenValidateThatUserIsCreated()
        {
            //Verify created user details
            Assert.AreEqual(newUser.Name, "morpheus");
            Assert.AreEqual(newUser.Job, "leader");
        }
    }
}
