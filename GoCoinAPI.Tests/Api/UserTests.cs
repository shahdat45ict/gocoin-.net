using NUnit.Framework;

namespace GoCoinAPI.Tests.Api
{
    [TestFixture]
    public class UserTests : ApiTestsBase
    {
        // This test is failing because of an HTTP 404 Not Found response. Nevertheless, the list method
        // is returning just one instance of the User class, but it should return a collection instead,
        // and this is why I leave the last line of this test commented out, because it doesn't compile.
        [Test]
        public void CanList()
        {
            var result = Client.api.user.list();
            //Assert.Greater(result.Count, 0);
        }

        // This test is failing because of an HTTP 404 Not Found response.
        [Test]
        public void CanCreate()
        {
            var result = CreateTestUser();
            Assert.AreEqual("dd456fd9-9928-4649-89d2-379368787845", result.id);
        }

        [Test]
        public void CanGet()
        {
            var result = Client.api.user.get("c8076c0f-af3e-4b92-a03f-32a7d8d35fb4");
            Assert.AreEqual("c8076c0f-af3e-4b92-a03f-32a7d8d35fb4", result.id);
        }

        [Test]
        public void CanGetResourceOwner()
        {
            var result = Client.api.user.self();
            Assert.AreEqual("c8076c0f-af3e-4b92-a03f-32a7d8d35fb4", result.id);
        }

        [Test]
        public void CanUpdate()
        {
            var existingUser = User;
            var result = Client.api.user.update(existingUser);
            Assert.AreEqual(existingUser.id, result.id);
        }

        // This test is failing because I need to create a new user before deleting it, but creation
        // isn't working, see CanList() comments. Moreover, the delete method is returning an instance of
        // the User class, but it should return void according to the api docs
        // (http://docs.gocoinapi.apiary.io/#merchants) of the delete operation.
        [Test]
        public void CanDelete()
        {
            var createdMerchant = CreateTestUser();
            Client.api.user.delete(createdMerchant);
        }

        // I can't write this test without being able to create new users unless I hardcode my user
        // password into it, which I'd rather not.
        //[Test]
        //public void CanUpdatePassword()
        //{
        //    ...
        //    var result = Client.api.user.update_password(existingUserWithCurrentAndNewPassword);
        //}

        // I can't write this test without being able to create new users or else I would get my user's
        // password reset.
        //[Test]
        //public void CanRequestPasswordReset()
        //{
        //    ...
        //    Client.api.user.request_password_reset(existingUser);
        //}

        // I can't find how to get the reset token. If it's sent in an email I won't be able to test it 
        // at all.
        //[Test]
        //public void CanResetPassword()
        //{
        //    ...
        //    Client.api.user.reset_password(existingUser, resetToken);
        //}

        // This test is failing because of an HTTP 500 Internal Server Error, probably because the api
        // generates an incorrect url, without the slash between user_id and applications,
        // ie: /users/:user_idapplications. Anyway, the get_applications_for_user method is returning
        // a User which doesn't seem right, but the /users/:user_id/applications response isn't
        // documented in the api docs (http://docs.gocoinapi.apiary.io/#users)
        //[Test]
        //public void CanGetApplicationsForUser()
        //{
        //    Client.api.user.get_applications_for_user(User.id);
        //}

        private User CreateTestUser()
        {
            var newUser = new User(Client.api)
                              {
                                  id = "dd456fd9-9928-4649-89d2-379368787845",
                                  email = "user@gocoin.com",
                                  first_name = "GoCoin",
                                  last_name = "User",
                              };
            var result = Client.api.user.create(newUser);
            return result;
        }
    }
}
