using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShopApp.Exceptions;


namespace TechShopApp.Entities
{
    public class Customers
    {
        public int CustomerID { get; set; }
        public String FirstName { get; set; }

        public String LastName { get; set; }
        public String? Email { get; set; }

        public String Phone { get; set; }

        public String Address { get; set; }

        public void validateCustomerID()
        {
            if (this.CustomerID is < 100)
            {
                throw new Exceptions.InvalidCustomerIDException();
            }
            //else
            //{
            //    Console.WriteLine("Valid Customer ID");
            //}
        }
    }
}
