using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Models
{
    public class ShoperProductResponse
    {
        public string pages { get; set; }
        public List<ShoperProduct> list { get; set; }
    }
    public class ShoperProduct
    {
        public string product_id { get; set; }
        public Stock stock { get; set; }
        public Translations translations { get; set; }
    }
    public class Stock
    {
        public string stock { get; set; }
        public string price { get; set; }
        public string Code { get; set; }
    }
    public class Translations
    {
        public pl_PL pl_PL { get; set; }
    }
    public class pl_PL
    {
        public string name { get; set; }
    }

}
