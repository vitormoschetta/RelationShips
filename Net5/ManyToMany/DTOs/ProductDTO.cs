using System;
using ManyToMany.Models;

namespace ManyToMany.DTOs
{
    public class ProductDTO
    {
        public ProductDTO(Product item)
        {
            Id = item.Id;
            Name = item.Name;
        }
        public ProductDTO() { }

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}