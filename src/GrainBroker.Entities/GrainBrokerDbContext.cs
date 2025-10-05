using Microsoft.EntityFrameworkCore;

namespace GrainBroker.Entities
{
    public class GrainBrokerDbContext : DbContext
    {
        public GrainBrokerDbContext(DbContextOptions<GrainBrokerDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderFulfillment> OrderFulfillments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-many relationship between Customer and Orders
            //modelBuilder.Entity<Customer>()
            //    //.HasMany(c => c.Orders)
            //   // .WithOne(o => o.Customer)
            //    .HasForeignKey(o => o.CustomerId)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-many relationship between Supplier and OrderFulfillments
            modelBuilder.Entity<Supplier>()
                .HasMany(s => s.Fulfillments)
                .WithOne(f => f.Supplier)
                .HasForeignKey(f => f.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure one-to-one relationship between Order and OrderFulfillment
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Fulfillment)
                .WithOne(f => f.Order)
                .HasForeignKey<OrderFulfillment>(f => f.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure decimal properties
            modelBuilder.Entity<Order>()
                .Property(o => o.RequestedGrainAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderFulfillment>()
                .Property(f => f.SuppliedAmount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderFulfillment>()
                .Property(f => f.CostOfDelivery)
                .HasColumnType("decimal(18,2)");

            // Initialize collections in entity constructors
            modelBuilder.Entity<Customer>()
                .HasData(new Customer { Id = Guid.NewGuid(),CustomerName = "ABC", CustomerLocation = "Cincinatti" });

            modelBuilder.Entity<Supplier>()
                .HasData(new Supplier { Id = Guid.NewGuid(),SupplierName="XYZ", SupplierLocation = "Omaha" });
        }
    }
}