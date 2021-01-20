using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace OneToMany.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API",
                    Description = "NET Core 3.1 - One To Many",
                    Contact = new OpenApiContact
                    {
                        Name = "Vitor Moschetta",
                        Email = "vitormoschetta@gmail.com"
                    }
                });
            });
        }   
    }
}