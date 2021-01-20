using System;
using System.Collections.Generic;

namespace ManyToMany.DTOs
{
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public List<OrderProductDTO> OrderProducts { get; set; }
    }
}