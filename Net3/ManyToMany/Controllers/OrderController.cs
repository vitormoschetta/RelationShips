using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dapper;
using ManyToMany.Configurations;
using ManyToMany.Data;
using ManyToMany.DTOs;
using ManyToMany.Models;
using ManyToMany.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ManyToMany.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public OrderController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        // cadastra apenas o pedido
        [HttpPost]
        public void Create(OrderCreateDTO item)
        {
            var order = _mapper.Map<Order>(item);
            _context.Add(order);
            _context.SaveChanges();
        }


        // cadastra pedido e lista de produtos de uma só vez
        [HttpPost]
        public void Create02(OrderCreateDTO02 item)
        {
            var order = _mapper.Map<Order>(item);

            _context.Add(order);
            _context.SaveChanges();

            foreach (var product in item.Products)
            {
                var newProduct = new Product(product.Name);
                _context.Add(newProduct);
                _context.SaveChanges();

                var orderProduct = new OrderProduct(order.Id, newProduct.Id);
                _context.Add(orderProduct);
                _context.SaveChanges();
            }
                        
        }


        // cadastra pedido com produtos já existentes
        [HttpPost]
        public void Create03(OrderCreateDTO03 item)
        {
            var order = _mapper.Map<Order>(item);

            _context.Add(order);
            _context.SaveChanges();

            foreach (var product in item.Products)
            {              
                var orderProduct = new OrderProduct(order.Id, product.Id);
                _context.Add(orderProduct);
                _context.SaveChanges();
            }
                        
        }


        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return _context.Order
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product);
        }


        [HttpGet]
        public IEnumerable<OrderDTO> GetAll02()
        {
            var orders =  _context.Order
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product);

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);
        }


        [HttpGet]
        public dynamic GetAll03()
        {
            var connString = ServicesConfiguration.ConnectionString;

            var query = string.Empty;
            query += "select O.Id, O.Date, P.Id as ProductId, P.Name as ProductName ";
            query += "from [Order] as O ";
            query += "inner join OrderProduct as OP ";
            query += "on O.Id = OP.OrderId ";
            query += "inner join Product as P ";
            query += "on P.Id = OP.ProductId ";


            using (var connection = new SqlConnection(connString))
            {
                return connection.Query(query);
            }
        }


        [HttpGet]
        public IEnumerable<OrderViewModel> GetAll04()
        {
            var orders = _context.Order
                .Include(x => x.OrderProducts)
                .ThenInclude(x => x.Product);

            var list = new List<OrderViewModel>();
            
            foreach (var item in orders)
            {
                var orderViewModel = new OrderViewModel();
                orderViewModel.Id = item.Id;
                orderViewModel.Date = item.Date;

                var products = item.OrderProducts.Select(x => x.Product).ToList();

                orderViewModel.Products = _mapper.Map<List<ProductViewModel>>(products);

                list.Add(orderViewModel);
            }

            return list;

        }
    }

}