using TechTalk.SpecFlow;
using SmooveAPI;
using NUnit.Framework;

namespace RestSharp_SpecFlow.Steps.resreq
{
    [Binding]
    public class DeleteUserSteps
    {
        BaseService deleteUser = new BaseService();
        int resStatusCode;

        [Given(@"I delete user by id")]
        public void GivenIDeleteUserById()
        {
            //endpoint url -> /api/users/2
        }

        [When(@"I send delete request to delete user with id (.*)")]
        public void WhenISendDeleteRequestToDeleteUserWithId(int id)
        {
            deleteUser = new BaseService();
            resStatusCode = deleteUser.DeleteUser(id);
        }

        [Then(@"Validate that user is deleted")]
        public void ThenValidateThatUserIsDeleted()
        {
            //Verify response code
            Assert.AreEqual(resStatusCode, 204);
        }
    }
}
