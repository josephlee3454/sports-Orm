using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        //first one 
        {
            ViewBag.WomenLeagues = _context.Leagues
                .Where(l => l.Name.Contains("Women"))
                .ToList();
            

            //second table
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Hockey"))
                .ToList();
            //third table
            ViewBag.NotFootballLeagues = _context.Leagues
                .Where(l => l.Sport!="Football")
                .ToList();
            //fourth table 
            ViewBag.Conferences = _context.Leagues
                .Where(l => l.Name.Contains("Conference"))
                .ToList();
            //fifth table
            ViewBag.RegionAtlantic = _context.Leagues
                .Where(l => l.Name.Contains("Atlantic"))
                .ToList();
            //fitst teams modeltable
            ViewBag.TeamsDallas = _context.Teams
                .Where(l => l.Location.Contains("Dallas"))
                .ToList();


            //second teams models
             ViewBag.TeamsRaptors = _context.Teams
                .Where(l => l.TeamName.Contains("Raptors"))
                .ToList();


            //third teams models 
             ViewBag.LocationCity = _context.Teams
                .Where(l => l.Location.Contains("City"))
                .ToList();

            //fourth team models
            ViewBag.TeamsT = _context.Teams
                .Where(l => l.TeamName.StartsWith("T"))
                .ToList();


            //sixth team models
            ViewBag.AlphaOrder = _context.Teams
                .OrderBy(l => l.Location)
                .ToList();


            //first player models
            ViewBag.PlayerLName = _context.Players
                .Where(l => l.LastName.Contains("Cooper"))
                .ToList();

            //second player models db
            ViewBag.PlayerFName = _context.Players
                .Where(l => l.FirstName.Contains("Joshua"))
                .ToList();


            // third player models db
             ViewBag.PlayerJoshuaORCooper = _context.Players
                .Where(l => l.FirstName.Contains("Joshua"))
                .Where(l => l.LastName!="Cooper")
                .ToList();

             ViewBag.PlayerAlexanderORWyatt = _context.Players
                .Where(l => l.LastName=="Wyatt" || l.FirstName=="Alexander")
                .ToList();



            return View();
            
        }
    

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}