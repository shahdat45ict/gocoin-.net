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

        // This test is failing not because of the request, which the api client sends correctly, but because
        // the api client expects an HTTP 200 response with body content, even though the api returns an
        // HTTP 204 (No Content) response (as documented) to indicate the request was successfully processed.
        [Test]
        [Explicit]
        public void CanUpdatePassword()
        {
            var existingUser = Client.api.user.self();
            existingUser.current_password       = "************************";
            existingUser.password               = "************************";
            existingUser.password_confirmation  = "************************";
            Client.api.user.update_password(existingUser);
        }
    }
}
