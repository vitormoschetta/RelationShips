using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToMany.Data;
using OneToMany.DTOs;
using OneToMany.Models;

namespace OneToMany.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PlayerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PlayerController(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        

        [HttpPost]
        public void Create(PlayerCreateDTO item)
        {
            var player = new Player(item.Nome, item.TimeId);
            _context.Add(player);
            _context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Player> GetAll()
        {
            return _context.Player;                
        }


        [HttpGet]
        public IEnumerable<Player> GetAll02()
        {
            return _context.Player
                .Include(x => x.Team);
        }


        [HttpGet]
        public IEnumerable<PlayerDTO> GetAll03()
        {
            var teams = _context.Player;

            return _mapper.Map<IEnumerable<PlayerDTO>>(teams);
        }


        [HttpPut]
        public void Update(Guid id, PlayerUpdateDTO item)
        {
            var player = _mapper.Map<Player>(item);
            _context.Update(player);
            _context.SaveChanges();
        }


        [HttpDelete]
        public void Delete(Guid id)
        {
            var player = _context.Player.FirstOrDefault(x => x.Id == id);
            _context.Remove(player);
            _context.SaveChanges();
        }

    }
}