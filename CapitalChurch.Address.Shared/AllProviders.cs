using System.Collections.Generic;
using System.Linq;
using CapitalChurch.Address.Business;
using CapitalChurch.Address.Data;
using CapitalChurch.Address.Shared.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CapitalChurch.Address.Shared
{
    public static class AllProviders
    {
        private static readonly List<IDependencyProvider> _providers = new List<IDependencyProvider>
        {
            new DataLayerServicesProvider(),
            new BusinessLayerServicesProvider()
        };
        
        public static ServiceCollection All =>
            new ServiceCollection { _providers.SelectMany(x => x.ListAll()) };
    }
}