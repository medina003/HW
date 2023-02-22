use Barbershop1 -- у нас не было задания с бд  «Спортивный магазин»,поэтому использую эту бд из прошлого дз
go
-- task1
create login Mark with password = 'Mark123'
go
create user UserMark for login Mark;
go
grant select on Barbershop1.dbo.Barbers to UserMark;
go
grant select on Barbershop1.dbo.Clients to UserMark;
go
grant select on Barbershop1.dbo.Services to UserMark;
go
grant select on Barbershop1.dbo.Barbers to UserMark;

deny select on Barbershop1.dbo.Barbers to UserMark;
go

--task3
create login David with password = 'David123'
go
create user DavidUser for login David
go
grant select on Barbershop1.dbo.Barbers to DavidUser;
--task3
create login Olga with password = 'Olga123'
go
create user OlgaUser for login Olga
go
exec sp_addrolemember 'db_owner' , 'OlgaUser';
go
--task4
create login Konstantin with password = 'Konstantin123'
go
create user KonstantinUser for login Konstantin
go
grant select on Barbershop1.dbo.Clients to KonstantinUser;
go
grant select on Barbershop1.dbo.Services to KonstantinUser;