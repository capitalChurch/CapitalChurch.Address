using CapitalChurch.Address.Shared.Contracts.Business;
using CapitalChurch.Address.Shared.Contracts.Repository;
using NetTopologySuite.Geometries;

namespace CapitalChurch.Address.Business
{
    public class AppAddress : IAppAddress
    {
        private readonly IAddressRepository _repository;

        public AppAddress(IAddressRepository repository)
        {
            _repository = repository;
        }
        
        public Domain.Model.Address Create(Domain.Model.Address obj)
        {
            if(obj.Latitude.HasValue && obj.Longitude.HasValue)
                obj.Point = new Point(obj.Latitude.Value, obj.Longitude.Value);
            
            return _repository.Insert(obj);
        }
    }
}