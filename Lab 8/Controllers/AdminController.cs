using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab_8.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lab_8.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private RoleManager<IdentityRole> _RoleManager;
        private UserManager<CustomIdentityUser> _UserManager;

        public AdminController(RoleManager<IdentityRole> roleManager, UserManager<CustomIdentityUser> userManager)
        {
            _RoleManager = roleManager;
            _UserManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateRole(string RoleName)
        {
            IdentityRole role = new IdentityRole
            {
                Name = RoleName
            };
            IdentityResult identityResult = _RoleManager.CreateAsync(role).Result;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteRole(string RoleName)
        {
            IdentityRole role = _RoleManager.FindByNameAsync(RoleName).Result;
            IdentityResult identityResult = _RoleManager.DeleteAsync(role).Result;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddUserToRole(string Email)
        {
            return View("AddUserToRole", Email);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUserToRole(string Email, string RoleName)
        {
            CustomIdentityUser identityUser = _UserManager.FindByEmailAsync(Email).Result;
            IdentityResult identityResult = _UserManager.AddToRoleAsync(identityUser, RoleName).Result;

            if (!identityResult.Succeeded)
            {
                throw new Exception(identityResult.Errors.Select(e => e.Description).Aggregate((a, b) => a + "," + b));
            }

            return RedirectToAction("Index");
        }
    }
}