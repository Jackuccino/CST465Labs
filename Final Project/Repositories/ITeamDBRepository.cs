using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface ITeamDBRepository
    {
        Task<List<Team>> GetTeamsAsync();
        void Insert(Team team);
        void Delete(int id);
    }
}
