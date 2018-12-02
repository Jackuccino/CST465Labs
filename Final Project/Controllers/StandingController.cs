using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Repositories;
using Microsoft.Extensions.Caching.Memory;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class StandingController : Controller
    {
        private ITeamDBRepository _TeamRepo;
        private IMemoryCache _Cache;

        public StandingController(IMemoryCache cache, ITeamDBRepository teamRepo)
        {
            _Cache = cache;
            _TeamRepo = teamRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Team> teamList = new List<Team>(await _TeamRepo.GetTeamsAsync());
            Team team = new Team
            {
                GroupA = new List<Team>(teamList.FindAll(m => m.Group == 'A')),
                GroupB = new List<Team>(teamList.FindAll(m => m.Group == 'B')),
                GroupC = new List<Team>(teamList.FindAll(m => m.Group == 'C')),
                GroupD = new List<Team>(teamList.FindAll(m => m.Group == 'D')),
                GroupE = new List<Team>(teamList.FindAll(m => m.Group == 'E')),
                GroupF = new List<Team>(teamList.FindAll(m => m.Group == 'F')),
                GroupG = new List<Team>(teamList.FindAll(m => m.Group == 'G')),
                GroupH = new List<Team>(teamList.FindAll(m => m.Group == 'H'))
            };

            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTeam(Team team)
        {
            return RedirectToAction("Index");
        }
    }
}