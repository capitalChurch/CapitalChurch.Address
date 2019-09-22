using AutoMapper;
using CapitalChurch.Address.WebApi.V1.Models;

namespace CapitalChurch.Address.WebApi.Infrastructure
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<AddressViewModel, Domain.Model.Address>();
        }
    }
}