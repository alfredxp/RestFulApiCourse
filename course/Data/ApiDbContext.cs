using Microsoft.EntityFrameworkCore;
using course.Models;
namespace course.Data
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server = (localdb)\ProjectModels; Database = RealEstateDb;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    
}
