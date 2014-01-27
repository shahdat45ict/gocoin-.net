using NUnit.Framework;

namespace GoCoinAPI.Tests.Api
{
    [TestFixture]
    public class UserTests : ApiTestsBase
    {
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

        //Set a valid password for the user befor run this test. 
        [Test]
        public void CanUpdatePassword()
        {
            var existingUser = Client.api.user.self();
            existingUser.current_password       = "*******";
            existingUser.password               = "*******";
            existingUser.password_confirmation  = "*******";
            Client.api.user.update_password(existingUser);
        }
    }
}
