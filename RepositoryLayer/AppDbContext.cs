using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions con): base(con) 
        {
        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
       // public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
/*            modelBuilder.Entity<UserAddress>()
                .HasKey(u => new { u.UserId, u.AddressId });


                    modelBuilder.Entity<User>()
            .HasMany<Order>(g => g.Orders)
            .WithOne(s => s.User)
            .HasForeignKey(s => s.UserId);

                    modelBuilder.Entity<Restaurant>()
             .HasMany<Order>(o => o.Orders)
             .WithOne(r => r.Restaurant)
             .HasForeignKey(o => o.RestaurantId);*/

        }
    }

   }

