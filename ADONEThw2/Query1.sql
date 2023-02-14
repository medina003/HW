create database Stock;
use Stock;
create table GoodsTypes(
    Id int not null primary key identity(1,1),
    TypeName nvarchar(20) unique not null check ( TypeName not like N'' ),
);
create table Providers(
    Id int not null identity (1,1) primary key ,
    Name nvarchar(30) unique not null check ( Name not like N'' )
)
create table Products(
    Id int not null primary key identity(1,1),
    Name nvarchar(30) not null check( Name not like N'') unique,
    TypeId int not null foreign key references GoodsTypes(Id),
    ProvidersId int not null foreign key references Providers(Id),
    Quantity int not null check (Quantity >= 0) ,
    Price money not null check(price >= 0 ),
    Date date not null
)
insert into GoodsTypes(TypeName) values ('Clothes');
insert into GoodsTypes(TypeName) values ('Food');
insert into GoodsTypes(TypeName) values ('Beauty');
insert into GoodsTypes(TypeName) values ('Gear');
insert into Providers(Name) values ('Provider1');
insert into Providers(Name) values ('Provider2');
insert into Providers(Name) values ('Provider3');
insert into Products(Name, TypeId, ProvidersId, Quantity, Price, Date) values ('T-Shirt',1,1,10,30,'14.02.2023')
insert into Products(Name, TypeId, ProvidersId, Quantity, Price, Date) values ('Jeans',1,1,10,70,'14.02.2023')
insert into Products(Name, TypeId, ProvidersId, Quantity, Price, Date) values ('Bread',2,2,100,1,'13.02.2023')
insert into Products(Name, TypeId, ProvidersId, Quantity, Price, Date) values ('Water',2,2,100,1,'13.02.2023')
insert into Products(Name, TypeId, ProvidersId, Quantity, Price, Date) values ('Shower gel',3,3,70,3,'14.02.2023')
insert into Products(Name, TypeId, ProvidersId, Quantity, Price, Date) values ('Cream',3,3,4,30,'12.02.2023')
