-- SQL Query to retrieve names and emails of all customers 

Select (firstname+' '+lastname) as Name, email from Customers

-- List of all orders with their order dates and corresponding customer names

Select orderid, orderdate, (Select (firstname+' '+lastname) from Customers as c where o.customerID = c.CustomerID ) from Orders as o

-- Insert new customer record

Insert into Customers(firstname, lastname, email, address) values ('Surendar','Duraisamy','Surendardurai@gmail.com','Chitra veedhi, Kannapanagar, Coimbatore')

-- Increasing the price of products by 10%

update Products SET price = price+(Products.price *0.1)
Select * from Products

Select * from Orders


-- Deleting a record from OrderDetails and Orders table
CREATE PROCEDURE DELETE_ORDER_DETAILS
    @orderID INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM OrderDetails WHERE OrderID = @orderID;
    DELETE FROM Orders WHERE OrderID = @orderID;
END;
GO


Exec DELETE_ORDER_DETAILS @OrderID = 10;

Select * from Orders


-- Inserting new record into the table Orders

Insert Into orders(customerID,Orderdate,TotalAmount) Values
(102,GETDATE(),75000);
Select * from Orders


-- Updating a Contact information

Select * from Customers

CREATE PROCEDURE UPDATE_CUSTOMER_CONTACT
    @CustomerID INT, @email varchar(65), @address varchar(max)
AS
BEGIN
    SET NOCOUNT ON;

    Update Customers set Email = @email Where CustomerID = @CustomerID
	Update Customers set Address = @address Where CustomerID = @CustomerID

END;
GO
-- Execute
Exec UPDATE_CUSTOMER_CONTACT @CustomerID = 103,
@email = 'nivetha@gmail.com',
@address = 'Raman Street, Elampillai, Salem';

Select * from Customers


-- Recalculate

Update Orders
Set TotalAmount = (select sum(od.Quantity*p.Price)
from OrderDetails od
join Products p on od.ProductID=p.ProductID
where od.OrderID=orders.OrderID)

Select * from Orders

-- Delete order , and order details of customer
delete from OrderDetails where OrderID in (Select OrderId from Orders where CustomerID=7)
delete from Orders where CustomerID=7

-- Insert into products

Insert into Products(ProductName, Descreption, Price) values
('Power Bank', '5000 Mah with C type I/O', 8500)

Select * From Products

-- Update the status of order
alter table Orders add Status varchar(30)
Update Orders
Set Status='Pending'

Update Orders
Set Status='Shipped'
where OrderID=1

Select * from Orders


--Update The count of customer orders per customer

alter table Customers add OrderCount int

Select * from Customers
Update Customers set OrderCount = (Select count(*) from Orders)
where Customers.CustomerID = Orders.customerID

