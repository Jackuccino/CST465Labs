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

        public CostumeController(ICostumeRepository costumeRepository)
        {
            _costumeRepo = costumeRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            CostumeModel model = new CostumeModel
            {
                CostumeList = new List<Costume>(_costumeRepo.GetList())
            };
            return View(model);
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