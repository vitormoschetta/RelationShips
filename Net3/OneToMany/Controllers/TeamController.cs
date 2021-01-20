using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OneToMany.Configurations;
using OneToMany.Data;
using OneToMany.DTOs;
using OneToMany.Models;

namespace OneToMany.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeamController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TeamController(AppDbContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }
        

        [HttpPost]
        public void Create(TeamCreateDTO item)
        {
            var team = _mapper.Map<Team>(item);
            _context.Add(team);
            _context.SaveChanges();
        }

        [HttpGet]
        public IEnumerable<Team> GetAll()
        {
            return _context.Team
                .Include(x => x.Players);
        }


        [HttpGet]
        public IEnumerable<TeamDTO> GetAll02()
        {
            var teams =  _context.Team
                .Include(x => x.Players);

            return _mapper.Map<IEnumerable<TeamDTO>>(teams);
        }

        
        [HttpGet]
        public dynamic GetAll03([FromServices] IConfiguration _configuration)
        {
            var connString = ServicesConfiguration.ConnectionString;

            var query = string.Empty;
            query += "select T.Id, T.Nome, P.Id as PlayerId, P.Nome as PlayerNome ";
            query += "from Team as T ";
            query += "inner join Player as P ";
            query += "on T.Id = P.TeamId ";                 

            using (var connection = new SqlConnection(connString))
            {                
                return connection.Query<dynamic>(query);
            }                                
        }


        [HttpPut]
        public void Update(Guid id, TeamUpdateDTO item)
        {
            var team = _mapper.Map<Team>(item);
            _context.Update(team);
            _context.SaveChanges();
        }


        [HttpDelete]
        public void Delete(Guid id)
        {
            var team = _context.Team.FirstOrDefault(x => x.Id == id);
            _context.Remove(team);
            _context.SaveChanges();
        }
        
    }
}