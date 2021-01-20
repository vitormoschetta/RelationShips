using System;
using System.Collections.Generic;

namespace OneToMany.DTOs
{
    public class TeamDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<PlayerDTO> Players { get; set; }
    }
}