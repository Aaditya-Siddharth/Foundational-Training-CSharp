using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApp.Entities
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int customerID { get; set; }
        public  DateTime Orderdate { get; set; }
        public Decimal TotalAmount { get; set; }
        public String OrderStatus { get; set; }
    }
}
