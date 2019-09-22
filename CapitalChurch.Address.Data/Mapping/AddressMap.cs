using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CapitalChurch.Address.Data.Mapping
{
    public class AddressMap : IEntityTypeConfiguration<Domain.Model.Address>
    {
        public void Configure(EntityTypeBuilder<Domain.Model.Address> builder)
        {
            builder.ToTable("address", "addresses");

            #region Keys

            builder.HasKey(x => x.Id);

            #endregion

            #region Properties

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.PostalCode)
                .HasColumnName("postalcode");

            builder.Property(x => x.AddressLine)
                .HasColumnName("addressline");

            builder.Property(x => x.Complement)
                .HasColumnName("complement");

            builder.Property(x => x.Number)
                .HasColumnName("number");

            builder.Property(x => x.ReferencePlace)
                .HasColumnName("referenceplace");

            builder.Property(x => x.Neighborhood)
                .HasColumnName("neighborhood");

            builder.Property(x => x.City)
                .HasColumnName("city");

            builder.Property(x => x.State)
                .HasColumnName("state");

            builder.Property(x => x.Country)
                .HasColumnName("country");

            builder.Property(x => x.Latitude)
                .HasColumnName("lat");

            builder.Property(x => x.Longitude)
                .HasColumnName("long");

            builder.Property(x => x.Point)
                .HasColumnName("point");

            builder.Property(x => x.Shape)
                .HasColumnName("shape");

            #endregion
        }
    }
}