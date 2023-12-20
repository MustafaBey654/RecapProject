

using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using User = Core.Entities.Concrete.User;




namespace Core.DataAccess.Eframework
{
    public class EfDbContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = 192.168.255.1;Database=RecapDb;User ID=SA;Password=password1;TrustServerCertificate=True");
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
       
        public DbSet<Rental> Rentals { get; set;}
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarImage> CarImages { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
