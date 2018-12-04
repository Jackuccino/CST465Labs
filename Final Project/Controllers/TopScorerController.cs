using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FinalProject.Controllers
{
    [Authorize]
    public class TopScorerController : Controller
    {
        private ITopScorerDBRepository _PlayerRepo;
        private ITeamDBRepository _TeamRepo;
        private LeagueSettings _Settings;

        public TopScorerController(IOptions<LeagueSettings> settings, ITeamDBRepository teamRepo, ITopScorerDBRepository playerRepo)
        {
            _Settings = settings.Value;
            _TeamRepo = teamRepo;
            _PlayerRepo = playerRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.LeagueSettings = _Settings;

            List<Player> players = await _PlayerRepo.GetPlayersAsync();
            List<Team> teams = await _TeamRepo.GetTeamsAsync();
            Player player = new Player
            {
                PlayerList = new List<Player>(players.OrderByDescending(p => p.GoalScored)),
                TeamList = new List<Team>(teams.OrderBy(t => t.TeamName))
            };

            return View(player);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditPlayer(int id)
        {
            var player = await _PlayerRepo.GetPlayerAsync(id);
            return View("AddPlayer", player);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddPlayer()
        {
            List<Team> teams = await _TeamRepo.GetTeamsAsync();
            Player player = new Player
            {
                TeamList = new List<Team>(teams.OrderBy(t => t.TeamName))
            };
            return View(player);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult AddPlayer(Player player)
        {
            if (!ModelState.IsValid)
            {
                return View(player);
            }

            _PlayerRepo.Insert(player);

            return RedirectToAction("AddPlayer");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult DeletePlayer(int playerId)
        {
            _PlayerRepo.Delete(playerId);

            return RedirectToAction("Index");
        }
    }
}