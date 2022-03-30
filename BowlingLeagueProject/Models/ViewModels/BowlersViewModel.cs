using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueProject.Models.ViewModels
{
    public class BowlersViewModel
    {
        public IQueryable<Bowler> Bowlers { get; set; }
    }
}
