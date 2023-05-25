create database TiendaP
go
use TiendaP
go
create table [User]
(
	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Username nvarchar (50) unique not null,
	[Password] nvarchar (100) not null,
	[Name]nvarchar (50) not null,
	LastName nvarchar (50) not null,
	Email  nvarchar (100) unique not null,
	Tipo nvarchar (50) not null
)
go
insert into [User] values (NEWID(), 'admin', 'admin','Adrian','Dominguez', 'admin@gmail.com', 'Admin')
insert into [User] values (NEWID(), 'depen', 'depen','Dependiente','Arturo', 'depen@gmail.com', 'Depen')
insert into [User] values (NEWID(), 'cliente', 'cliente','Cliente','Roberto', 'cliente@gmail.com','Cliente')
go

select *from [User]