using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_5.Models;
using Lab_5.Repositories;

namespace Lab_5.Controllers
{
    public class HomeController : Controller
    {
        private ITreaterRepository _treaterRepo;

        public HomeController()
        {
            _treaterRepo = new TreaterDBRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TreaterModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(TreaterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Treater treater = new Treater
            {
                Name = model.Name,
                FavoriteCandyID = model.FavoriteCandyID,
                CostumeID = model.CostumeID
            };
            _treaterRepo.Insert(treater);

            return RedirectToAction("Index");
        }
    }
}