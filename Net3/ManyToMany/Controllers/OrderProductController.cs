using System.Collections.Generic;
using AutoMapper;
using ManyToMany.Data;
using ManyToMany.DTOs;
using ManyToMany.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderProductController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OrderProductController(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpPost]
        public void Create(OrderProductCreateDTO item)
        {           
            var orderProduct = _mapper.Map<OrderProduct>(item);
            _context.Add(orderProduct);
            _context.SaveChanges();
        }        
        
        

       
        [HttpGet]
        public IEnumerable<OrderProduct> GetAll()
        {
            return _context.OrderProduct;           
        }
    }
}