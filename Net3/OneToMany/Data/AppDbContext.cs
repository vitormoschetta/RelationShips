using Microsoft.EntityFrameworkCore;
using OneToMany.Models;

namespace OneToMany.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        
        public DbSet<Team> Team { get; set; }
        public DbSet<Player> Player { get; set; }
        public object First { get; internal set; }
    }
}