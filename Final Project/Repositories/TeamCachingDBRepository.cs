using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;

namespace FinalProject.Repositories
{
    public class TeamCachingDBRepository : TeamDBRepository
    {
        private readonly string _CachePrefix = "TeamCacheRepo";
        private string _CacheListKey { get { return $"{_CachePrefix}_List"; } }
        private IMemoryCache _Cache;
        public TeamCachingDBRepository(IConfiguration configuration, IMemoryCache cache) : base(configuration)
        {
            _Cache = cache;
        }

        public override async Task<List<Team>> GetTeamsAsync()
        {
            var teamList = (List<Team>)_Cache.Get(_CacheListKey);
            if (teamList != null)
            {
                return teamList;
            }
            else
            {
                teamList = await base.GetTeamsAsync();
                _Cache.Set(_CacheListKey, teamList);
                return teamList;
            }
        }

        public override void Insert(Team team)
        {
            base.Insert(team);
            _Cache.Remove(_CacheListKey);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            _Cache.Remove(_CacheListKey);
        }
    }
}
