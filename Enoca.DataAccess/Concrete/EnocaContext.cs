using Enoca.Entity.Modals;
using Microsoft.EntityFrameworkCore;

namespace Enoca.DataAccess.Concrete
{
    public class EnocaContext:DbContext
    {
        public EnocaContext() { }

        public EnocaContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<CarrierConfiguration> CarrierConfigurations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-0IN5JO9S;Database=Enoca;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasOne(c => c.Carrier)
                .WithMany(o => o.Orders)
                .HasForeignKey(c => c.CarrierId);

            modelBuilder.Entity<CarrierConfiguration>()
                .HasOne(c => c.Carrier)
                .WithMany(c => c.CarrierConfigurations)
                .HasForeignKey(c => c.CarrierId);
        }
    }
}
