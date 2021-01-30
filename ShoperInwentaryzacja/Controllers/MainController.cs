using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using ShoperInwentaryzacja.Database;
using ShoperInwentaryzacja.Entities;
using ShoperInwentaryzacja.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Controllers
{
    public class MainController: Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;
        public MainController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> singInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _dbContext = appDbContext;
        }
        [Authorize, Authorize]
        public IActionResult Index()
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            List<UsersShoperToken> shops =_dbContext.ShoperToken.Where<UsersShoperToken>(x => x.UserID == UserId).ToList<UsersShoperToken>();
            return View(shops);
        }
        [HttpGet, Authorize]
        public async Task<IActionResult> Inventory(string ShopId)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            dynamic models = new ExpandoObject();
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => (x.UserID == UserId && x.Id == Int32.Parse(ShopId)));
            List<Inventories> inventories = _dbContext.Inventories.Where<Inventories>( x => (x.UserID == UserId && x.ShopUrl==shop.ShopUrl)).ToList<Inventories>();
            models.inventories = inventories;
            ShopCategories shopCategories = await ShopCategories.GetCategories(shop.ShopUrl, shop.Token);
            models.categories = shopCategories;
            models.shopid = ShopId;
            return View("Inventories", models);
        }
        [HttpGet, Authorize]
        public IActionResult AddInventory(string ShopId, string Name, string SKU, string Option, string Category)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => (x.UserID == UserId && x.Id == Int32.Parse(ShopId)));
            Inventories inventories = new Inventories()
            {
                ShopUrl =shop.ShopUrl,
                Sku = SKU,
                Category =Category,
                Name = Name,
                Option =Option,
                UserID = UserId
            };
            _dbContext.Inventories.Add(inventories);
            _dbContext.SaveChanges();

            return View("Inventories", ShopId);
        }
        public IActionResult AddShoperToken()
        {
            return View();
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> AddShoperToken(LoginDetails loginDetails)
        {
            RestClient client = new RestClient("https://" + loginDetails.ShopUrl);
            RestRequest request = new RestRequest("/webapi/rest/auth", Method.POST);
            request.AddParameter("client_id", loginDetails.Name);
            request.AddParameter("client_secret", loginDetails.Password);
            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
                var UserId = _userManager.GetUserId(principal);
                ShoperAuthResponse shoperAuth = new ShoperAuthResponse(response.Content);
                UsersShoperToken shoperToken = new UsersShoperToken()
                {
                    ExpireDate = shoperAuth.expire_date,
                    ShopUrl = loginDetails.ShopUrl,
                    Token = shoperAuth.access_token,
                    UserID = UserId,
                };
                _dbContext.ShoperToken.Add(shoperToken);
                _dbContext.SaveChanges();
                return RedirectToAction("ShoperTokenAdded");
            }
            return RedirectToAction("AddShoperToken");
        }
    }
}
