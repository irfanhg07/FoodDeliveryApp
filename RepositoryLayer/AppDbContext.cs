using DomainLayer.Entity;
using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;


namespace RepositoryLayer
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions con): base(con) 
        {
        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAddress>()
                   .HasKey(ua => new { ua.UserId, ua.AddressId }); // Define composite primary key

            // Relation between user and address(many to many)
            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAddresses)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserAddress>()
                .HasOne(ua => ua.Address)
                .WithMany(a => a.UserAddresses)
                .HasForeignKey(ua => ua.AddressId);

            // Relation between order and MenuItem(many to many)

            modelBuilder.Entity<OrderDetails>()
                  .HasKey(ua => new { ua.OrderId, ua.MenuItemId }); // Define composite primary key
            modelBuilder.Entity<OrderDetails>()
            .HasOne(o => o.Order)
            .WithMany(u => u.orderDetails)
            .HasForeignKey(o => o.OrderId)
            .IsRequired();

            modelBuilder.Entity<OrderDetails>()
               .HasOne(ua => ua.menuItem)
               .WithMany(u => u.OrderDetails)
               .HasForeignKey(ua => ua.MenuItemId);


    


        }
    }

   }

