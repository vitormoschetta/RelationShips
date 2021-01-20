using System;

namespace ManyToMany.DTOs
{
    public class OrderProductCreateDTO
    {
        public Guid OrderId { get; set; }            
        public Guid ProductId { get; set; }    
    }
}