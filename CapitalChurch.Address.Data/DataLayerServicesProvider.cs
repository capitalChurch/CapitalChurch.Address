using CapitalChurch.Address.Data.Core;
using CapitalChurch.Address.Shared.Contracts;
using CapitalChurch.Address.Shared.Contracts.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CapitalChurch.Address.Data
{
    public class DataLayerServicesProvider : IDependencyProvider
    {
        public ServiceCollection ListAll()
        {
            var services = new ServiceCollection();
            
            services.AddTransient<IAddressRepository, AddressRepository>();
            
            return services;
        }
    }
}