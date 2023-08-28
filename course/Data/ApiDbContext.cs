using Microsoft.EntityFrameworkCore;
using course.Models;
namespace course.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string connectionString = @"Server = (localdb)\ProjectModels; Database = RealEstateDb;";
            string connectionString = @"Server = (localdb)\Local; Database = RealEstateDb;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    
}

