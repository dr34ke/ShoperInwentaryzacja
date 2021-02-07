using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Models
{
    public class ReportOfChanges
    {
        public string product_id { get; set; }
        public string sku { get; set; }
        public string category_id { get; set; }
        public float difference_of_stock { get; set; }
        public bool accepted { get; set; }
        public string name { get; set; }
        public float realStock { get; set; }
    }
}
