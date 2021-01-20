using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dapper;
using ManyToMany.Configurations;
using ManyToMany.Data;
using ManyToMany.DTOs;
using ManyToMany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Relationships02.DTOs;

namespace ManyToMany.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public ProductController(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public void Create(ProductCreateDTO item)
        {            
            var product = _mapper.Map<Product>(item);
            _context.Add(product);
            _context.SaveChanges();
        }


        // Usando AutoMapper para mapear Model para DTO
        [HttpGet]
        public IEnumerable<ProductDTO> GetAll()
        {
            var products = _context.Product;
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        // Usando Linq para mapear Model para DTO
        [HttpGet]
        public IEnumerable<ProductDTO> GetAll02()
        {
           return from p in _context.Product.ToList()
                            select new ProductDTO()
                            {
                                Id = p.Id,
                                Name = p.Name
                            };           
            
        }

        // Usando Linq Lambda para mapear Model para DTO
        [HttpGet]        
        public IEnumerable<ProductDTO> GetAll03()
        {
            return _context.Product
                .ToList()                           
                .Select(x => new ProductDTO() {
                    Id = x.Id,
                    Name = x.Name
                });
            
        }

        [HttpGet]        
        public IEnumerable<ProductDTO> GetAll04()
        {
            return _context.Product
                .ToList()                           
                .Select(x => new ProductDTO(x));    // <-- lá no construtor do ProductDTO eu aceito um Product                   
        }

        
        // Usando Dapper
        [HttpGet]
        public IEnumerable<ProductDTO> GetAll05()
        {
            var connString = ServicesConfiguration.ConnectionString;                 

            using (var connection = new SqlConnection(connString))
            {
                return connection.Query<ProductDTO>("select * from Product");
            }
        }


        [HttpPut("{id}")]
        public void Update(Guid id, ProductUpdateDTO item)
        {             
            if (id != item.Id) 
                return;
                
            var product = _mapper.Map<Product>(item);         
            _context.Update(product);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Update02(Guid id, ProductUpdateDTO item)
        {             
            if (id != item.Id) 
                return;
                
            var product = new Product();
            product.Id = item.Id;
            product.Name = item.Name;
            
            _context.Update(product);
            _context.SaveChanges();
        }


        
    }
}