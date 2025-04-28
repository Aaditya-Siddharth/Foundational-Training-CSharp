using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApp.Entities
{
    public class Products
    {
        public int ProductID { get; set; }
        public String ProductName { get; set; }
        public String Description { get; set; }
        public Decimal Price { get; set; }
    }
}
