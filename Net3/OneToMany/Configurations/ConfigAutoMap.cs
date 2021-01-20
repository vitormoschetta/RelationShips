using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OneToMany.DTOs;
using OneToMany.Models;

namespace OneToMany.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigAutoMap(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {                               
                cfg.CreateMap<Team, TeamDTO>();                                
                cfg.CreateMap<TeamCreateDTO, Team>();  
                cfg.CreateMap<TeamUpdateDTO, Team>();      

                cfg.CreateMap<Player, PlayerDTO>();        
                cfg.CreateMap<PlayerCreateDTO, Player>();    
                cfg.CreateMap<PlayerUpdateDTO, Player>();                            
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }   
    }
}