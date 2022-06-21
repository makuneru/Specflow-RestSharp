using TechTalk.SpecFlow;
using NUnit.Framework;
using SmooveAPI;

namespace RestSharp_SpecFlow.Steps.resreq
{
    [Binding]
    public class UpdateUserSteps
    {
        User user = new User();
        User updatedUser = new User();
        BaseService getUser = new BaseService();

        [Given(@"I update name ""([^""]*)"" and job ""([^""]*)""")]
        public void GivenIUpdateNameAndJob(string morpheus, string job)
        {
            user.Name = "morpheus";
            user.Job = "Test Automation Eng";
        }

        [When(@"I send PUT request to update user details of id (.*)")]
        public void WhenISendPUTRequestToUpdateUserDetailsOfId(int id)
        {
            getUser = new BaseService();
            updatedUser = getUser.UpdateUserPutRequest(user, id);
        }

        [Then(@"Validate that user is updated")]
        public void ThenValidateThatUserIsUpdated()
        {
            //Verify updated user details
            Assert.AreEqual(updatedUser.Name, "morpheus");
            Assert.AreEqual(updatedUser.Job, "Test Automation Eng");
        }
    }
}
