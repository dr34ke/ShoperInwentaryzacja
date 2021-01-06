using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Entities
{
    public class StockCheck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Category { get; set; }
    }
}
