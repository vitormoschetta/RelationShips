using System;
using System.Collections.Generic;
using Relationships02.DTOs;

namespace ManyToMany.DTOs
{
    public class OrderCreateDTO02
    {
        public DateTime Date { get; set; }
        public ICollection<ProductCreateDTO> Products { get; set; }
    }
}