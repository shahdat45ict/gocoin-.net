using NUnit.Framework;

namespace GoCoinAPI.Tests.Api
{
    [TestFixture]
    public class AccountsTests : ApiTestsBase
    {
        [Test]
        public void CanList()
        {
            var result = Client.api.accounts.alist(User.merchant_id);
            Assert.Greater(result.Count, 0);
        }
    }
}
