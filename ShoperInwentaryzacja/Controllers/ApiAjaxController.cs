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
        public async Task<List<ShoperItem>> Items(string InventoryId, string shopId)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => (x.Id == Int32.Parse(shopId)));
            List<Inventory> inventories = _dbContext.Inventory.Where<Inventory>(x => x.InventoryId == Int32.Parse(InventoryId)).ToList<Inventory>();
            string skus = "";
            foreach (Inventory inv in inventories)
            {
                skus += "\"" + inv.Sku + "\",";
            }
            List<ShoperItem> items = await ShoperItem.GetListAsync(shop.Token, shop.ShopUrl, skus.TrimEnd(','), inventories);
            return items;
        }

        [HttpGet("SetCounter")]
        public async Task<bool> SetCounter(string InventoryId, string shopId, string sku, int value)
        {
            Inventory inventory = _dbContext.Inventory.SingleOrDefault<Inventory>(x => (x.Sku.ToLower() == sku.ToLower() && x.InventoryId == Int32.Parse(InventoryId)));
            var response = new AjaxModel();
            if (inventory == null)
            {
                return false;
            }
            else
            {
                inventory.Counter = value;
                _dbContext.SaveChanges();
                return true;
            }
        }
    }

}
