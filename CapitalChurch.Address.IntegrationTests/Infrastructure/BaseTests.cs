using System;
using CapitalChurch.Address.Data;
using CapitalChurch.Address.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace CapitalChurch.Address.IntegrationTests.Infrastructure
{
    [TestFixture]
    public class BaseTests
    {
        private readonly ServiceProvider _serviceProvider;
        
        protected BaseTests()
        {
            var services = AllProviders.All;
            services.AddTransient<AddressContext>(_ =>
            {
                var builder = new DbContextOptionsBuilder<AddressContext>();
                builder.UseNpgsql(DatabaseConstants.ConnectionString, o => o.UseNetTopologySuite());
                return new AddressContext(builder.Options);
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected TResult GetService<TResult>() where TResult : class
        {
            var result = _serviceProvider.GetService<TResult>();
            
            if(result == default)
                throw new Exception($"Service not registered {typeof(TResult).Name}");

            return result;
        }
    }
}