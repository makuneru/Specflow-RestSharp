using TechTalk.SpecFlow;
using SmooveAPI;
using NUnit.Framework;

namespace RestSharp_SpecFlow.Steps.resreq
{
    [Binding]
    public class CreateUserSteps
    {
        User user = new User();
        User newUser = new User();
        BaseService getUser = new BaseService();

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
