using System.Threading.Tasks;
using CapitalChurch.Address.IntegrationTests.WebApi.Base;
using CapitalChurch.Address.IntegrationTests.WebApi.Models;
using CapitalChurch.Shared.Extensions;
using NUnit.Framework;
using Shouldly;

namespace CapitalChurch.Address.IntegrationTests.WebApi
{
    public class AddressControllerTests : BaseControllerTests
    {
        [Test]
        public async Task InsertAddress()
        {
            var url = "/v1/address";
            var address = new
            {
                AddressLine = "Chac 129 Lote",
                Number = "15",
                City = "Taguatinga",
                Neighborhood = "SHS Vicente Pires",
                State = "Distrito Federal",
                PostalCode = 72001800,
            };

            var result = await base._client.Post<HasIdTestModel>(url, address);

            result.Id.ShouldBePositive();
        }
    }
}