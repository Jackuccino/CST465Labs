using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface ITopScorerDBRepository
    {
        Task<List<Player>> GetPlayersAsync();
        Task<Player> GetPlayerAsync(int id);
        void Insert(Player player);
        void Delete(int id);
    }
}
