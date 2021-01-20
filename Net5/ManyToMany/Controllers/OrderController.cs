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
using Microsoft.EntityFrameworkCore;
using Relationships02.DTOs;

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


        // cadastrar apenas o pedido
        [HttpPost]
        public void Create(OrderCreateDTO item)
        {
            var order = new Order(item.Date);
            _context.Add(order);
            _context.SaveChanges();
        }


        // cadastrar pedido e produtos em lista
        [HttpPost]
        public void Create02(OrderCreateDTO02 item)
        {
            var order = _mapper.Map<Order>(item);
            _context.Add(order);
            _context.SaveChanges();
        }


        // cadastrar pedido com produtos já existentes ?
        [HttpPost]
        public void Create03(OrderCreateDTO03 item)
        {
            var order = _mapper.Map<Order>(item);

            _context.Add(order); //aqui ele tenta gravar o produto existente e dá erro porq o id já existe
            _context.SaveChanges();

            foreach (var product in item.Products)
            {
                var orderProduct = new OrderProduct(order.Id, product.Id);
                _context.Add(orderProduct);
                _context.SaveChanges();
            }

        }


        [HttpGet]
        public IEnumerable<OrderDTO> GetAll()
        {
            var orders = _context.Order
                .Include(x => x.Products);

            return _mapper.Map<IEnumerable<OrderDTO>>(orders);

        }

        [HttpGet]
        public IEnumerable<OrderDTO> GetAll02()
        {
            var orders = from o in _context.Order
                .Include(x => x.Products)
                         select new OrderDTO()
                         {
                             Id = o.Id,
                             Date = o.Date,
                             Products = _mapper.Map<ICollection<ProductDTO>>(o.Products)
                         };

            return orders;

        }

        [HttpGet]
        public dynamic GetAll03()
        {
            var connString = ServicesConfiguration.ConnectionString;

            var query = string.Empty;
            query += "select O.Id, O.Date, P.Id as ProductId, P.Name as ProductName ";
            query += "from [Order] as O ";
            query += "inner join OrderProduct as OP ";
            query += "on O.Id = OP.OrdersId ";
            query += "inner join Product as P ";
            query += "on P.Id = OP.ProductsId ";


            using (var connection = new SqlConnection(connString))
            {
                return connection.Query(query);
            }
        }


        [HttpPut("{id}")]
        public void Update(Guid id, OrderUpdateDTO item)
        {
            if (id != item.Id)
                return;

            var order = _mapper.Map<Order>(item);
            _context.Update(order);
            _context.SaveChanges();
        }




        [HttpDelete("RemoveItem/{orderId}/{productId}")]
        public void RemoveItem(Guid orderId, Guid productId)
        {
            var order = _context.Order
                .Include(x => x.Products)
                .FirstOrDefault(x => x.Id == orderId);

            var item = order.Products.FirstOrDefault(x => x.Id == productId);
            order.Products.Remove(item);

            _context.SaveChanges();
        }





    }
}