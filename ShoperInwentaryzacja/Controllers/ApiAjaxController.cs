using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using ShoperInwentaryzacja.Database;
using ShoperInwentaryzacja.Entities;
using ShoperInwentaryzacja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ApiAjaxController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _singInManager;
        public ApiAjaxController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> singInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _dbContext = appDbContext;
        }
        [HttpPost]
        public AjaxModel Post(ShoperItem form)
        {
            Inventory inventory = _dbContext.Inventory.SingleOrDefault<Inventory>(x => (x.Sku == form.Sku && x.InventoryId==Int32.Parse(form.InventoryId)));
            var response = new AjaxModel();
            if(inventory==null)
            {
                _dbContext.Add(new Inventory()
                {
                    Sku = form.Sku,
                    Counter = 1,
                    InventoryId=Int32.Parse(form.InventoryId)
                });
                response = new AjaxModel(form, "false");
            }
            else
            {
                inventory.Counter += 1;
                response = new AjaxModel(form, "true");
            }
            _dbContext.SaveChanges();
            return response;
        }
        [HttpGet("Get")]
        public async Task<ShoperItem> Get(string shopid, string sku,string InventoryId)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => ( x.Id == Int32.Parse(shopid)));
            Inventory inventory = _dbContext.Inventory.SingleOrDefault<Inventory>(x => (x.Sku == sku && x.InventoryId == Int32.Parse(InventoryId)));
            ShoperItem shoperItem = await ShoperItem.GetAsync(shop.Token, shop.ShopUrl, sku, inventory.Counter);
            return shoperItem;
        }

        [HttpGet("GetItems")]
        public List<Inventory> Items(string InventoryId)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            List<Inventory> inventory = _dbContext.Inventory.Where<Inventory>(x => x.InventoryId == Int32.Parse(InventoryId)).ToList<Inventory>();
            return inventory;
        }
    }

}
