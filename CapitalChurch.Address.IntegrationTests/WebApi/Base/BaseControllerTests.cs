using System.Net.Http;
using NUnit.Framework;

namespace CapitalChurch.Address.IntegrationTests.WebApi.Base
{
    public class BaseControllerTests
    {
        protected HttpClient _client;

        [OneTimeSetUp]
        public void SetupTests()
        {
            _client = new AddressFixture().CreateClient();
        }
    }
}