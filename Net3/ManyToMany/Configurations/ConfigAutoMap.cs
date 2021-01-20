using AutoMapper;
using ManyToMany.DTOs;
using ManyToMany.Models;
using ManyToMany.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace ManyToMany.Configurations
{
    public static partial class ServicesConfiguration
    {
        public static void ConfigAutoMap(this IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {                                                              
                cfg.CreateMap<OrderCreateDTO, Order>();
                cfg.CreateMap<OrderCreateDTO02, Order>();
                cfg.CreateMap<OrderCreateDTO03, Order>();
                cfg.CreateMap<OrderDTO, Order>();                
                cfg.CreateMap<Order, OrderCreateDTO>();
                cfg.CreateMap<Order, OrderDTO>();
                                                    
                cfg.CreateMap<ProductCreateDTO, Product>(); 
                cfg.CreateMap<ProductUpdateDTO, Product>(); 
                cfg.CreateMap<Product, ProductCreateDTO>(); 
                cfg.CreateMap<Product, ProductUpdateDTO>();                
                cfg.CreateMap<Product, ProductDTO>(); 
                cfg.CreateMap<ProductDTO, Product>(); 

                cfg.CreateMap<OrderProductCreateDTO, OrderProduct>(); 
                cfg.CreateMap<OrderProductDTO, OrderProduct>();
                cfg.CreateMap<OrderProduct, OrderProductDTO>();

                cfg.CreateMap<Product, ProductViewModel>();
                                                   
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }   
    }
}