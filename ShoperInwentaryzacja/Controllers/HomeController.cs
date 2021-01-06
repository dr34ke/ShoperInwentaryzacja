using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Web;
using RestSharp;
using ShoperInwentaryzacja.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace ShoperInwentaryzacja.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;

        public HomeController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> singInManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        public IActionResult tajne()
        {
            return View();
        }
        public IActionResult Authenticate()
        {
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user  = await _userManager.FindByNameAsync(username);
            if(user !=null)
            {
                var result = await _singInManager.PasswordSignInAsync(user, password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {
            var user = new IdentityUser()
            {
                UserName = username,
                Email = "",
            };

            var result = await _userManager.CreateAsync(user, password);
            if(result.Succeeded)
            {
                if (user != null)
                {
                    var _result = await _singInManager.PasswordSignInAsync(user, password, false, false);
                    if (_result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
