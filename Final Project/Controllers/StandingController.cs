using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    public class StandingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}