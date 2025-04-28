using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechShopApp.DAO
{
    public interface ICustomersDao<T>
    {
        T SaveCustomerInfo(T Customers);
        bool DeleteCustomerInfo(int CustomerID);
        T UpdateCustomerInfo(T Customers);
        T GetCustomerInfoByID(int CustomerID);
        List<T> GetAllCustomerInfo(); 

    }
}
