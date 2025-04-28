using AssetManagementApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementApp.DAO
{
    public interface IEmployeeDao<T>
    {
        T AddEmployee(T employee);
        bool DeleteEmployee(int employee_id);
        T UpdateEmployee(T employee);
        T GetEmployeeById(int employee_id);
        List<T> GetAllEmployees();
    }
}
