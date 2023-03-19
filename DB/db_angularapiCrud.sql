-- ============ DATABASE ===============
create database db_angularapiCrud

use db_angularapiCrud

-- ============ TABLES ===============
create table Department(
 departmentId int primary key identity,
 departmentName varchar(50),
 createdDate datetime default getdate()
)

create table Employee(
 employeeId int primary key identity,
 employeeName varchar(50),
 departmentId int references Department(departmentId),
 salary int,
 contractDate datetime,
 createdDate datetime default getdate()
)

-- ============ INSERTS ===============
insert into Department (departmentName) values
('Management'),
('Commerce'),
('Sales'),
('Marketing')

insert into Employee (employeeName, departmentId, salary, contractDate) values
('John Smith', 1, 2000, getdate())