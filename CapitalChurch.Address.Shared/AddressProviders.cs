using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CapitalChurch.Address.Business;
using CapitalChurch.Address.Data;
using CapitalChurch.Address.Shared.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace CapitalChurch.Address.Shared
{
    public class AddressProviders : IEnumerable<ServiceDescriptor>
    {
        private readonly List<IDependencyProvider> _providers;

        public AddressProviders(IConfiguration configuration)
        {
            _providers = new List<IDependencyProvider>
            {
                new DataLayerServicesProvider(configuration),
                new BusinessLayerServicesProvider()
            };
        }

        public IEnumerator<ServiceDescriptor> GetEnumerator() =>
            new ServiceCollection {_providers.SelectMany(x => x.ListAll())}.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}