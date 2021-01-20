using System;
using System.Collections.Generic;

namespace ManyToMany.DTOs
{
    public class OrderCreateDTO02
    {
        public DateTime Date { get; set; }        
        public ICollection<ProductCreateDTO> Products { get; set; }
    }
}