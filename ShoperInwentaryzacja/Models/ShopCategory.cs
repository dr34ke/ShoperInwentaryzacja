using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Models
{
    public class ShopCategories
    {
        public ShopCategories()
        {
           
        }
        public static async Task<ShopCategories> GetCategories(string ShopUrl, string Token)
        {
            int i = 0;
            ShopCategories shopCategories = new ShopCategories();
                do
                {
                    i++;
                    RestClient client = new RestClient(@"https://"+ShopUrl+"/webapi/rest/");
                    RestRequest request = new RestRequest("categories");
                    request.AddHeader("Authorization", "Bearer " + Token);
                    request.AddParameter("page", i);
                    request.AddParameter("limit", "50");
                    var response = await client.ExecuteAsync(request);
                    ShopCategories x = JsonConvert.DeserializeObject<ShopCategories>(response.Content);
                    shopCategories.count = x.count;
                    shopCategories.pages = x.pages;
                    shopCategories.list.AddRange(x.list);
                } while (i != Int32.Parse(shopCategories.pages));
            return shopCategories;
            
        }
        public string count { get; set; }
        public string pages { get; set; }
        public List<Category> list {
            get
            {
                if (_list == null)
                    _list = new List<Category>();
                return _list;
            }
            set
            {
                _list = value;
            }
        }
        private List<Category> _list { get; set; }
    }
    public class Category
    {
        public Category()
        {
        }
        public string category_id { get; set; }
        public CategoryTranslations translations { get; set; }
    }
    public class CategoryTranslations
    {
        public Categorypl_PL pl_PL { get; set; }
    }
    public class Categorypl_PL
    {
        public string name { get; set; }
    }
}

