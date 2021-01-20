using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ManyToMany.Data;
using ManyToMany.DTOs;
using ManyToMany.Models;
using Microsoft.AspNetCore.Mvc;

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
        

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _context.Product;
        } 


        [HttpPut]
        public void Update(Guid id, ProductUpdateDTO item)
        {            
            var product = _mapper.Map<Product>(item);
            _context.Update(product);
            _context.SaveChanges();
        }


        [HttpDelete]
        public void Delete(Guid id)
        {            
            var item = _context.Product.FirstOrDefault(x => x.Id == id);
            _context.Remove(item);
            _context.SaveChanges();
        }
      
    }
}