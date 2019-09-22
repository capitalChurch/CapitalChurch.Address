using System.Linq;
using CapitalChurch.Address.Data;
using CapitalChurch.Address.IntegrationTests.Infrastructure;
using NUnit.Framework;
using Shouldly;

namespace CapitalChurch.Address.IntegrationTests.Data
{
    public class AddressContextMappingTests : BaseTests
    {
        private readonly AddressContext _target;
        
        public AddressContextMappingTests()
        {
            _target = GetService<AddressContext>();
        }

        [Test]
        public void AddressTest()
        {
            var target = _target.Addresses.ToList();

            target.Count().ShouldBePositive();
            target.ForEach(x =>
            {
                x.Id.ShouldBePositive();
                x.AddressLine.ShouldNotBeNullOrEmpty();
                x.Neighborhood.ShouldNotBeNullOrEmpty();
                x.City.ShouldNotBeNullOrEmpty();
                x.State.ShouldNotBeNullOrEmpty();
            });
        }
    }
}