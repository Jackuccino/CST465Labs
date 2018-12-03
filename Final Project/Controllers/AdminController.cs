using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
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
        public async Task<IActionResult> CreateRole(string RoleName)
        {
            IdentityRole role = new IdentityRole
            {
                Name = RoleName
            };
            IdentityResult identityResult = await _RoleManager.CreateAsync(role);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRole(string RoleName)
        {
            IdentityRole role = await _RoleManager.FindByNameAsync(RoleName);
            IdentityResult identityResult = await _RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddUserToRole(string Email)
        {
            if (Email == null)
                return RedirectToAction("Index");
            else
                return View("AddUserToRole", Email);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserToRole(string Email, string RoleName)
        {
            CustomIdentityUser identityUser = await _UserManager.FindByEmailAsync(Email);
            IdentityResult identityResult = await _UserManager.AddToRoleAsync(identityUser, RoleName);

            if (!identityResult.Succeeded)
            {
                throw new Exception(identityResult.Errors.Select(e => e.Description).Aggregate((a, b) => a + "," + b));
            }

            return RedirectToAction("Index");
        }
    }
}