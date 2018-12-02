using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Repositories
{
    public interface IMatchDBRepository
    {
        Task<List<Match>> GetMatchesAsync();
        void Insert(Match match);
        void Delete(int id);
    }
}
