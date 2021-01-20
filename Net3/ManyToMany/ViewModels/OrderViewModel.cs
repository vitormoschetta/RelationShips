using System;
using System.Collections.Generic;

namespace ManyToMany.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}