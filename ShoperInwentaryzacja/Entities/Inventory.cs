using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Entities
{
    public class Inventory
    {

        public int Id { get; set; }
        public int InventoryId { get; set; }
        public string Sku { get; set; }
        public int Counter { get; set; }
    }
}
