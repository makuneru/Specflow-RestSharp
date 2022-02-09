using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharpAPI;

namespace Specflow_RestSharp
{
    [Binding]
    public class UserNotFoundSteps
    {
        APIRequests userNotFound;
        int resStatusCode;

        [Given(@"I would like to test user not found")]
        public void GivenIWouldLikeToTestUsersNotFound()
        {
            //endpoint url -> /api/users/99
        }

        [When(@"I send GET request with invalid id (.*)")]
        public void WhenISendGETRequestWithInvalidId(int id)
        {
            userNotFound = new APIRequests();
            resStatusCode = userNotFound.UserNotFound(id);
        }

        [Then(@"Validate that user is not found and has (.*) response\.")]
        public void ThenValidateThatUserIsNotFoundAndHasResponse_(int status)
        {
            Assert.AreEqual(resStatusCode, status);
        }
    }
}
