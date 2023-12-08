using Microsoft.EntityFrameworkCore;
using E_Commerce.Models;
namespace E_Commerce.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet <Products> Products { get; set; }
    }
}
