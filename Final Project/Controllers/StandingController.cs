using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Repositories;
using Microsoft.Extensions.Caching.Memory;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    [Authorize]
    public class StandingController : Controller
    {
        private ITeamDBRepository _TeamRepo;

        public StandingController(ITeamDBRepository teamRepo)
        {
            _TeamRepo = teamRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Team> teamList = new List<Team>(await _TeamRepo.GetTeamsAsync());
            Team team = new Team
            {
                GroupA = new List<Team>(teamList.FindAll(t => t.Group == 'A').OrderBy(t => t.Points)),
                GroupB = new List<Team>(teamList.FindAll(t => t.Group == 'B').OrderBy(t => t.Points)),
                GroupC = new List<Team>(teamList.FindAll(t => t.Group == 'C').OrderBy(t => t.Points)),
                GroupD = new List<Team>(teamList.FindAll(t => t.Group == 'D').OrderBy(t => t.Points)),
                GroupE = new List<Team>(teamList.FindAll(t => t.Group == 'E').OrderBy(t => t.Points)),
                GroupF = new List<Team>(teamList.FindAll(t => t.Group == 'F').OrderBy(t => t.Points)),
                GroupG = new List<Team>(teamList.FindAll(t => t.Group == 'G').OrderBy(t => t.Points)),
                GroupH = new List<Team>(teamList.FindAll(t => t.Group == 'H').OrderBy(t => t.Points))
            };

            return View(team);
        }
        
        [HttpGet]
        public IActionResult EditTeam(Team team)
        {
            return View("AddTeam", team);
        }


        [HttpGet]
        public IActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTeam(Team team)
        {
            if (!ModelState.IsValid)
            {
                return View(team);
            }

            _TeamRepo.Insert(team);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteTeam(int id)
        {
            _TeamRepo.Delete(id);

            return RedirectToAction("Index");
        }
    }
}