using CapitalChurch.Address.IntegrationTests.Infrastructure;
using CapitalChurch.Address.Shared.Contracts.Repository;
using NUnit.Framework;
using Shouldly;

namespace CapitalChurch.Address.IntegrationTests.Data.core
{
    public class AddressRepositoryTests : BaseTests
    {
        private readonly IAddressRepository _target;

        public AddressRepositoryTests()
        {
            _target = GetService<IAddressRepository>();
        }

        [Test]
        public void InsertTest()
        {
            var expected = new Domain.Model.Address
            {
                City = "Taguatinga",
                Complement = "EPCT",
                AddressLine = "QS 07 Lote",
                Number = "01",
                State = "Distrito Federal",
                PostalCode = 71966700,
                ReferencePlace = "Na frente do pistão sul",
                Country = "Brasil",
                Neighborhood = "Taguatinga Sul",
                Latitude = -15.8675561,
                Longitude = -48.0309839,
            };

            var newObj = _target.Insert(expected);
            
            newObj.Id.ShouldBePositive();
        }
    }
}