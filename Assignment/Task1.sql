use TechShop

-- creating customer table

create table Customers (CustomerID Int Identity(100,1) PRIMARY Key NOT NULL, FirstName varchar(65) Not NUll,
                       LastName varchar(65) NOT NULL, Email Varchar(65) not null, Phone bigint, Address varchar(max));

-- creating products table 

create table Products (ProductID INT Identity (1,1) primary key NOT NULL, ProductName varchar(max) NOT NULL, Descreption Varchar(max), Price bigint NOT NULL)

-- creating orders table 

Create table Orders(OrderID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, customerID INT, Orderdate date NOT NULL, TotalAmount BigInt)
Alter Table Orders Add CONSTRAINT Order_CustomerID FOREIGN key(customerid) References Customers(customerid)

-- creating orderdetails table 

Create table OrderDetails(OrderDetailID INT IDENTITY(1,1) primary Key NOT NULL, OrderID INT, ProductID INT, Quantity BigInt,
                         Constraint FK_Order_details_OrderID FOREIGN KEY(orderid) References Orders(orderid),
                         CONSTRAINT FK_Order_Details_ProductID FOREIGN Key(productid) References Products(productid))
         
-- creating Inventory table 

Create table Invetory(InventoryID INT IDENTITY(1,1) PRIMARY KEY NOT NULL, productid INT, QuantityInStock Bigint, LastStockUpdate date
                     CONSTRAINT FK_Inventory_Product FOREIGN KEY(productid) References Products(productid))
                     
-- INSERTING INTO THE RESPECTIVE TABLES

-- Inserting into customers table 
Select * from Customers
Insert into Customers values ('Sampath', 'Kumar', 'sampathkumar@gmail.com', 9982156217, 'Raja Street, Ganapathy, Coimbatore'),
('Manikandan', 'KN', 'manikandan@gmail.com', 9212127712, 'Narayanasamy layout, Sanganoor, Coimbatore'),
('Karpagashiva', 'Kumar', 'kissk@gmail.com', 8712616217, 'KSK Nagar, Pudur, Pollachi'),
('Nivetha', 'Sugumar', 'niveSugu@gmail.com', 9922117621, 'Rajini Street, Elampillai, Salem'),
('Suresh', 'Raman', 'suresh.raman@gmail.com', 9345678123, 'Gandhi Road, Tiruppur'),
('Anitha', 'Mohan', 'anitha.mohan@gmail.com', 9456781234, 'Periyar Nagar, Erode'),
('Vignesh', 'Balaji', 'vignesh.b@gmail.com', 9554433212, 'Ayyappa Colony, Madurai'),
('Deepika', 'Rajesh', 'deepika.rajesh@gmail.com', 8899123456, 'Thillai Nagar, Trichy'),
('Ganesh', '', 'ganesh.k@gmail.com', 7788991122, 'Velachery, Chennai'),
('Ramya', 'Selvam', 'ramya.selvam@gmail.com', 9123456789, 'MGR Street, Karur'),
('Madhan', 'V', 'madhanv@gmail.com', 8223344556, 'New Bus Stand, Dindigul'),
('Harini', 'Kumar', 'harini.kumar@gmail.com', 9988776655, 'Anna Nagar, Chennai')

--inserting into Products table 
Insert INTO Products Values ('Laptop', 'High-performance laptop with Intel i7 processor', 75000),  
('Smartphone', 'Android smartphone with 128GB storage', 25000),  
('Wireless Earbuds', 'Noise-canceling wireless earbuds', 5000),  
('Smartwatch', 'Fitness smartwatch with heart rate monitor', 12000),  
('Gaming Console', 'Next-gen gaming console with 1TB storage', 55000),  
('Bluetooth Speaker', 'Portable Bluetooth speaker with deep bass', 8000),  
('External Hard Drive', '1TB external hard drive for data backup', 6000),  
('Mechanical Keyboard', 'RGB mechanical keyboard with blue switches', 4500),  
('DSLR Camera', 'Professional DSLR camera with 24MP lens', 65000),  
('Monitor', '27-inch 4K UHD monitor with HDR support', 30000),  
('Power Bank', '10000mAh fast-charging power bank', 2500),  
('Wireless Mouse', 'Ergonomic wireless mouse with adjustable DPI', 2000),  
('Graphics Card', 'High-end GPU with 12GB VRAM', 85000),  
('Headphones', 'Over-ear noise-canceling headphones', 7000),  
('Tablet', '10-inch tablet with stylus support', 28000);  

Select * from Products

--Inserting into the Orders table

Insert into Orders Values 
((SELECT customerid from Customers where firstname = 'Aaditya'), '2025-03-01', 75000),
(101, '2025-03-02', 25000),
(102, '2025-03-03', 5000),
(103, '2025-03-04', 12000),
(104, '2025-03-05', 55000),
(105, '2025-03-06', 8000),
(106, '2025-03-07', 6000),
(107, '2025-03-08', 4500),
(108, '2025-03-09', 65000),
(109, '2025-03-10', 30000);

Insert into Orders Values 
((SELECT customerid from Customers where firstname = 'Manikandan'), '2025-03-09', 90000)

Select * from Orders

Insert Into OrderDetails Values
(1, 1, 1),
(2, 2, 2),
(3, 3, 5),
(4, 4, 3),
(5, 5, 1),
(6, 6, 2),
(7, 7, 3),
(8, 8, 9),
(9, 9, 2),
(10, 10, 2);

Insert Into OrderDetails Values
((Select orderid from Orders where customerid=100), (Select productid from Products where productname ='Laptop'), 1),
((Select orderid from Orders where customerid=100), (Select productid from Products where productname ='Wireless Earbuds'), 3)


Select * from OrderDetails

-- inserting values into the Inventory tableCustomers
Insert into Invetory Values(1, 50, '2025-03-15'),
(2, 100, '2025-03-14'),
(3, 200, '2025-03-13'),
(4, 75, '2025-03-12'),
(5, 30, '2025-03-11'),
(6, 120, '2025-03-10'),
(7, 90, '2025-03-09'),
(8, 150, '2025-03-08'),
(9, 40, '2025-03-07'),
(10, 60, '2025-03-06'),
(11, 85, '2025-03-05'),
(12, 110, '2025-03-04'),
(13, 55, '2025-03-03'),
(14, 95, '2025-03-02'),
(15, 130, GetDate());

SELECT * FROM Invetory