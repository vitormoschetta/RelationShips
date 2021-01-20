using Microsoft.Extensions.DependencyInjection;

namespace OneToMany.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigJSON(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            
        }   
    }
}