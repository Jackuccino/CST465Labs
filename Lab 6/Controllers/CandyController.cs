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

        public CandyController(ICandyRepository candyRepository)
        {
            _candyRepo = candyRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CandyModel model = new CandyModel
            {
                CandyList = new List<Candy>(_candyRepo.GetList())
            };
            return View(model);
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