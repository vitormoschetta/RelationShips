using System;

namespace ManyToMany.DTOs
{
    public class OrderProductDTO
    {
        public Guid Id { get; set; }
        public ProductDTO Product { get; set; }
    }
}