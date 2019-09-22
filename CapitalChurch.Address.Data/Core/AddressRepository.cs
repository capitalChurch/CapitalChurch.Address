using CapitalChurch.Address.Shared.Contracts.Repository;

namespace CapitalChurch.Address.Data.Core
{
    public class AddressRepository : IAddressRepository
    {
        private readonly AddressContext _context;

        public AddressRepository(AddressContext context)
        {
            _context = context;
        }

        public Domain.Model.Address Insert(Domain.Model.Address obj)
        {
            _context.Addresses.Add(obj);
            _context.SaveChanges();
            return obj;
        }
    }
}