using System;

namespace ManyToMany.Models
{
    public class OrderProduct
    {
        public OrderProduct(Guid orderId, Guid productId)
        {
            Id = Guid.NewGuid();
            OrderId = orderId;
            ProductId = productId;
        }
        public OrderProduct() { }

        public Guid Id { get; set; }
        public Guid OrderId { get; set; }            
        public Guid ProductId { get; set; }    
        public Product Product { get; set; }          
    }
}