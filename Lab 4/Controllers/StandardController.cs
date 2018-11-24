using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab_4.Controllers
{
    public class StandardController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new ComputerModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(ComputerModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.Clear();
                return View(new ComputerModel());
            }
            return View("Submission", model);
        }
    }
}