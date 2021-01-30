using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoperInwentaryzacja.Database;
using ShoperInwentaryzacja.Models;

namespace ShoperInwentaryzacja.Controllers
{
    public class InventoryController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;
        public InventoryController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> singInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _dbContext = appDbContext;
        }
        public IActionResult Index()
        {
            Tuple<List<ShoperItem>, ShoperItem> tuple = new Tuple<List<ShoperItem>, ShoperItem>(new List<ShoperItem>(), new ShoperItem());
            return View("Index", tuple);
        }
    }
}
