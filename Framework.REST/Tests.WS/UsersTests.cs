using System;
using System.Net;
using Framework.REST;
using Framework.REST.RequestData;
using NUnit.Framework;
using RestSharp;

namespace Tests.WS
{
    [TestFixture]
    public class UsersTests
    {
        [Test]
        public void VerifyUsersDataOnSpecificPage()
        {
            int expUsersAmountOnPage2 = 3;
            int expUsersTotalAmount = 12;
            int expTotalPagesAmount = 4;

            // Verify that 3 Users are present on Page#2;
            var usersData = REST.Users.GetUsersFromPage(2);
            int curUsersAmountOnPage2 = usersData.Data.Count;
            Assert.AreEqual(expUsersAmountOnPage2, curUsersAmountOnPage2);

            // Verify that Total Amount of Users = 12;
            int curUsersTotalAmount = usersData.Total;
            Assert.AreEqual(expUsersTotalAmount, curUsersTotalAmount);

            // Verify that Total Amount of Pages = 4;
            int curTotalPagesAmount = usersData.TotalPages;
            Assert.AreEqual(expTotalPagesAmount, curTotalPagesAmount);
        }

        [Test]
        public void VerifySingleUserData()
        {
            int expId = 2;
            string expFirstName = "Janet";
            string expLastName = "Weaver";
            string expAvatarUrl = "https://s3.amazonaws.com/uifaces/faces/twitter/josephstein/128.jpg";

            // Verify Id;
            var userData = REST.Users.GetSingleUser(2);

            int curId = userData.Id;
            Assert.AreEqual(expId, curId);

            // Verify that FirstName of 2-nd User = "Janet";
            string curFirstName = userData.FirstName;
            Assert.AreEqual(expFirstName, curFirstName);

            // Verify that LastName of 2-nd User = "Weaver";
            string curLastName = userData.LastName;
            Assert.AreEqual(expLastName, curLastName);

            // Verify AvatarUrl of 2-nd User;
            string curAvatar = userData.Avatar;
            Assert.AreEqual(expAvatarUrl, curAvatar);
        }

        [Test]
        public void CreateUser()
        {
            UserRequest requestData = new UserRequest
            {
                Name = "newName",
                Job = "newJob"
            };
            int amountOfUserBeforeCreation = REST.Users.GetUsers().Total;

            var userResponse = REST.Users.CreateUser(requestData);

            var actualStatusCode = userResponse.StatusCode;
            Assert.AreEqual(HttpStatusCode.Created, actualStatusCode, $"User is not created, HttpStatusCode:{actualStatusCode}");

            var userName = userResponse.Data.Name;
            Assert.AreEqual(requestData.Name, userName);

            var userJob = userResponse.Data.Job;
            Assert.AreEqual(requestData.Job, userJob);

            int amountOfUserAfterCreation = REST.Users.GetUsers().Total;
            //Assert.Less(amountOfUserBeforeCreation, amountOfUserAfterCreation);
        }

        [Test]
        public void UpdateUser()
        {
            UserRequest requestData = new UserRequest
            {
                Name = "newName",
                Job = "newJob"
            };

            var userResponsePUT = REST.Users.UpdateUser(2, requestData);
            var userResponsePATCH = REST.Users.UpdateUser(2, requestData, Method.PATCH);

            var actualStatusCodePUT = userResponsePUT.StatusCode;
            var actualStatusCodePATCH = userResponsePATCH.StatusCode;
        }
    }
}
