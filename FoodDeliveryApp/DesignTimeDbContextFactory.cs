/*using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;

namespace FoodDeliveryApp
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=Food_Delivery_DB;Username=postgres;Password=Rajeev@123;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
*/