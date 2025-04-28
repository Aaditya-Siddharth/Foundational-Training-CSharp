using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechShopApp.DAO;
using TechShopApp.Entities;

namespace TechShopApp.Main
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== TechShop Menu =====");
                Console.WriteLine("1. Customer Registration");
                Console.WriteLine("2. Update Customer record");
                Console.WriteLine("3. Get Customer by ID");
                Console.WriteLine("4. Get All records");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");

                var choice = Convert.ToInt32(Console.ReadLine());

                CustomerDao customerDao= new CustomerDao();
                switch (choice)
                {
                    case 1:
                        //save product

                        Customers customer = new Customers();
                        Console.WriteLine("--- Register Customer ---");
                        //Console.Write("Customer ID: ");
                        //customer.CustomerID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("First Name: ");
                        customer.FirstName = Convert.ToString(Console.ReadLine());
                        
                        Console.Write("Last Name: ");
                        customer.LastName = Convert.ToString(Console.ReadLine());
                        Console.Write("Email: ");
                        customer.Email = Convert.ToString(Console.ReadLine());
                        Console.Write("Phone: ");
                        customer.Phone = Convert.ToString(Console.ReadLine());
                       Console.Write("Address: ");
                        customer.Address = Convert.ToString(Console.ReadLine());
                        var newCustomer = customerDao.SaveCustomerInfo(customer);
                        Console.WriteLine(newCustomer != null ? "New Customer Added" : "Error");
                        break;
                    case 2:
                        //Update Customer
                        Customers customers = new Customers();
                        Console.WriteLine("--- Update Customer ---");
                        Console.Write("Customer ID: ");
                        customers.CustomerID = Convert.ToInt32(Console.ReadLine());
                        Console.Write("First Name: ");
                        customers.FirstName = Convert.ToString(Console.ReadLine());
                        Console.Write("Last Name: ");
                        customers.LastName = Convert.ToString(Console.ReadLine());
                        Console.Write("Email: ");
                        customers.Email = Convert.ToString(Console.ReadLine());
                        Console.Write("Phone: ");
                        customers.Phone = Convert.ToString(Console.ReadLine());
                        Console.Write("Address: ");
                        customers.Address = Convert.ToString(Console.ReadLine());
                        var updateCustomer = customerDao.UpdateCustomerInfo(customers);
                        Console.WriteLine(updateCustomer != null ? "Customer Record Updated" : "Customer Record Updated not");
                        break;

                    case 3:

                        // Get Customer by ID
                        var id = 1;
                        var customerByID = customerDao.GetCustomerInfoByID(id);
                        Console.WriteLine($"{customerByID.CustomerID}\t{customerByID.FirstName}\t{customerByID.LastName}\t{customerByID.Email}\t{customerByID.Phone}\t{customerByID.Address}");
                        break;
                    case 4:

                        // get all products
                        var allPets = petDao.GetAllPets();  // Assuming petDao is an instance of PetDao
                        foreach (var pet in allPets)
                        {
                            Console.WriteLine($"Pet ID: {pet.PetID}, Name: {pet.Name}, Age: {pet.Age}, Breed: {pet.Breed}, Type: {pet.Type}, Available for Adoption: {pet.AvailableForAdoption}, Shelter ID: {pet.ShelterID}");
                        }

                        break;
                    //case "3":
                    //    PlaceOrder();
                    //    break;
                    //case "4":
                    //    TrackOrderStatus();
                    //    break;
                    //case "5":
                    //    ManageInventory();
                    //    break;
                    //case "6":
                    //    GenerateSalesReport();
                    //    break;
                    //case "7":
                    //    UpdateCustomerAccount();
                    //    break;
                    //case "8":
                    //    ProcessPayment();
                    //    break;
                    //case "9":
                    //    SearchProducts();
                    //    break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Try again.");
                        break;
                }
              }
        }

       

    }
}
