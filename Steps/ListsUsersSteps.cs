using TechTalk.SpecFlow;
using NUnit.Framework;
using RestSharpAPI;

namespace Specflow_RestSharp
{
    [Binding]
    public class ListsUsersSteps
    {
        APIRequests getListUsers;
        Pages resListUsers;

        [Given(@"I would like to list users")]
        public void GivenIWouldLikeToListUsers()
        {
            //endpoint url -> /api/users?page=2
        }

        [When(@"I send GET request to list the users on page (.*)")]
        public void WhenISendGETRequestToListTheUsersOnPage(int page)
        {
            getListUsers = new APIRequests();
            resListUsers = getListUsers.GetListUsers(page);
        }

        [Then(@"Validate the list users page details")]
        public void ThenValidateTheListUsersPageDetails()
        {
            Assert.AreEqual(resListUsers.Page, 2); //get users from page 2
            Assert.AreEqual(resListUsers.Per_Page, 6); //6 users per page
            Assert.AreEqual(resListUsers.Total_Pages, 2); // total pages
            Assert.AreEqual(resListUsers.Total, 12); //total number of users
            Assert.AreEqual(resListUsers.Data.Count, 6); //6 users per page
        }
    }
}
