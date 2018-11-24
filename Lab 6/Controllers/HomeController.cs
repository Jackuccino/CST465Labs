using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_5.Models;
using Lab_5.Repositories;
using Microsoft.Extensions.Options;

namespace Lab_5.Controllers
{
    public class HomeController : Controller
    {
        private ITreaterRepository _treaterRepo;
        private ICandyRepository _candyRepo;
        private ICostumeRepository _costumeRepo;
        private TreaterSettings _Settings;
        public HomeController(IOptions<TreaterSettings> settings, 
                              ITreaterRepository treaterRepository, 
                              ICandyRepository candyRepository, 
                              ICostumeRepository costumeRepository)
        {
            _Settings = settings.Value;
            _treaterRepo = treaterRepository;
            _candyRepo = candyRepository;
            _costumeRepo = costumeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TreaterSettings = _Settings;
            TreaterModel model = new TreaterModel
            {
                CandyList = new List<Candy>(_candyRepo.GetList()),
                CostumeList = new List<Costume>(_costumeRepo.GetList()),
                TreaterList = new List<Treater>(_treaterRepo.GetList())
            };
            return View(model);
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

        public IActionResult Error()
        {
            return View();
        }
    }
}