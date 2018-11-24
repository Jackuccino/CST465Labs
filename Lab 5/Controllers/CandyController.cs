using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_5.Models;
using Lab_5.Repositories;

namespace Lab_5.Controllers
{
    public class CandyController : Controller
    {
        private ICandyRepository _candyRepo;

        public CandyController()
        {
            _candyRepo = new CandyDBRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new CandyModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CandyModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
                        
            _candyRepo.Insert(model.ProductName);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _candyRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}