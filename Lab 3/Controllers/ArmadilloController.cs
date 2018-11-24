using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArmadilloLib;

namespace Lab_3.Controllers
{
    public class ArmadilloController : Controller
    {
        private static ArmadilloFarm m_farm = null;

        public ArmadilloController()
        {
            if (m_farm == null)
            {
                m_farm = new ArmadilloFarm();
                string[] names =
                {
                    "aaa",
                    "bbb",
                    "ccc",
                    "ddd",
                    "eee",
                    "fff",
                    "ggg",
                    "hhh",
                    "iii",
                    "jjj",
                };

                for (int i = 0; i < 10; i++)
                {
                    m_farm.FarmAnimals.Add(new Armadillo
                    {
                        Name = names[i],
                        Age = i + 10,
                        ShellHardness = i * 10,
                        IsPainted = Convert.ToBoolean(i % 2)
                    });
                }
            }
        }

        [Route("/SearchAnimals")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            return View(m_farm.FarmAnimals);
        }

        [HttpPost]
        public IActionResult Search(string name)
        {
            Console.WriteLine(name);
            var arm = m_farm.FarmAnimals.Where(a => a.Name.ToLower().Contains(name.ToLower()));
            return View("SearchResults", arm);
        }
    }
}