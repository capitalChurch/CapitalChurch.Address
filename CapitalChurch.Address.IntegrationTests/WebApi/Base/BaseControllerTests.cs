using System;
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
            var client = new AddressFixture().CreateClient();
            client.BaseAddress = new Uri($"{client.BaseAddress}endereco/");
            _client = client;
        }
    }
}