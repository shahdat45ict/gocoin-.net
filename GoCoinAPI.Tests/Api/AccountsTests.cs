using NUnit.Framework;

namespace GoCoinAPI.Tests.Api
{
    [TestFixture]
    public class AccountsTests
    {
        private const string accessToken = "8c1618e67b7425e66413cfdcf4f790ce853e5b6dd184d9f333293f833b4cfdac";

        [Test]
        public void CanList()
        {
            var client = new Client {token = accessToken};
            var user = client.api.user.self();
            var result = client.api.accounts.alist(user.merchant_id);
            Assert.Greater(result.Count, 0);
        }

        // The Accounts class of this api client implements the create method, but the api doesn't document this
        // operation for the Accounts resource, so we are receiving a 404 Not Found HTTP response for the below
        // test. The Accounts class of this api client has methods for other undocumented operations too, so I
        // don't test them as well, for now.
        //[Test]
        //public void CanCreate()
        //{
        //    var client = new Client { token = accessToken };
        //    var user = client.api.user.self();
        //    var newAccount = new Accounts(client.api)
        //        {
        //            balance = "1",
        //            currency_code = "USD",
        //            merchantid = user.merchant_id
        //        };
        //    var result = client.api.accounts.create(newAccount);
        //    Assert.IsNotNullOrEmpty(result.id);
        //}
    }
}
