create database Academy;
use Academy;
create table Groups (
[Id] int primary key not null identity (1,1),
[Name] nvarchar(10) unique not null check ([Name] not like N''),
[Rating] int not null check ([Rating] >= 0 and [Rating] <= 5),
[Year] int not null check ([Year] >= 1 and [Year] <5));
create table Departments(
[Id] int primary key not null identity (1,1),
[Financing] money not null default 0 check ([Financing] >= 0),
[Name] nvarchar(100) not null unique check([Name] not like N''));
create table Faculties(
[Id] int primary key not null identity (1,1),
[Name] nvarchar(100) not null unique check([Name] not like N''));
create table Teachers(
[Id] int primary key not null identity (1,1),
[EmploymentDate] date not null check([EmploymentDate] > '1990-01-01'),
[Name] nvarchar(max) not null check ([Name] not like N''),
[Premium] money not null default 0 check ([Premium] >= 0),
[Salary] money not null check ([Salary] > 0),
[Surname] nvarchar(max) not null check ([Surname] not like N''));


