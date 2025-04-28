using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApp.Entities
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public int productid { get; set; }
        public int QuantityInStock { get; set; }
        public DateTime LastStockUpdate { get; set; }

    }
}
