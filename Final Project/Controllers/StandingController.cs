using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Repositories;
using Microsoft.Extensions.Caching.Memory;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace FinalProject.Controllers
{
    [Authorize]
    public class StandingController : Controller
    {
        private ITeamDBRepository _TeamRepo;
        private LeagueSettings _Settings;

        public StandingController(IOptions<LeagueSettings> settings, ITeamDBRepository teamRepo)
        {
            _Settings = settings.Value;
            _TeamRepo = teamRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.LeagueSettings = _Settings;

            List<Team> teamList = new List<Team>(await _TeamRepo.GetTeamsAsync());

            Team team = new Team
            {
                GroupA = new List<Team>(teamList.FindAll(t => t.Group == 'A').OrderByDescending(t => t.Points)),
                GroupB = new List<Team>(teamList.FindAll(t => t.Group == 'B').OrderByDescending(t => t.Points)),
                GroupC = new List<Team>(teamList.FindAll(t => t.Group == 'C').OrderByDescending(t => t.Points)),
                GroupD = new List<Team>(teamList.FindAll(t => t.Group == 'D').OrderByDescending(t => t.Points)),
                GroupE = new List<Team>(teamList.FindAll(t => t.Group == 'E').OrderByDescending(t => t.Points)),
                GroupF = new List<Team>(teamList.FindAll(t => t.Group == 'F').OrderByDescending(t => t.Points)),
                GroupG = new List<Team>(teamList.FindAll(t => t.Group == 'G').OrderByDescending(t => t.Points)),
                GroupH = new List<Team>(teamList.FindAll(t => t.Group == 'H').OrderByDescending(t => t.Points))
            };

            return View(team);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditTeam(int id)
        {
            var team = await _TeamRepo.GetTeamAsync(id);
            return View("AddTeam", team);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddTeam()
        {
            return View(new Team());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult AddTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View(team);
            }

            _TeamRepo.Insert(team);

            return RedirectToAction("AddTeam");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteTeam(int teamId)
        {
            _TeamRepo.Delete(teamId);

            return RedirectToAction("Index");
        }
    }
}