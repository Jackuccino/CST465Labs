using FinalProject.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public class TopScorerCachingDBRepository : TopScorerDBRepository
    {
        private readonly string _CachePrefix = "PlayerCacheRepo";
        private string _CacheListKey { get { return $"{_CachePrefix}_List"; } }
        private IMemoryCache _Cache;
        public TopScorerCachingDBRepository(IConfiguration configuration, IMemoryCache cache) : base(configuration)
        {
            _Cache = cache;
        }

        public override async Task<List<Player>> GetPlayersAsync()
        {
            var playerList = (List<Player>)_Cache.Get(_CacheListKey);
            if (playerList != null)
            {
                return playerList;
            }
            else
            {
                playerList = await base.GetPlayersAsync();
                _Cache.Set(_CacheListKey, playerList);
                return playerList;
            }
        }

        public override async Task<Player> GetPlayerAsync(int id)
        {
            Player player = null;
            var playerList = (List<Player>)_Cache.Get(_CacheListKey);

            if (playerList == null)
            {
                playerList = await base.GetPlayersAsync();
                _Cache.Set(_CacheListKey, playerList);
            }

            foreach (var item in playerList)
            {
                if (item.Id == id)
                {
                    player = new Player
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Position = item.Position,
                        Nationality = item.Nationality,
                        JerseyNumber = item.JerseyNumber,
                        GoalScored = item.GoalScored,
                        TeamId = item.TeamId
                    };
                }
            }

            if (player == null)
            {
                await base.GetPlayerAsync(id);
            }

            return player;
        }

        public override void Insert(Player player)
        {
            _Cache.Remove(_CacheListKey);
            base.Insert(player);
        }

        public override void Delete(int id)
        {
            _Cache.Remove(_CacheListKey);
            base.Delete(id);
        }
    }
}
