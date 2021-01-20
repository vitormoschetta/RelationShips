using System;
using System.Collections.Generic;

namespace ManyToMany.Models
{
    public class Order
    {
        public Order(DateTime date)
        {
            Id = Guid.NewGuid();
            Date = date;
        }
        public Order() { }

        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}