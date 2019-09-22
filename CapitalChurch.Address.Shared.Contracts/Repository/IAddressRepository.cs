namespace CapitalChurch.Address.Shared.Contracts.Repository
{
    public interface IAddressRepository
    {
        Domain.Model.Address Insert(Domain.Model.Address obj);
    }
}