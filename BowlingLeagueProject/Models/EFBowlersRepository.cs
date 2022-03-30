using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueProject.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlingDbContext _context { get; set; }

        public EFBowlersRepository (BowlingDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
        public IQueryable<Team> Teams => _context.Teams;

        public void SaveBowler(Bowler b)
        {
            _context.SaveChanges();
        }

        public void AddBowler(Bowler b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }

        public void DeleteBowler(Bowler b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}
