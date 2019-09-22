using NetTopologySuite.Geometries;

namespace CapitalChurch.Address.Domain.Model
{
    public class Address
    {
        public int Id { get; set; }

        public int PostalCode { get; set; }

        public string AddressLine { get; set; }

        public string Complement { get; set; }

        public string Number { get; set; }

        /// <summary>
        /// Popular near by place to be easy to found the address
        /// </summary>
        public string ReferencePlace { get; set; }
        
        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }
        
        public double? Latitude { get; set; }
        
        public double? Longitude { get; set; }
        
        public Point Point { get; set; }
        
        public Geometry Shape { get; set; }
    }
}