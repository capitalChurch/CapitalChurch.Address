using System;
using CapitalChurch.Address.Data.Core;
using CapitalChurch.Address.Shared.Contracts;
using CapitalChurch.Address.Shared.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CapitalChurch.Address.Data
{
    public class DataLayerServicesProvider : IDependencyProvider
    {
        private readonly IConfiguration _configuration;

        public DataLayerServicesProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ServiceCollection ListAll()
        {
            var services = new ServiceCollection();

            services.AddDbContext<AddressContext>(opts =>
                opts.UseNpgsql(_configuration[EnvironmentConstants.ConnectionStrings], builder =>
                    builder.UseNetTopologySuite()));
            
            services.AddTransient<IAddressRepository, AddressRepository>();
            
            return services;
        }
    }
}