create database Academy;
create table Departments
(
    Id        int primary key      not null identity (1,1),
    Financing money                not null default 0 check (Financing >= 0),
    Name      nvarchar(100) unique not null check (Name not like N''),
)
create table Faculties
(
    Id int primary key not null identity (1,1),
    Dean nvarchar(max) not null check(Dean not like N''),
    Name nvarchar(100) not null unique check(Name not like N''),
)
create table Groups
(
    Id int primary key not null identity (1,1),
    Name nvarchar(10) not null unique check(Name not like N''),
    Rating int not null check(Rating between 0 and 5),
    Year int not null check(Year between 0 and 5),
)
create table Teachers (
    Id int not null primary key identity(1,1),
    EmploymentDate date not null check(EmploymentDate >= '1990-01-01'),
    IsAssistant bit not null default 0,
    IsProfessor bit not null default 0,
    Name nvarchar(max) not null check(Name not like N''),
    Position nvarchar(max) not null check (Position not like N''),
    Premium money not null default 0 check (Premium >= 0),
    Salary money not null check(Salary > 0),
    Surname nvarchar(max) not null check (Surname not like N''))

insert into Departments(Financing, Name)  values (100000,N'Computer Engineering')
insert into Departments(Financing, Name) values (260000,N'Software Development')
insert into Departments(Financing, Name) values (130000,N'Mathematics')
insert into Departments(Financing, Name) values (266000,N'Web design')
insert into Departments(Financing, Name) values(220000,N'Finances')

insert into Faculties(Dean, Name) values (N'Yaqub Sardarov',N'Computer Science')
insert into Faculties (Dean, Name) values (N'Inara Aliyeva',N'IT');
insert into Faculties(Dean, Name) values(N'Farida Ragimova',N'UI/UX design')
insert into Faculties(Dean, Name) values(N'Zakir Mamedov',N'Management')

insert into Groups(Name, Rating, Year) values (N'120E',2,3)
insert into Groups(Name, Rating, Year) values (N'120D',4,3)
insert into Groups(Name, Rating, Year) values (N'110E',3,4)
insert into Groups(Name, Rating, Year) values (N'110D',4,1)

insert into Teachers(EmploymentDate, IsAssistant, IsProfessor, Name, Position, Premium, Salary, Surname) values ('1999-10-9',0,1,N'Cavad',N'Math teacher',200,2000,N'Quliyev')
insert into Teachers(EmploymentDate, IsAssistant, IsProfessor, Name, Position, Premium, Salary, Surname) values ('2009-11-9',1,0,N'Cavid',N'Web design assistant',170,900,N'Quseynov')
insert into Teachers(EmploymentDate, IsAssistant, IsProfessor, Name, Position, Premium, Salary, Surname) values ('2012-12-9',0,1,N'Irada',N'Programming teacher',650,2700,N'Quseynova')
insert into Teachers(EmploymentDate, IsAssistant, IsProfessor, Name, Position, Premium, Salary, Surname) values ('2007-10-9',0,1,N'Laman',N'Management assistant',250,700,N'Mamedova')
insert into Teachers(EmploymentDate, IsAssistant, IsProfessor, Name, Position, Premium, Salary, Surname) values ('2018-10-9',0,1,N'Milana',N'Web design teacher',760,2500,N'Rzaeva')
insert into Teachers(EmploymentDate, IsAssistant, IsProfessor, Name, Position, Premium, Salary, Surname) values ('1996-10-9',0,1,N'Suel',N'Management teacher',450,1800,N'Aliyeva')

-- Query 1
select * from Departments order by id desc;
-- Query 2
select Name as N'Group Name' , Rating as N'Group Rating' from Groups;
-- Query 3
select Surname , (Salary * 100 / Premium) ,(Salary * 100 / Salary + Premium) from Teachers;
-- Query 4
select 'The dean of faculty ' + Name + ' is ' + Dean from Faculties;
-- Query 5
select Surname from Teachers where IsProfessor = 1 and Salary > 1050 ;
-- Query 6
select Name from Departments where Financing < 11000 or Financing > 25000;
-- Query 7
select Name from Faculties where Name != N'Computer Science';
-- Query 8
select Surname,Position from Teachers where IsProfessor = 0;
-- Query 9
select  Surname,Position,Surname,Premium from Teachers where IsAssistant=1 and Premium between 160 and 550;
-- Query 10
select Surname,Salary from Teachers where IsAssistant=1;
-- Query 11
select Surname,Position from Teachers where EmploymentDate < '2000-01-01';
-- Query 12
select Name as "Name of Department" from Departments where Name < 'Software Development' order by Name;
-- Query 13
select  Surname from Teachers where IsAssistant=1 and (Salary + Premium < 1200);
-- Query 14
select Name from Groups where (Rating between 0 and 4 ) and Year = 5;
-- Query 15
select Surname from Teachers where IsAssistant = 1 and (Salary < 550 or Premium < 200);
