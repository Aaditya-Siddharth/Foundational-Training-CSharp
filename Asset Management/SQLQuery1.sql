Create database AssetManagementDB

use AssetManagementDB

Create table employees(
employee_id int Identity(100,1) Primary Key not null,
name Varchar(80) not null,
department varchar(80) not null,
email varchar(80) not null,
password varchar(25) not null
)

create table assets(
asset_id int identity(1,1) primary key not null,
name varchar(80) not null,
Type varchar(80) not null,
serial_number int not null,
purchasedate date default Getdate() not null,
location varchar(80) not null,
status varchar(65) default 'In Use' not null,
owner_id int foreign key references employees(employee_id)
)

create table maintenance_records(
maintenance_id int identity(1,1) primary key not null,
asset_id int foreign key references assets(asset_id) not null,
maintenance_date date default getdate() not null,
description varchar(max) not null,
cost numeric(18,2) not null
)


create table asset_allocations(
allocation_id int identity(1,1) primary key not null,
asset_id int foreign key references assets(asset_id) not null,
employee_id int foreign key references employees(employee_id) not null,
allocation_date date not null,
return_date date
)

create table reservations(
reservation_id int identity(100,1) primary key not null,
asset_id int foreign key references assets(asset_id) not null,
employee_id int foreign key references employees(employee_id) not null,
reservation_date date default getdate() not null,
start_date date,
end_date date,
status varchar(80) default 'pending' not null
)

select * from assets