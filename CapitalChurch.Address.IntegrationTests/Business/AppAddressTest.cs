using CapitalChurch.Address.IntegrationTests.Infrastructure;
using CapitalChurch.Address.Shared.Contracts.Business;
using NUnit.Framework;
using Shouldly;

namespace CapitalChurch.Address.IntegrationTests.Business
{
    public class AppAddressTest : BaseTests
    {
        private readonly IAppAddress _target;
        
        public AppAddressTest()
        {
            _target = GetService<IAppAddress>();
        }

        [Test]
        public void CreateTest()
        {
            var obj = _target.Create(GetBasicAddress());
            
            obj.Id.ShouldBePositive();
            obj.Point.ShouldBeNull();


            obj = GetBasicAddress();
            
            obj.Latitude = -15.8535217;
            obj.Longitude = -48.0323616;
            
            obj = _target.Create(obj);
            obj.Id.ShouldBePositive();
            obj.Point.ShouldNotBeNull();
        }
        
        private Domain.Model.Address GetBasicAddress() => new Domain.Model.Address
        {
            City = "Taguatinga",
            Neighborhood = "Taguatinga Centro",
            AddressLine = "CSB 1 Lote 13",
            Complement = "Apartamento",
            Number = "233",
            State = "Brasilia",
        };
    }
}