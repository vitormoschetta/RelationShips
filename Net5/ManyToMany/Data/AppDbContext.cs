using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }       

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }               

    }
}