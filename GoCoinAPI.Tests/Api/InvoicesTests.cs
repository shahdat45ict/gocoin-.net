using NUnit.Framework;

namespace GoCoinAPI.Tests.Api
{
    [TestFixture]
    public class InvoicesTests : ApiTestsBase
    {
        private const string InvoiceId = "c265772f-18be-47db-a14b-ed28db228673";

        // This test is failing with an HTTP 404 Not Found response, but the url looks fine according to
        // the documentation (http://docs.gocoinapi.apiary.io/#invoices), /merchants/:id/invoices.
        [Test]
        public void CanCreate()
        {
            var invoice = new Invoices
                {
                    price_currency = "BTC",
                    base_price = 134.00f,
                    base_price_currency = "USD",
                    confirmations_required = 6,
                    notification_level = "all",
                    callback_url = "https://www.example.com/gocoin/callback",
                    redirect_url = "https://www.example.com/redirect"
                };
            var result = Client.api.invoices.create(User.merchant_id, invoice);
            Assert.IsNotNullOrEmpty(result.id);
        }

        [Test]
        public void CanGet()
        {
            var result = Client.api.invoices.get(InvoiceId);
            Assert.AreEqual(InvoiceId, result.id);
        }

        // I am receiving an HTTP 401 Unauthorized response, even though the token has both invoice_read
        // and invoice_read_write OAuth Scopes. Nevertheless, the search method is returning just one instance
        // of the Invoices class, but it should return a collection instead.
        //[Test]
        //public void CanSearch()
        //{
        //    var client = new Client { token = accessToken };
        //    var user = client.api.user.self();
        //    var result = client.api.invoices.search("merchant_id=" + user.merchant_id);
        //    Assert.Greater(result.Count, 0);
        //}
    }
}
