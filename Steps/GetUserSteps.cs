using TechTalk.SpecFlow;
using RestSharpAPI;
using NUnit.Framework;

namespace Specflow_RestSharp
{
    [Binding]
    public class GetUserSteps
    {
        APIRequests getUser;
        Datas resUser;
        [Given(@"I would like to Get User")]
        public void GivenIWouldLikeToGetUser()
        {
            //endpoint url -> /api/users/2
        }

        [When(@"I send GET request to list the user with id (.*)")]
        public void WhenISendGETRequestToListTheUserWithId(int id)
        {
            getUser = new APIRequests();
            resUser = getUser.GetUser(id);

            Assert.AreEqual(resUser.Data.Id, id); //verify id
        }

        [Then(@"Validate the users details")]
        public void ThenValidateTheUsersDetails()
        {
            //Verify user details
            Assert.AreEqual(resUser.Data.First_Name, "Janet");
            Assert.AreEqual(resUser.Data.Last_Name, "Weaver");
            Assert.AreEqual(resUser.Data.Email, "janet.weaver@reqres.in");
        }
    }
}
