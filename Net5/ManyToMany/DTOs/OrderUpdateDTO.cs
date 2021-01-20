using System;
using System.Collections.Generic;

namespace Relationships02.DTOs
{
    public class OrderUpdateDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<ProductUpdateDTO> Products { get; set; }
    }
}