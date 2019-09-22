using System;
using CapitalChurch.Address.Shared;
using CapitalChurch.Address.Shared.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Moq;
using NUnit.Framework;

namespace CapitalChurch.Address.IntegrationTests.Infrastructure
{
    [TestFixture]
    public class BaseTests
    {
        private readonly ServiceProvider _serviceProvider;

        private readonly string DefaultConnection =
            "Host=localhost;Port=5432;Username=address;Password=@Qualidade2#!;Database=capitalChurch;";
        
        protected BaseTests()
        {
            var configurationSection = new Mock<IConfigurationSection>();
            configurationSection.SetupGet(x => x[It.Is<string>(s => s == EnvironmentConstants.AddressConnectionString)])
                .Returns(DefaultConnection);

            var configuration = new Mock<IConfiguration>();
            configuration.Setup(a => a.GetSection(It.Is<string>(s => s == EnvironmentConstants.ConnectionStrings)))
                .Returns(configurationSection.Object);

            var services = new AddressProviders(configuration.Object);
            
            _serviceProvider = new ServiceCollection().Add(services).BuildServiceProvider();
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