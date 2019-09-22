namespace CapitalChurch.Address.WebApi.V1.Models
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        
        public int PostalCode { get; set; }

        public string AddressLine { get; set; }

        public string Complement { get; set; }

        public string Number { get; set; }
        
        public string ReferencePlace { get; set; }
        
        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
        
        public double? Latitude { get; set; }
        
        public double? Longitude { get; set; }

        public static implicit operator Domain.Model.Address(AddressViewModel model) => new Domain.Model.Address
        {
            Id = model.Id,
            PostalCode = model.PostalCode,
            AddressLine = model.AddressLine,
            Complement = model.Complement,
            Number = model.Number,
            ReferencePlace = model.ReferencePlace,
            Neighborhood = model.Neighborhood,
            City = model.City,
            State = model.State,
            Country = model.Country,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
        };

        public static implicit operator AddressViewModel(Domain.Model.Address model) => new AddressViewModel
        {
            Id = model.Id,
            PostalCode = model.PostalCode,
            AddressLine = model.AddressLine,
            Complement = model.Complement,
            Number = model.Number,
            ReferencePlace = model.ReferencePlace,
            Neighborhood = model.Neighborhood,
            City = model.City,
            State = model.State,
            Country = model.Country,
            Latitude = model.Latitude,
            Longitude = model.Longitude,
        };

    }
}