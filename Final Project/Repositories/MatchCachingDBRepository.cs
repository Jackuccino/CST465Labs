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
        private string _CacheListKey { get { return $"{_CachePrefix}_List"; } }
        private IMemoryCache _Cache;
        public MatchCachingDBRepository(IConfiguration configuration, IMemoryCache cache) : base(configuration)
        {
            _Cache = cache;
        }

        public override async Task<List<Match>> GetMatchesAsync()
        {
            var matchList = (List<Match>)_Cache.Get(_CacheListKey);
            if (matchList != null)
            {
                return matchList;
            }
            else
            {
                matchList = await base.GetMatchesAsync();
                _Cache.Set(_CacheListKey, matchList);
                return matchList;
            }
        }

        public override void Insert(Match match)
        {
            base.Insert(match);
            _Cache.Remove(_CacheListKey);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            _Cache.Remove(_CacheListKey);
        }
    }
}
