﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_5.Models;

namespace Lab_5.Repositories
{
    public interface ICostumeRepository
    {
        List<Costume> GetList();
        void Insert(string name);
        void Delete(int id);
    }
}
