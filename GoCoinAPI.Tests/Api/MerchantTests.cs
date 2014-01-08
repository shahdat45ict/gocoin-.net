using NUnit.Framework;

namespace GoCoinAPI.Tests.Api
{
    [TestFixture]
    public class MerchantTests : ApiTestsBase
    {
        // This test is failing because of an HTTP 404 Not Found response. Nevertheless, the list method
        // is returning just one instance of the Merchant class, but it should return a collection instead,
        // and this is why I leave the last line of this test commented out, because it doesn't compile.
        [Test]
        public void CanList()
        {
            var result = Client.api.merchants.list();
        //    Assert.Greater(result.Count, 0);
        }

        // This test is failing because of an HTTP 404 Not Found.
        [Test]
        public void CanCreate()
        {
            var result = CreateTestMerchant();
            Assert.IsNotNullOrEmpty(result.id);
        }

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

        // This test is failing because I need to create a new merchant before deleting it, but creation
        // isn't working, see CanList(). Moreover, the delete method is an instance of the Merchant class,
        // but it should return void according to the api docs (http://docs.gocoinapi.apiary.io/#merchants)
        // of the delete operation.
        [Test]
        public void CanDelete()
        {
            var createdMerchant = CreateTestMerchant();
            Client.api.merchants.delete(createdMerchant);
        }

        private Merchant CreateTestMerchant()
        {
            var newMerchant = new Merchant(Client.api)
                                  {
                                      name = "Blingin' Merchant",
                                      address_1 = "123 Main St.",
                                      address_2 = "Suite 1",
                                      city = "Los Angeles",
                                      region = "CA",
                                      country_code = "US",
                                      postal_code = "90000",
                                      contact_name = "Bling McBlingerton",
                                      phone = "1-555-555-5555",
                                      website = "http://www.blinginmerchant.com",
                                      description = "Some description.",
                                      tax_id = "000000"
                                  };
            var result = Client.api.merchants.create(newMerchant);
            return result;
        }
    }
}
