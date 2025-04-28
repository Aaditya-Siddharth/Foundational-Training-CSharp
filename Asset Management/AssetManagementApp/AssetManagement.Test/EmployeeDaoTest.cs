using NUnit.Framework;
using AssetManagementApp.DAO;
using AssetManagementApp.Entity;
using System.Collections.Generic;

namespace AssetManagementApp.Tests
{
    [TestFixture]
    public class EmployeeDAOTests
    {
        private EmployeeDAO dao;

        [SetUp]
        public void Setup()
        {
            dao = new EmployeeDAO();
        }

        [Test]
        public void AddEmployee_ShouldInsertAndReturnEmployee()
        {
            // Arrange
            Employees emp = new Employees
            {
                name = "Test User",
                department = "QA",
                email = "testuser@example.com",
                password = "password123"
            };

            // Act
            var result = dao.AddEmployee(emp);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test User", result.name);
        }

        [Test]
        public void GetAllEmployees_ShouldReturnList()
        {
            List<Employees> employees = dao.GetAllEmployees();
            Assert.IsNotNull(employees);
            Assert.IsInstanceOf<List<Employees>>(employees);
        }

        //[Test]
        [Test]
        public void GetEmployeeById_ShouldReturnCorrectEmployee()
        {
            // Arrange – insert a known test employee first
            Employees testEmp = new Employees
            {
                name = "John Tester",
                department = "QA",
                email = "john.tester@example.com",
                password = "test123"
            };
            var added = dao.AddEmployee(testEmp);

            // Act
            var result = dao.GetEmployeeById(added.employee_Id);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(added.name, result.name);
            Assert.AreEqual(added.email, result.email);
        }


        [Test]
        public void UpdateEmployee_ShouldModifyEmployeeDetails()
        {
            // Arrange – insert a new employee to update
            Employees testEmp = new Employees
            {
                name = "Temp User",
                department = "Dev",
                email = "temp@example.com",
                password = "temp123"
            };
            var added = dao.AddEmployee(testEmp);

            // Act – modify and update
            added.name = "Updated User";
            var updated = dao.UpdateEmployee(added);

            // Assert
            Assert.IsNotNull(updated);
            Assert.AreEqual("Updated User", updated.name);

            // Optionally verify from DB again
            var fromDb = dao.GetEmployeeById(added.employee_Id);
            Assert.AreEqual("Updated User", fromDb.name);
        }


        [Test]
        public void DeleteEmployee_ShouldRemoveEmployee()
        {
            Employees emp = new Employees
            {
                name = "ToDelete",
                department = "IT",
                email = "delete@example.com",
                password = "testpass"
            };
            var added = dao.AddEmployee(emp);

            bool deleted = dao.DeleteEmployee(added.employee_Id);
            Assert.IsTrue(deleted);
        }
    }
}
