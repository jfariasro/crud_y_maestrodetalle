use master
go

if db_id('MyDB') is not null
begin
	drop database MyDB
end
go

create database MyDB
go

use MyDB
go

create table producto(
idproducto int primary key identity,
nombre nvarchar(100),
precio decimal(10, 2)
)
go

create table venta(
idventa int primary key identity,
cliente varchar(100),
total decimal(10, 2)
)
go

create table detalleventa(
iddetalleventa int primary key identity,
idventa int foreign key references venta(idventa),
idproducto int foreign key references producto(idproducto),
cantidad int,
subtotal decimal(10, 2)
)
go

insert into Producto(Nombre,Precio) values 
('Teclado', 15),
('Mouse', 7)
go

select * from producto