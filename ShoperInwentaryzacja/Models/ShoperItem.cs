using Newtonsoft.Json;
using RestSharp;
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
        public string Name { get; set; }
        public string Price { get; set; }
        public int Stock { get; set; }
        public string Product_id { get; set; }
        public int ExpectedStock { get; set; }
        public string Sku { get; set; }
        public string InventoryId { get; set; }
    }
}
