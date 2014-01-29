using NUnit.Framework;

namespace GoCoinAPI.Tests.Api
{
    public class ApiTestsBase
    {
        private const string AccessToken = "YOUR ACCESS TOKEN HERE";
        protected Client Client;
        protected User User;

        [SetUp]
        public void SetUp()
        {
            Client = new Client { token = AccessToken };
            User = Client.api.user.self();
        }
    }
}
