
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;

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
        {   //1
            ViewBag.atlanticTeams = _context.Teams
                .Include(item => item.CurrLeague)
                .Where(item => item.CurrLeague.Name
                .Contains("Atlantic Soccer Conference"))
                .ToList();
                //2
            ViewBag.BostonPenguins = _context.Players
                .Include(item => item.CurrentTeam)
                .Where(item => item.CurrentTeam.TeamName == "Penguins" && item.CurrentTeam.Location == "Boston")
                .ToList();
            //3
            ViewBag.ICBC= _context.Teams
                .Where(item => item.LeagueId == 2)
                .SelectMany(item => item.CurrentPlayers)
                .ToList();
            //4
            ViewBag.ACAFLopez = _context.Teams
                .Include(item => item.CurrLeague)
                .Where(item => item.CurrLeague.Name == "American Conference of Amateur Football" && item.CurrLeague.Name.Contains("Lopez")) 
                .ToList();
            //5
                ViewBag.ACAFLopez = _context.Teams
                .Where(t => t.LeagueId == 7)
                .SelectMany(p => p.CurrentPlayers)
                .Where(currentPlayers => currentPlayers.LastName.Contains("Lopez"))
                .ToList();

                //6
        
            ViewBag.Sophia = _context.Teams
                .Include(item => item.CurrentPlayers)
                .Where(item => item.CurrentPlayers
                .Any(item => item.FirstName == "Sophia"))
                .ToList();

                //7
            ViewBag.AllLegSophia = _context.Leagues
                .Include(item => item.Teams)
                .Where(item => item.Teams.Any(item=> item.CurrentPlayers
                .Any(player => player.FirstName.Contains("Sophia"))));
            
                //8
            ViewBag.FindFlores = _context.Players
                .Include(item => item.CurrentTeam)
                .Where(item => item.LastName.Contains("Flores") 
                && item.CurrentTeam.TeamName != "Roughriders");   
                                                                                   
            return View();
         
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}