using Microsoft.Extensions.DependencyInjection;

namespace CapitalChurch.Address.Shared.Contracts
{
    public interface IDependencyProvider
    {
        ServiceCollection ListAll();
    }
}