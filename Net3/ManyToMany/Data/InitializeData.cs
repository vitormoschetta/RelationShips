using System;
using System.Linq;
using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ManyToMany.Data
{
    public static class InitializeData
    {
        public static void InitializeProducts(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (_context.Product.Any())  
                    return;

                var product = new Product("Agenda");
                _context.Add(product);
                _context.SaveChanges();

                product = new Product("Caneta");
                _context.Add(product);
                _context.SaveChanges();

                product = new Product("Pasta Plástica");
                _context.Add(product);
                _context.SaveChanges();               
            }
        }      

        public static void InitializeOrders(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (_context.Order.Any())  
                    return;

                var order = new Order(DateTime.Now);
                _context.Add(order);
                _context.SaveChanges();

                order = new Order(DateTime.Now.AddDays(-1));
                _context.Add(order);
                _context.SaveChanges();
               
            }
        }         

    }
}