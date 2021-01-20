using System;
using System.Collections.Generic;
using Relationships02.DTOs;

namespace ManyToMany.DTOs
{
    public class OrderCreateDTO03
    {
        public DateTime Date { get; set; }
        public ICollection<ProductUpdateDTO> Products { get; set; }
    }
}