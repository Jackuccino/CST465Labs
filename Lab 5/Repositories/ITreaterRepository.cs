using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Models;

namespace Lab_5.Repositories
{
    public interface ITreaterRepository
    {
        List<Treater> GetList();
        void Insert(Treater treater);
    }
}
