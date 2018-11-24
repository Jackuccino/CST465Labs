using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_5.Models;
using Lab_5.Repositories;

namespace Lab_5.Controllers
{
    public class CostumeController : Controller
    {
        private ICostumeRepository _costumeRepo;

        public CostumeController()
        {
            _costumeRepo = new CostumeDBRepository();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CostumeModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CostumeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _costumeRepo.Insert(model.CostumeName);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _costumeRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}