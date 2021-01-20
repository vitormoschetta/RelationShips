using AutoMapper;
using ManyToMany.DTOs;
using ManyToMany.Models;
using Microsoft.Extensions.DependencyInjection;
using Relationships02.DTOs;

namespace ManyToMany.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigAutoMap(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {                                
                cfg.CreateMap<Order, OrderDTO>();                                              
                cfg.CreateMap<OrderCreateDTO, Order>();   
                cfg.CreateMap<OrderCreateDTO02, Order>(); 
                cfg.CreateMap<OrderCreateDTO03, Order>(); 
                cfg.CreateMap<OrderUpdateDTO, Order>();   

                cfg.CreateMap<Product, ProductDTO>();
                cfg.CreateMap<ProductCreateDTO, Product>();
                cfg.CreateMap<ProductUpdateDTO, Product>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }   
    }
}