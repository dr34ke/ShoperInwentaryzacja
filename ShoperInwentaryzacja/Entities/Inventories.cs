using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Entities
{
    public class Inventories
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string ShopId { get; set; }
        public string ShopUrl { get; set; }
        public string Name { get; set; }
        public string Option { get; set; }
        public string Sku { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }
}
