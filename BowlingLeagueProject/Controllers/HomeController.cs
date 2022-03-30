using BowlingLeagueProject.Models;
using BowlingLeagueProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingLeagueProject.Controllers
{
    public class HomeController : Controller
    {

        private IBowlersRepository _repo { get; set; }

        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index(string team)
        {
            //ViewBag.Bowlers = _repo.Teams.ToList();
            //Viewbag.Teams = _repo.Bowlers.ToList();

            var x = new BowlersViewModel
            {
                Bowlers = _repo.Bowlers.Include(x => x.Team).Where(x => x.Team.TeamName == team || team == null).OrderBy(x => x.BowlerFirstName)
            };

            return View(x);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Teams = _repo.Teams.ToList();
            ViewBag.IDs = _repo.Bowlers.Max(x => x.BowlerID) + 1;
            return View();
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            if (ModelState.IsValid)
            {
                _repo.AddBowler(b);
                //_repo.SaveBowler(b);
                return View("Index");
            }
            else
            {
                ViewBag.Teams = _repo.Teams.ToList();
                return View();
            }
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
