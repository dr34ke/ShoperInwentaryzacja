using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using MimeKit;
using ShoperInwentaryzacja.Database;
using ShoperInwentaryzacja.Models;
using System.Text;
using System.Security.Claims;
using ShoperInwentaryzacja.Entities;
using Newtonsoft.Json;
using System.Dynamic;

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
        [Authorize]
        public IActionResult Index(string shopid, string inventoryid)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            Tuple<List<ShoperItem>, ShoperItem,string, string> tuple = new Tuple<List<ShoperItem>, ShoperItem,string, string>(new List<ShoperItem>(), new ShoperItem(),shopid,inventoryid);
            Inventories inventories = _dbContext.Inventories.First<Inventories>(x => (x.ShopId == shopid.ToString() && x.UserID == UserId && x.Id == Int32.Parse(inventoryid)));
            if (inventories.Status == "Zakończona")
            {
                return RedirectToAction("ShowReportOfChanges", new { shopId = shopid, inventoryId = inventoryid });
            }
            return View("Index", tuple);
        }
        [HttpGet, Authorize]
        public async Task<IActionResult> GenerateReport(string inventoryid, string shopid)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => (x.Id == Int32.Parse(shopid)));
            Inventories inventory = _dbContext.Inventories.Single<Inventories>(x => (x.Id == Int32.Parse(inventoryid) && x.ShopId == x.ShopId && x.UserID == UserId));
            List<Inventory> inventories = _dbContext.Inventory.Where<Inventory>(x => x.InventoryId == Int32.Parse(inventoryid)).ToList<Inventory>();
            if (inventory.Status == "Zakończona")
            {
                return RedirectToAction("ShowReportOfChanges", new { shopId = shopid, inventoryId = inventoryid });
            }
            List<ReportOfChanges> report = new List<ReportOfChanges>();
            switch (inventory.Option)
            {
                case "SKU":
                    {
                        report = await ShoperItem.GetAllSkuListAsync(shop.Token, shop.ShopUrl, inventory.Sku, inventories);
                        break;
                    }
                case "Category&SKU":
                    {
                        report = await ShoperItem.GetAllSkuListAsync(shop.Token, shop.ShopUrl, inventory.Sku, inventories);
                        //dodaj filtrowanie kategorii
                        break;
                    }
                case "Category":
                    {
                        report = await ShoperItem.GetAllCategoryListAsync(shop.Token, shop.ShopUrl, inventory.Category, inventories);
                        break;
                    }
                default:
                    break;
            }
            try
            {
                using (FileStream fs = System.IO.File.Create("reports\\shop" + shopid + "inventory" + inventoryid + ".json"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(report));
                    fs.Write(info, 0, info.Length);
                }
            }
            catch
            {

            }
            return ReadReport(inventoryid, shopid);
        }
        [HttpGet, Authorize]
        public IActionResult ReadReport(string inventoryId, string shopId)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => (x.Id == Int32.Parse(shopId) && x.UserID==UserId));
            Inventories inventories = _dbContext.Inventories.First<Inventories>(x => (x.ShopId == shop.Id.ToString() && x.UserID == UserId && x.Id == Int32.Parse(inventoryId)));
            if (inventories.Status == "Zakończona")
            {
                return RedirectToAction("ShowReportOfChanges", new { shopId = shopId, inventoryId = inventoryId });
            }
            string json = "";
            using (StreamReader sr = System.IO.File.OpenText("reports\\shop" + shop.Id + "inventory" + inventoryId + ".json"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    json += s;
                }
            }

            List<ReportOfChanges> reportOfChanges = JsonConvert.DeserializeObject<List<ReportOfChanges>>(json);
            Tuple<List<ReportOfChanges>, string, string> tuple = new Tuple<List<ReportOfChanges>, string, string>(reportOfChanges, shopId, inventoryId);
            return View("ReadReport", tuple);
        }
        [HttpPost]
        public bool DoActions(IEnumerable<ReportOfChanges> list, string num, string shopid, string inventoryid)
        {
            List<ReportOfChanges> accepted = list.Where(x => x.accepted == true).ToList();
            if(num=="0")
            {
                using (FileStream fs = System.IO.File.Create("reports\\acceptedshop" + shopid + "inventory" + inventoryid + ".json"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(accepted));
                    fs.Write(info, 0, info.Length);
                }
            }
            else
            {
                string json = "";
                using (StreamReader sr = System.IO.File.OpenText("reports\\acceptedshop" + shopid + "inventory" + inventoryid + ".json"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        json += s;
                    }
                }
                using (FileStream fs = System.IO.File.Create("reports\\acceptedshop" + shopid + "inventory" + inventoryid + ".json"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(json.Trim(']')+','+JsonConvert.SerializeObject(accepted).Trim('['));
                    fs.Write(info, 0, info.Length);
                }
            }
            return true;
        }
        [HttpGet, Authorize]
        public IActionResult ChangeStock(string shopId, string inventoryId)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => (x.Id == Int32.Parse(shopId) && x.UserID == UserId));
            Inventories inventories = _dbContext.Inventories.First<Inventories>(x => (x.ShopId == shop.Id.ToString() && x.UserID == UserId && x.Id == Int32.Parse(inventoryId)));
            if(inventories.Status=="Zakończona")
            {
                return RedirectToAction("ShowReportOfChanges", new { shopId = shopId, inventoryId = inventoryId });
            }
            string json = "";
            try
            {
                using(StreamReader sr = System.IO.File.OpenText("reports\\acceptedshop" + shop.Id + "inventory" + inventoryId + ".json"))
            {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        json += s;
                    }
                }
            }
            catch
            {
                return View("ChangeStock", new List<ReportOfChanges>());
            }
            
            List<ReportOfChanges> reportOfChanges = JsonConvert.DeserializeObject<List<ReportOfChanges>>(json);
            return View("ChangeStock", reportOfChanges);
        }



        [HttpPost, Authorize]
        public async Task<bool> ChangeStock(string id, string num, string stock, string shopid, string inventoryid)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => (x.Id == Int32.Parse(shopid) && x.UserID == UserId));
            bool response;
            int i = 0;
            do
            {
                response = await ShoperItem.ChangeStock(shop.Token, shop.ShopUrl, id, stock);
                await Task.Delay(i);
                i += 1000;
            } while (response != true || i==10000);

            dynamic a = new ExpandoObject();
            a.id = id;
            a.stock = stock;
            a.set = response;
            if (num == "0")
            {
                using (FileStream fs = System.IO.File.Create("reports\\reportofchanges" + shopid + "inventory" + inventoryid + ".json"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("["+JsonConvert.SerializeObject(a)+"]");
                    fs.Write(info, 0, info.Length);
                }
            }
            else
            {
                string json = "";
                using (StreamReader sr = System.IO.File.OpenText("reports\\reportofchanges" + shopid + "inventory" + inventoryid + ".json"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        json += s;
                    }
                }
                using (FileStream fs = System.IO.File.Create("reports\\reportofchanges" + shopid + "inventory" + inventoryid + ".json"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(json.Trim(']') + ',' + JsonConvert.SerializeObject(a)+"]");
                    fs.Write(info, 0, info.Length);
                }
            }
            return response;
        }
        [HttpPost, Authorize]
        public bool ChangeStatus(string shopId, string inventoryId)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => (x.Id == Int32.Parse(shopId) && x.UserID == UserId));
            Inventories inventory = _dbContext.Inventories.First<Inventories>(x => (x.Id==Int32.Parse(inventoryId) && x.ShopId== shop.Id.ToString()));
            inventory.Status="Zakończona";
            List<Inventory> _inventory = _dbContext.Inventory.Where<Inventory>(x => x.InventoryId == Int32.Parse(inventoryId)).ToList<Inventory>();
            _dbContext.Inventory.RemoveRange(_inventory);
            _dbContext.SaveChanges();
            System.IO.File.Delete("reports\\acceptedshop" + shopId + "inventory" + inventoryId + ".json");
            System.IO.File.Delete("reports\\shop" + shopId + "inventory" + inventoryId + ".json");
            return true;
        }
        [Authorize]
        public IActionResult ShowReportOfChanges(string shopId, string inventoryId)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            var UserId = _userManager.GetUserId(principal);
            UsersShoperToken shop = _dbContext.ShoperToken.First<UsersShoperToken>(x => (x.Id == Int32.Parse(shopId) && x.UserID == UserId));
            Inventories inventories = _dbContext.Inventories.First<Inventories>(x => (x.ShopId == shop.Id.ToString() && x.UserID == UserId));
            string json = "";
            try
            {
                using (StreamReader sr = System.IO.File.OpenText("reports\\reportofchanges" + shop.Id + "inventory" + inventoryId + ".json"))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        json += s;
                    }
                }
            }
            catch
            {
                return View("ShowReportOfChanges", new Dictionary<string, string>());
            }
            List<ReportResult> reportOfChanges = JsonConvert.DeserializeObject<List<ReportResult>>(json);
            return View("ShowReportOfChanges", reportOfChanges);
        }
    }
    
}

