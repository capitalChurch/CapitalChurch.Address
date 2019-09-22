using CapitalChurch.Address.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CapitalChurch.Address.Data
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options)
            : base(options)
        {}
        
        public virtual DbSet<Domain.Model.Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AddressMap());

            modelBuilder.HasPostgresExtension("postgis");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}