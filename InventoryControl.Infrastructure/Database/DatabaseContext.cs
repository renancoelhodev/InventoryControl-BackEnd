using InventoryControl.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryControl.Infrastructure.Database
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }
    }
}