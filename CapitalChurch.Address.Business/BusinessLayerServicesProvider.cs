using CapitalChurch.Address.Shared.Contracts;
using CapitalChurch.Address.Shared.Contracts.Business;
using Microsoft.Extensions.DependencyInjection;

namespace CapitalChurch.Address.Business
{
    public class BusinessLayerServicesProvider : IDependencyProvider
    {
        public ServiceCollection ListAll()
        {
            var services = new ServiceCollection();
            
            services.AddTransient<IAppAddress, AppAddress>();
            
            return services;
        }
    }
}