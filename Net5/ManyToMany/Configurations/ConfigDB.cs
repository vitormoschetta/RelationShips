using ManyToMany.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ManyToMany.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigDB(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(ConnectionString));
        }   

        public static string ConnectionString => "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=NET5ManyToMany;";
    }
}