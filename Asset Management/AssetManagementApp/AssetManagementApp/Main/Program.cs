using AssetManagementApp.DAO;
using AssetManagementApp.Entity;
using System;
using System.Collections.Generic;

namespace AssetManagementApp.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployeeDao<Employees> employeeDao = new EmployeeDAO();
            IAssetDao<Assets> assetDao = new AssetDAO();
            IReservationDao<Reservation> reservationDao = new ReservationDAO();
            IAssetAllocationDao<AssetAllocation> allocationDao = new AssetAllocationDAO();
            IMaintenanceDao<MaintenanceRecord> maintenanceDao = new MaintenanceDAO();

            while (true)
            {
                Console.WriteLine("\n=== Asset Management System ===");
                Console.WriteLine("1. Employee Management");
                Console.WriteLine("2. Asset Management");
                Console.WriteLine("3. Reservation Management");
                Console.WriteLine("4. Asset Allocation Management");
                Console.WriteLine("5. Maintenance Management");
                Console.WriteLine("6. Exit");
                Console.WriteLine("6. Exit");
                Console.WriteLine();
                string mainChoice = Console.ReadLine();

                switch (mainChoice)
                {
                    case "1":
                        ManageEmployees(employeeDao);
                        break;
                    case "2":
                        ManageAssets(assetDao);
                        break;
                    case "3":
                        ManageReservations(reservationDao);
                        break;
                    case "4":
                        ManageAssetAllocations(allocationDao);
                        break;
                    case "5":
                        ManageMaintenance(maintenanceDao);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void ManageEmployees(IEmployeeDao<Employees> dao)
        {
            Console.WriteLine("\n--- Employee Management ---");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. View All Employees");
            Console.WriteLine("3. Get Employee by ID");
            Console.WriteLine("4. Update Employee");
            Console.WriteLine("5. Delete Employee");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Employees emp = new Employees();
                    Console.Write("Name: "); emp.name = Console.ReadLine();
                    Console.Write("Department: "); emp.department = Console.ReadLine();
                    Console.Write("Email: "); emp.email = Console.ReadLine();
                    Console.Write("Password: "); emp.password = Console.ReadLine();
                    dao.AddEmployee(emp);
                    Console.WriteLine("Employee added.");
                    break;
                case "2":
                    List<Employees> emps = dao.GetAllEmployees();
                    foreach (var e in emps)
                        Console.WriteLine($"{e.employee_Id} - {e.name} - {e.department} - {e.email}");
                    break;
                case "3":
                    Console.Write("Enter ID: ");
                    int empId = Convert.ToInt32(Console.ReadLine());
                    var empFound = dao.GetEmployeeById(empId);
                    if (empFound != null)
                        Console.WriteLine($"{empFound.employee_Id} - {empFound.name} - {empFound.department} - {empFound.email}");
                    else
                        Console.WriteLine("Employee not found.");
                    break;
                case "4":
                    Console.Write("Employee ID to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Employees updateEmp = dao.GetEmployeeById(updateId);
                    if (updateEmp != null)
                    {
                        Console.Write("Name: "); updateEmp.name = Console.ReadLine();
                        Console.Write("Department: "); updateEmp.department = Console.ReadLine();
                        Console.Write("Email: "); updateEmp.email = Console.ReadLine();
                        Console.Write("Password: "); updateEmp.password = Console.ReadLine();
                        dao.UpdateEmployee(updateEmp);
                        Console.WriteLine("Employee updated.");
                    }
                    else
                        Console.WriteLine("Employee not found.");
                    break;
                case "5":
                    Console.Write("Enter ID to delete: ");
                    int deleteId = Convert.ToInt32(Console.ReadLine());
                    if (dao.DeleteEmployee(deleteId))
                        Console.WriteLine("Deleted successfully.");
                    else
                        Console.WriteLine("Delete failed.");
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }

        static void ManageAssets(IAssetDao<Assets> dao)
        {
            Console.WriteLine("\n--- Asset Management ---");
            Console.WriteLine("1. Add Asset");
            Console.WriteLine("2. View All Assets");
            Console.WriteLine("3. Get Asset by ID");
            Console.WriteLine("4. Update Asset");
            Console.WriteLine("5. Delete Asset");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Assets asset = new Assets();
                    Console.Write("Name: "); asset.name = Console.ReadLine();
                    Console.Write("Status: "); asset.status = Console.ReadLine();
                    Console.Write("Purchase Date (yyyy-MM-dd): ");
                    asset.purchasedate = DateTime.Parse(Console.ReadLine());
                    dao.AddAsset(asset);
                    Console.WriteLine("Asset added.");
                    break;

                case "2":
                    var list = dao.GetAllAssets();
                    foreach (var a in list)
                        Console.WriteLine($"{a.asset_id} - {a.name} - {a.status} - {a.purchasedate.ToShortDateString()}");
                    break;

                case "3":
                    Console.Write("Asset ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var found = dao.GetAssetById(id);
                    if (found != null)
                        Console.WriteLine($"{found.asset_id} - {found.name} - {found.status} - {found.purchasedate.ToShortDateString()}");
                    else
                        Console.WriteLine("Asset not found.");
                    break;

                case "4":
                    Console.Write("Asset ID to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Assets updateAsset = dao.GetAssetById(updateId);
                    if (updateAsset != null)
                    {
                        Console.Write("Name: "); updateAsset.name = Console.ReadLine();
                        Console.Write("Status: "); updateAsset.status = Console.ReadLine();
                        Console.Write("Purchase Date (yyyy-MM-dd): "); updateAsset.purchasedate = DateTime.Parse(Console.ReadLine());
                        dao.UpdateAsset(updateAsset);
                        Console.WriteLine("Asset updated.");
                    }
                    else
                    {
                        Console.WriteLine("Asset not found.");
                    }
                    break;
                case "5":
                    Console.Write("Asset ID to delete: ");
                    int delId = Convert.ToInt32(Console.ReadLine());
                    if (dao.DeleteAsset(delId))
                        Console.WriteLine("Asset deleted.");
                    else
                        Console.WriteLine("Delete failed.");
                    break;
            }
        }

        static void ManageReservations(IReservationDao<Reservation> dao)
        {
            Console.WriteLine("\n--- Reservation Management ---");
            Console.WriteLine("1. Create Reservation");
            Console.WriteLine("2. View All Reservations");
            Console.WriteLine("3. Get Reservation by ID");
            Console.WriteLine("4. Update Reservation");
            Console.WriteLine("5. Cancel Reservation");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Reservation res = new Reservation();
                    Console.Write("Asset ID: "); res.asset_id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Employee ID: "); res.employee_id = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Date (yyyy-MM-dd): "); res.reservation_date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Status: "); res.status = Console.ReadLine();
                    dao.CreateReservation(res);
                    Console.WriteLine("Reservation created.");
                    break;
                case "2":
                    var list = dao.GetAllReservations();
                    foreach (var r in list)
                        Console.WriteLine($"{r.reservation_id} - {r.asset_id} - {r.employee_id} - {r.reservation_date} - {r.status}");
                    break;
                case "3":
                    Console.Write("Reservation ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var found = dao.GetReservationById(id);
                    if (found != null)
                        Console.WriteLine($"{found.reservation_id} - {found.asset_id} - {found.employee_id} - {found.reservation_date} - {found.status}");
                    else
                        Console.WriteLine("Not found.");
                    break;
                case "4":
                    Console.Write("Reservation ID to update: ");
                    int updateId = Convert.ToInt32(Console.ReadLine());
                    Reservation update = dao.GetReservationById(updateId);
                    if (update != null)
                    {
                        Console.Write("Asset ID: "); update.asset_id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Employee ID: "); update.employee_id = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Date: "); update.reservation_date = DateTime.Parse(Console.ReadLine());
                        Console.Write("Status: "); update.status = Console.ReadLine();
                        dao.UpdateReservation(update);
                        Console.WriteLine("Updated.");
                    }
                    else
                        Console.WriteLine("Not found.");
                    break;
                case "5":
                    Console.Write("Reservation ID to cancel: ");
                    int delId = Convert.ToInt32(Console.ReadLine());
                    if (dao.CancelReservation(delId))
                        Console.WriteLine("Cancelled.");
                    else
                        Console.WriteLine("Failed.");
                    break;
            }
        }

        static void ManageAssetAllocations(IAssetAllocationDao<AssetAllocation> dao)
        {
            Console.WriteLine("\n--- Asset Allocation Management ---");
            Console.Write("Asset ID: ");
            int assetId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Employee ID: ");
            int empId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Allocation Date (yyyy-MM-dd): ");
            DateTime allocDate = DateTime.Parse(Console.ReadLine());

            AssetAllocation allocation = new AssetAllocation
            {
                asset_id = assetId,
                employee_id = empId,
                allocation_date = allocDate
            };

            dao.AllocateAsset(allocation);
            Console.WriteLine("Asset allocated.");
        }

        static void ManageMaintenance(IMaintenanceDao<MaintenanceRecord> dao)
        {
            Console.WriteLine("\n--- Maintenance Management ---");
            Console.Write("Asset ID: ");
            int assetId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.Write("Description: ");
            string desc = Console.ReadLine();
            Console.Write("Cost: ");
            decimal cost = Convert.ToDecimal(Console.ReadLine());

            MaintenanceRecord record = new MaintenanceRecord
            {
                asset_id = assetId,
                maintenance_date = date,
                description = desc,
                cost = cost
            };

            dao.AddMaintenanceRecord(record);
            Console.WriteLine("Maintenance record added.");
        }
    }
}
