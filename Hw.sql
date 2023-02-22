create database Barbershop1;
use Barbershop1;
create table Barbers (
Id int primary key identity (1,1),
FullName nvarchar(100),
Gender nvarchar(10),
PhoneNumber nvarchar(20),
Email nvarchar(255),
BirthDate date,
HireDate date,
Position nvarchar(20)
);
create table Clients (
Id int primary key identity (1,1),
FullName nvarchar(100),
PhoneNumber nvarchar(20),
Email nvarchar(255),
Feedback nvarchar(255),
Rating nvarchar(20)
);
Create table Schedules (
Id int primary key identity (1,1),
BarberId int foreign key references  Barbers(id),
AvailableDate datetime,
ClientId int foreign key references  clients(id),
BusyDate datetime,
);

create table VisitsArchive (
Id int primary key identity (1,1),
ClientId int foreign key references Clients(id),
BarberId int foreign key references  Barbers(id),
ServiceName nvarchar(100),
Date date,
TotalPrice money,
Rating nvarchar(20),
Feedback nvarchar(255)
);
create table Services(
Id int primary key identity (1,1),
BarberId int foreign key references  Barbers(id),
ServiceName nvarchar(100),
Price money,
Time Time
)


insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Arny Pontin', 'Male', '952-865-9314', 'apontin0@un.org', '06.09.1985', '11.07.2015', 'Chief');
insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Filip Coneron', 'Male', '470-777-1181', 'fconeron1@eventbrite.com', '24.10.1996', '22.01.2021', 'Senior');
insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Rudolf Crusham', 'Male', '782-181-1485', 'rcrusham2@cyberchimps.com', '24.04.1975', '09.07.2017', 'Senior');
insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Yves Peasgood', 'Male', '197-151-8324', 'ypeasgood3@rakuten.co.jp', '21.09.1988', '14.01.2019', 'Senior');
insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Dennison Dearlove', 'Male', '485-483-7446', 'ddearlove4@europa.eu', '04.02.1984', '12.12.2020', 'Junior');
insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Edmund Bruck', 'Male', '450-682-3226', 'ebruck5@go.com', '21.02.1979', '02.11.2017', 'Junior');
insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Cort Reading', 'Male', '422-609-3634', 'creading6@pcworld.com', '14.06.1988', '12.08.2017', 'Junior');
insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Hobie Ingreda', 'Male', '707-888-3188', 'hingreda7@amazon.co.uk', '06.11.1986', '21.03.2016', 'Junior');
insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Tori Leggett', 'Female', '707-262-7342', 'tleggett8@t.co', '30.09.1990', '21.01.2023', 'Junior');
insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Maurise Hugh', 'Female', '809-135-2633', 'mhugh9@51.la', '24.04.1976', '12.01.2020', 'Junior');

insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Kylen Laborda', '238-216-2174', 'klaborda0@fda.gov', 'est risus', 'nulla');
insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Audra Caustick', '177-654-0259', 'acaustick1@washingtonpost.com', 'aenean fermentum', 'eget elit');
insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Sheelagh Fice', '540-388-7768', 'sfice2@baidu.com', 'justo etiam', 'nunc rhoncus');
insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Mehetabel Vero', '274-438-8863', 'mvero3@columbia.edu', 'lectus pellentesque', 'cras');
insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Cristie Waleran', '916-763-4469', 'cwaleran4@usgs.gov', 'purus', 'integer');
insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Teriann Mowle', '872-298-1206', 'tmowle5@chron.com', 'quisque', 'sollicitudin');
insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Tory Hallihane', '859-878-5604', 'thallihane6@webnode.com', 'hac', 'et eros');
insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Darcee Schouthede', '918-228-9566', 'dschouthede7@diigo.com', 'odio in', 'eleifend pede');
insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Essy Sprackling', '228-491-7460', 'esprackling8@ucla.edu', 'dapibus nulla', 'sociis');
insert into Clients (FullName, PhoneNumber, Email, Feedback, Rating) values ('Vida Hartrick', '549-192-2010', 'vhartrick9@mail.ru', 'platea dictumst', 'morbi');

insert into Services(BarberId, ServiceName, Price, Time) values (11,'Traditional shaving',10,'1:3')
insert into Services(BarberId, ServiceName, Price, Time) values (14,'Beard Grooming',10,'1:3')
insert into Services(BarberId, ServiceName, Price, Time) values (17,'Colours and Treatment',10,'1:3')

insert into VisitsArchive(ClientId, BarberId, ServiceName, Date, TotalPrice, Rating, Feedback) values (22,21,'Traditional shaving','21.01.2023',12,'Good','Like it')
insert into VisitsArchive(ClientId, BarberId, ServiceName, Date, TotalPrice, Rating, Feedback) values (22,24,'Beard Grooming','23.01.2023',12,'Good','Like it')
insert into VisitsArchive(ClientId, BarberId, ServiceName, Date, TotalPrice, Rating, Feedback) values (22,21,'Beard Grooming','30.01.2023',12,'Good','Like it')
insert into VisitsArchive(ClientId, BarberId, ServiceName, Date, TotalPrice, Rating, Feedback) values (29,17,'Beard Grooming','23.01.2023',12,'Good','Like it')
insert into VisitsArchive(ClientId, BarberId, ServiceName, Date, TotalPrice, Rating, Feedback) values (28,17,'Colours and Treatment','01.01.2023',12,'Good','Like it')

go
create procedure GetBarbers  as select * from Barbers
go
exec GetBarbers;
go

create procedure GetSeniors  as select * from Barbers where Position = 'Senior'
go
exec GetSeniors;
go

create procedure GetTraditionalShavingBarbers as select B.Id, FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position from Barbers B
    inner join Services S on B.Id = S.BarberId where ServiceName = 'Traditional shaving'
go
exec GetTraditionalShavingBarbers
go

create function GetGivenServiceBarberss (@ServiceName nvarchar(20))
returns table as
    return select B.Id, FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position from Barbers B
    inner join Services S on B.Id = S.BarberId where ServiceName = @ServiceName
go
select * from GetGivenServiceBarberss ('Beard Grooming')
go

create  procedure GetGivenExperienceBarbers (@Year int)
as  select * from Barbers B where  datediff(year, HireDate, GETDATE()) >= @Year
go
exec GetGivenExperienceBarbers @Year = 15
go

create procedure GetCountJuniorSenior
as
begin
    select COUNT(*) as JuniorBarberCount from Barbers where Position = 'Junior'
    union
    select COUNT(*) as SeniorBarberCount from Barbers where Position = 'Senior'
end
go
exec GetCountJuniorSenior
go
create procedure GetClients(@quantity int)
as
begin
    select * from Clients
    where (select count(*) from VisitsArchive where  VisitsArchive.ClientId = Clients.Id) >= @quantity
end
go
exec GetClients @quantity = 3
go

create trigger PreventDeletion ON Barbers
for delete
as
if (select COUNT(*) from Barbers where Position = 'Chief') < 2
begin
    raiserror('Not allowed to delete chief barber when number of chiefs < 2', 16, 1)
    rollback transaction;
end
go
create trigger ProhibitAdding on Barbers
    for insert
    as
    begin
    if( datediff(year,(select BirthDate from inserted),getdate()) < 21 )
        raiserror('Not allowed to insert barbers with age under 21', 16, 1)
        rollback transaction;
    end
go
-- insert into Barbers (FullName, Gender, PhoneNumber, Email, BirthDate, HireDate, Position) values ('Arny Pontin', 'Male', '952-865-9314', 'apontin0@un.org', '06.09.2004', '11.07.2015', 'Chief');
