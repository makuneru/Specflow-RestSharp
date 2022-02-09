using TechTalk.SpecFlow;
using RestSharpAPI;
using NUnit.Framework;

namespace Specflow_RestSharp
{
    [Binding]
    public class DeleteUserSteps
    {
        APIRequests deleteUser = new APIRequests();
        int resStatusCode;

        [Given(@"I delete user by id")]
        public void GivenIDeleteUserById()
        {
            //endpoint url -> /api/users/2
        }

        [When(@"I send delete request to delete user with id (.*)")]
        public void WhenISendDeleteRequestToDeleteUserWithId(int id)
        {
            deleteUser = new APIRequests();
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
