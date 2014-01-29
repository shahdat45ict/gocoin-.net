using NUnit.Framework;

namespace GoCoinAPI.Tests.Api
{
    [TestFixture]
    public class MerchantTests : ApiTestsBase
    {
        [Test]
        public void CanGet()
        {
            var result = Client.api.merchants.get(User.merchant_id);
            Assert.AreEqual(User.merchant_id, result.id);
        }

        [Test]
        public void CanUpdate()
        {
            var existingMerchant = Client.api.merchants.get(User.merchant_id);
            var result = Client.api.merchants.update(existingMerchant);
            Assert.AreEqual(User.merchant_id, result.id);
        }
    }
}
