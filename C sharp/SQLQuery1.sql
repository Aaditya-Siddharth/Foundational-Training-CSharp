Create database TechShop

use TechShop

create table Customers (
CustomerID Int Identity(100,1) PRIMARY Key NOT NULL, 
FirstName varchar(65) Not Null, 
LastName varchar(65) NOT NULL, 
Email Varchar(165) not null, 
Phone Varchar(15), 
Address varchar(max)); 

create table Products (
ProductID INT Identity (1,1) primary key NOT NULL, 
ProductName varchar(max) NOT NULL, 
Description Varchar(max) NOT NULL, 
Price numeric(18,2) NOT NULL) 


Create table Orders(
OrderID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
customerID INT Foreign Key References Customers(CustomerID), 
Orderdate datetime NOT NULL, 
TotalAmount numeric(18,2),
OrderStatus NVARCHAR(20))

select * from Orders

ALTER TABLE Orders
ALTER COLUMN OrderStatus VARCHAR(30) NOT NULL;

ALTER TABLE Orders
ADD CONSTRAINT DF_OrderStatus DEFAULT 'Pending' FOR OrderStatus;


-- Order Details Table
Create table OrderDetails(
OrderDetailID INT IDENTITY(1,1) primary Key NOT NULL, 
OrderID INT, 
ProductID INT, 
Quantity INT,
Constraint FK_Order_details_OrderID FOREIGN KEY(orderid) References Orders(orderid),
CONSTRAINT FK_Order_Details_ProductID FOREIGN Key(productid) References Products(productid))

ALTER TABLE OrderDetails
ALTER COLUMN Quantity Int NOT NULL;

--Inventory table
Create table Inventory(
InventoryID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
productid INT, 
QuantityInStock Int, 
LastStockUpdate dateTime,
CONSTRAINT FK_Inventory_Product FOREIGN KEY(productid) References Products(productid))

ALTER TABLE Inventory
ALTER COLUMN LastStockUpdate DateTime NOT NULL;

ALTER TABLE Inventory
ADD CONSTRAINT Inventory_LastStockUpdate_DATETIME DEFAULT GetDate() FOR LastStockUpdate;

-- Insert into Customers
INSERT INTO Customers (FirstName, LastName, Email, Phone, Address)
VALUES ('John', 'Doe', 'john.doe@example.com', '9876543210', '123 Main Street, Springfield');

-- Insert into Products
INSERT INTO Products (ProductName, Description, Price)
VALUES ('Wireless Mouse', 'Ergonomic wireless mouse with USB receiver', 799.99);

-- Insert into Orders
-- Assuming CustomerID is 100 (auto-generated starting from 100)
INSERT INTO Orders (CustomerID, OrderDate, TotalAmount, OrderStatus)
VALUES (100, GETDATE(), 799.99, DEFAULT); -- OrderStatus will default to 'Pending'

-- Insert into OrderDetails
-- Assuming OrderID = 1 and ProductID = 1 (based on identity settings)
INSERT INTO OrderDetails (OrderID, ProductID, Quantity)
VALUES (1, 1, 2);

-- Insert into Inventory
-- Assuming ProductID = 1
INSERT INTO Inventory (ProductID, QuantityInStock, LastStockUpdate)
VALUES (1, 50, GETDATE());
 

select * from Customers