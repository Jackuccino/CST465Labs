using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FinalProject.Controllers
{
    [Authorize]
    public class MatchesController : Controller
    {
        private ITeamDBRepository _teamRepo;
        private IMatchDBRepository _matchRepo;

        public MatchesController(IMatchDBRepository matchRepo, ITeamDBRepository teamRepo)
        {
            _teamRepo = teamRepo;
            _matchRepo = matchRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Match> matchList = new List<Match>(await _matchRepo.GetMatchesAsync());
            List<Team> teamList = new List<Team>(await _teamRepo.GetTeamsAsync());

            foreach (var item in matchList)
            {
                if (item.TeamList == null)
                    item.TeamList = new List<Team>(teamList.OrderBy(t => t.TeamName));
            }

            Match match = new Match()
            {
                TeamList = new List<Team>(teamList.OrderBy(t => t.TeamName)),
                GroupA = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'A').OrderBy(m => m.MatchDayNumber)),
                GroupB = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'B').OrderBy(m => m.MatchDayNumber)),
                GroupC = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'C').OrderBy(m => m.MatchDayNumber)),
                GroupD = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'D').OrderBy(m => m.MatchDayNumber)),
                GroupE = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'E').OrderBy(m => m.MatchDayNumber)),
                GroupF = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'F').OrderBy(m => m.MatchDayNumber)),
                GroupG = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'G').OrderBy(m => m.MatchDayNumber)),
                GroupH = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'H').OrderBy(m => m.MatchDayNumber)),
            };
            
            return View(match);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditMatch(int id)
        {
            var match = await _matchRepo.GetMatchAsync(id);

            if (match.TeamList == null)
            {
                match.TeamList = await _teamRepo.GetTeamsAsync();
            }

            return View("AddMatch", match);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddMatch()
        {
            List<Match> matchList = new List<Match>(await _matchRepo.GetMatchesAsync());
            List<Team> teamList = new List<Team>(await _teamRepo.GetTeamsAsync());

            foreach (var item in matchList)
            {
                if (item.TeamList == null)
                    item.TeamList = new List<Team>(teamList.OrderBy(t => t.TeamName));
            }

            Match match = new Match()
            {
                TeamList = new List<Team>(teamList.OrderBy(t => t.TeamName)),
                GroupA = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'A').OrderBy(m => m.MatchDayNumber)),
                GroupB = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'B').OrderBy(m => m.MatchDayNumber)),
                GroupC = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'C').OrderBy(m => m.MatchDayNumber)),
                GroupD = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'D').OrderBy(m => m.MatchDayNumber)),
                GroupE = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'E').OrderBy(m => m.MatchDayNumber)),
                GroupF = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'F').OrderBy(m => m.MatchDayNumber)),
                GroupG = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'G').OrderBy(m => m.MatchDayNumber)),
                GroupH = new List<Match>(matchList.FindAll(m => teamList.Find(t => t.Id == m.HomeTeamId).Group == 'H').OrderBy(m => m.MatchDayNumber)),
            };

            return View(match);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult AddMatch(Match match)
        {
            if (!ModelState.IsValid)
            {
                return View(match);
            }

            _matchRepo.Insert(match);

            return RedirectToAction("AddMatch");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteMatch(int matchId)
        {
            _matchRepo.Delete(matchId);

            return RedirectToAction("Index");
        }
    }
}