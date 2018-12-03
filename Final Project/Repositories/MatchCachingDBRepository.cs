using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace FinalProject.Repositories
{
    public class MatchCachingDBRepository : MatchDBRepository
    {
        private readonly string _CachePrefix = "MatchCacheRepo";
        private string _CacheMatchKey { get { return $"{_CachePrefix}_List"; } }
        private IMemoryCache _Cache;
        public MatchCachingDBRepository(IConfiguration configuration, IMemoryCache cache) : base(configuration)
        {
            _Cache = cache;
        }

        public override async Task<List<Match>> GetMatchesAsync()
        {
            var matchList = (List<Match>)_Cache.Get(_CacheMatchKey);
            if (matchList != null)
            {
                return matchList;
            }
            else
            {
                matchList = await base.GetMatchesAsync();
                _Cache.Set(_CacheMatchKey, matchList);
                return matchList;
            }
        }

        public override async Task<Match> GetMatchAsync(int id)
        {
            Match match = null;
            var matchList = await GetMatchesAsync();
            foreach (var item in matchList)
            {
                if (item.Id == id)
                {
                    match = new Match
                    {
                        Id = item.Id,
                        HomeTeamId = item.HomeTeamId,
                        HomeGoals = item.HomeGoals,
                        AwayTeamId = item.AwayTeamId,
                        AwayGoals = item.AwayGoals,
                        MatchDate = item.MatchDate,
                        MatchTime = item.MatchTime,
                        MatchDayNumber = item.MatchDayNumber
                    };
                }
            }

            if (match == null)
            {
                await base.GetMatchAsync(id);
            }

            return match;
        }

        public override void Insert(Match match)
        {
            base.Insert(match);
            _Cache.Remove(_CacheMatchKey);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            _Cache.Remove(_CacheMatchKey);
        }
    }
}