using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using FinalProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace FinalProject.Controllers
{
    public class MatchesController : Controller
    {
        private ITeamDBRepository _teamRepo;
        private IMatchDBRepository _matchRepo;
        private IMemoryCache _Cache;

        public MatchesController(IMemoryCache cache, IMatchDBRepository matchRepo, ITeamDBRepository teamRepo)
        {
            _Cache = cache;
            _teamRepo = teamRepo;
            _matchRepo = matchRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Match> matchList = new List<Match>(await _matchRepo.GetMatchesAsync());
            List<Team> teamList = new List<Team>(await _teamRepo.GetTeamsAsync());
            Match match = new Match()
            {
                TeamList = new List<Team>(teamList),
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
    }
}