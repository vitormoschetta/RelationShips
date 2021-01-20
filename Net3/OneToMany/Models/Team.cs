using System;
using System.Collections.Generic;

namespace OneToMany.Models
{
    public class Team
    {
        public Team(string nome)
        {
            Id = Guid.NewGuid();
            Nome = nome;
        }
        public Team() { }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Player> Players { get; set; }
    }
}