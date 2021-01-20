using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OneToMany.Models;

namespace OneToMany.Data
{
    public static class InitializeData
    {
        public static void InitializeTeams(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (_context.Team.Any())  
                    return;

                var team = new Team("Juventus");
                _context.Add(team);
                _context.SaveChanges();

                team = new Team("Real Madrid");
                _context.Add(team);
                _context.SaveChanges();                     
            }
        }      

        public static void InitializePlayers(IServiceProvider serviceProvider)
        {
            using (var _context = new AppDbContext(
               serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (_context.Player.Any())  
                    return;

                var team = _context.Team.FirstOrDefault();

                var player = new Player("C. Ronaldo", team.Id);
                _context.Add(player);
                _context.SaveChanges();

                player = new Player("P. Coutinho", team.Id);
                _context.Add(player);
                _context.SaveChanges();
               
            }
        }         

    }
}