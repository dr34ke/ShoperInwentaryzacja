using Newtonsoft.Json;
using RestSharp;
using ShoperInwentaryzacja.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Models
{
    public class ShoperItem 
    {
        public ShoperItem()
        {

        }
        public static async Task<ShoperItem> GetAsync(string token, string shopUrl, string sku, int counter)
        {
            RestClient client = new RestClient(@"https://" + shopUrl + "/");
            RestRequest request = new RestRequest("webapi/rest/products", Method.GET);
            request.AddParameter("filters", "{\"stock.code\":{\"=\":\""+sku+"\"}}");
            request.AddHeader("Authorization", "Bearer " + token);
            var response = await client.ExecuteAsync(request);
            ShoperProductResponse shoperProductResponse = JsonConvert.DeserializeObject<ShoperProductResponse>(response.Content);
            ShoperItem shoperItem = new ShoperItem();
            if (shoperProductResponse.list.Count > 0)
            {
                shoperItem.Sku = shoperProductResponse.list[0].stock.Code;
                shoperItem.ExpectedStock = Int32.Parse(shoperProductResponse.list[0].stock.stock);
                shoperItem.Name = shoperProductResponse.list[0].translations.pl_PL.name;
                shoperItem.Price = shoperProductResponse.list[0].stock.price;
                shoperItem.Product_id = shoperProductResponse.list[0].product_id;
                shoperItem.Stock = counter;
            }
            return shoperItem;
        }
        public static async Task<List<ShoperItem>> GetListAsync(string token, string shopUrl, string skuSet, List<Inventory> inventories)
        {
            //zapętl aby uzyskać wszystkie przedmioty
            ShoperProductResponse shoperProductResponse = new ShoperProductResponse();
            int page = 0;
            do
            {
                RestClient client = new RestClient(@"https://" + shopUrl + "/");
                RestRequest request = new RestRequest("webapi/rest/products?filters={\"stock.code\":{\"IN\":[" + skuSet + "]}}", Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("limit", "50");
                var response = await client.ExecuteAsync(request);
                ShoperProductResponse _response = JsonConvert.DeserializeObject<ShoperProductResponse>(response.Content);
                if (page == 0)
                {
                    shoperProductResponse = _response;
                }
                else
                {
                    shoperProductResponse.list.AddRange(_response.list);
                }
                page += 1;
            } while (page != Int32.Parse(shoperProductResponse.pages));
            
            List<ShoperItem> shoperItems = new List<ShoperItem>();
            foreach (Inventory inventory in inventories)
            {
                    ShoperProduct product = shoperProductResponse.list.Find(x => x.stock.Code.ToLower() == inventory.Sku.ToLower());
                    ShoperItem shoperItem = new ShoperItem();
                    if (product == null)
                    {
                        shoperItem.Sku = inventory.Sku;
                        shoperItem.Stock = inventory.Counter;
                        shoperItem.ExpectedStock = 0;
                        shoperItem.InventoryId = inventory.InventoryId.ToString();
                        shoperItem.Name = "Brak produktu w sklepie shoper";
                        shoperItem.Price = "0";
                        shoperItem.Product_id = "";
                    }
                    else
                    {
                        shoperItem.Sku = inventory.Sku;
                        shoperItem.Stock = inventory.Counter;
                        shoperItem.ExpectedStock = Int32.Parse(product.stock.stock);
                        shoperItem.InventoryId = inventory.InventoryId.ToString();
                        shoperItem.Name = product.translations.pl_PL.name;
                        shoperItem.Price = product.stock.price;
                        shoperItem.Product_id = product.product_id;
                    }
                    shoperItems.Add(shoperItem);
                }
            
            return shoperItems;
        }
        public static async Task<List<ReportOfChanges>> GetAllSkuListAsync(string token, string shopUrl, string skuSet, List<Inventory> inventories)
        {
            List<ReportOfChanges> reportOfChanges = new List<ReportOfChanges>();
            ShoperProductResponse shoperProductResponse = new ShoperProductResponse();
            int page = 0;
            do
            {
                RestClient client = new RestClient(@"https://" + shopUrl + "/");
                RestRequest request = new RestRequest("webapi/rest/products?filters={\"stock.code\":{\"like\":\"" + skuSet + "\"}}", Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("limit", "50");
                request.AddParameter("page", page);
                var response = await client.ExecuteAsync(request);
                ShoperProductResponse _response = JsonConvert.DeserializeObject<ShoperProductResponse>(response.Content);
                if (page == 0)
                {
                    shoperProductResponse = _response;
                }
                else
                {
                    shoperProductResponse.list.AddRange(_response.list);
                }
                page += 1;
            } while (page != Int32.Parse(shoperProductResponse.pages));


            foreach (ShoperProduct shoperProduct in shoperProductResponse.list)
            {
                Inventory product = inventories.Find(x => x.Sku.ToLower() == shoperProduct.stock.Code.ToLower());
                if (product == null)
                {
                    ReportOfChanges reportOfChange = new ReportOfChanges()
                    {
                        difference_of_stock = 0 - Int32.Parse(shoperProduct.stock.stock),
                        accepted = true,
                        name = shoperProduct.translations.pl_PL.name,
                        realStock = 0,
                        sku = shoperProduct.stock.Code,
                        product_id = shoperProduct.product_id
                    };
                    reportOfChanges.Add(reportOfChange);
                }
                else
                {
                    ReportOfChanges reportOfChange = new ReportOfChanges()
                    {
                        difference_of_stock = product.Counter - Int32.Parse(shoperProduct.stock.stock),
                        accepted = true,
                        name = shoperProduct.translations.pl_PL.name,
                        sku = shoperProduct.stock.Code,
                        realStock = product.Counter,
                        product_id = shoperProduct.product_id
                    };
                    reportOfChanges.Add(reportOfChange);
                }

            }
            List<Inventory> didntFind = new List<Inventory>();
            foreach (Inventory inventory in inventories)
            {
                if (!(shoperProductResponse.list.Exists(x => x.stock.Code.ToLower() == inventory.Sku.ToLower())))
                {
                    ReportOfChanges reportOfChange = new ReportOfChanges()
                    {
                        difference_of_stock = inventory.Counter,
                        realStock = inventory.Counter,
                        accepted = false,
                        name = "Brak produktu w magazynie shoper, lub nie spełnia założeń(zła kategoria)",
                        sku = inventory.Sku,
                        product_id = ""
                    };
                    reportOfChanges.Add(reportOfChange);
                }
            }
            return reportOfChanges;
        }
        public static async Task<List<ReportOfChanges>> GetAllCategoryListAsync(string token, string shopUrl, string category, List<Inventory> inventories)
        {
            List<ReportOfChanges> reportOfChanges = new List<ReportOfChanges>();
            ShoperProductResponse shoperProductResponse = new ShoperProductResponse();
            int page = 0;
            do
            {
                RestClient client = new RestClient(@"https://" + shopUrl + "/");
                RestRequest request = new RestRequest("webapi/rest/products?filters={\"category.category_id\":{\"=\":\""+category+"\"}}", Method.GET);
                request.AddHeader("Authorization", "Bearer " + token);
                request.AddParameter("limit", "50");
                request.AddParameter("page", page);
                var response = await client.ExecuteAsync(request);
                ShoperProductResponse _response = JsonConvert.DeserializeObject<ShoperProductResponse>(response.Content);
                if (page == 0)
                {
                    shoperProductResponse = _response;
                }
                else
                {
                    shoperProductResponse.list.AddRange(_response.list);
                }
                page += 1;
            } while (page != Int32.Parse(shoperProductResponse.pages));


            foreach (ShoperProduct shoperProduct in shoperProductResponse.list)
            {
                Inventory product = inventories.Find(x => x.Sku.ToLower() == shoperProduct.stock.Code.ToLower());
                if (product == null)
                {
                    ReportOfChanges reportOfChange = new ReportOfChanges()
                    {
                        difference_of_stock = 0 - Int32.Parse(shoperProduct.stock.stock),
                        accepted = true,
                        name = shoperProduct.translations.pl_PL.name,
                        realStock = 0,
                        sku = shoperProduct.stock.Code,
                        product_id = shoperProduct.product_id
                    };
                    reportOfChanges.Add(reportOfChange);
                }
                else
                {
                    ReportOfChanges reportOfChange = new ReportOfChanges()
                    {
                        difference_of_stock = product.Counter - Int32.Parse(shoperProduct.stock.stock),
                        accepted = true,
                        name = shoperProduct.translations.pl_PL.name,
                        sku = shoperProduct.stock.Code,
                        realStock = product.Counter,
                        product_id = shoperProduct.product_id
                    };
                    reportOfChanges.Add(reportOfChange);
                }

            }
            List<Inventory> didntFind = new List<Inventory>();
            foreach (Inventory inventory in inventories)
            {
                if (!(shoperProductResponse.list.Exists(x => x.stock.Code.ToLower() == inventory.Sku.ToLower())))
                {
                    ReportOfChanges reportOfChange = new ReportOfChanges()
                    {
                        difference_of_stock = inventory.Counter,
                        realStock = inventory.Counter,
                        accepted = false,
                        name = "Brak produktu w magazynie shoper, lub nie spełnia założeń(zła kategoria)",
                        sku = inventory.Sku,
                        product_id = ""
                    };
                    reportOfChanges.Add(reportOfChange);
                }
            }
            return reportOfChanges;
        }
        public static async Task<bool> ChangeStock (string token, string shopUrl, string id, string stock)
        {
            RestClient client = new RestClient(@"https://" + shopUrl + "/");
            RestRequest request = new RestRequest("webapi/rest/product-stocks/"+id.Trim(' '), Method.PUT);
            request.AddHeader("Authorization", "Bearer " + token);

            UpdateItem a= new UpdateItem();
            a.stock = stock;
            a.active = "true";
            string updateString = JsonConvert.SerializeObject(a);
            request.AddJsonBody(updateString);
            var response = await client.ExecuteAsync(request);
            if (response.Content == "1")
                return true;
            else
                return false;
        }

        public string Name { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }
        public string Product_id { get; set; }
        public int ExpectedStock { get; set; }
        public string Sku { get; set; }
        public string InventoryId { get; set; }
    }
    class UpdateItem
    {
        public string stock { get; set; }
        public string active { get; set; }
    }


}
