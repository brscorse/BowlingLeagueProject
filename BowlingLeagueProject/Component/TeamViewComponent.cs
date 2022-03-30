using BowlingLeagueProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueProject.Component
{
    public class TeamViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamViewComponent (IBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["team"];

            var teams = repo.Bowlers.Include(x => x.Team).Select(x => x.Team.TeamName).Distinct().OrderBy(x => x);

            return View(teams);
        }


    }
}
