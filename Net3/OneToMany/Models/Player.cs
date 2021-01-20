using System;
using System.Collections.Generic;

namespace OneToMany.Models
{
    public class Player
    {
        public Player(string nome, Guid timeId)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            TeamId = timeId;
        }
        public Player() { }      

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid TeamId { get; set; }    
        public virtual Team Team { get; set; } 
    }
}