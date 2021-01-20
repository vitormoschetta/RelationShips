using System;

namespace ManyToMany.Models
{
    public class OrderProduct
    {
        public OrderProduct(Guid productsId, Guid ordersId)
        {            
            ProductsId = productsId;
            OrdersId = ordersId;
        }        
        public Guid ProductsId { get; set; }
        public Guid OrdersId { get; set; }
    }
}