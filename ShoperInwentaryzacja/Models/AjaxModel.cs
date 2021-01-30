using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoperInwentaryzacja.Models
{
    public class AjaxModel
    {
        public bool success { get; set; }
        public string sku { get; set; }
        public string inventoryId { get; set; }
        public string isSet { get; set; }

        public AjaxModel(ShoperItem _sku, string isSet)
        {
            success = true;
            sku = _sku.Sku;
            inventoryId = _sku.InventoryId;
            this.isSet = isSet;
        }
        public AjaxModel()
        {

        }
    }
}
