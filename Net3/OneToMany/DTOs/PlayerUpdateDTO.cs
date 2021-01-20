using System;

namespace OneToMany.DTOs
{
    public class PlayerUpdateDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid TeamId { get; set; } 
    }
}