CREATE DATABASE Commerce
GO 
USE Commerce
GO

CREATE TABLE Usuarios(
	IdUsuario bigint not null PRIMARY KEY IDENTITY(1,1),	
	Usuario varchar(50) not null unique, -- email
	Clave varbinary(500) not null,
	Nombre varchar(100) not null,
    Apellido varchar(100) not null,
    Documento VARCHAR(8)not null,
    Domicilio varchar(150) null,
    Celular varchar(20)null,
	Estado bit not null,	
	TipoUsuario int not null	
);
GO

CREATE TABLE AdminCommerce(
    IdAdminCommerce bigint not null PRIMARY KEY IDENTITY(1,1),
    NombreComercio VARCHAR(100)not null,
    Email VARCHAR(50) not null,
    Clave varchar(100)not null,
    Estado bit not null
);
GO

CREATE TABLE FormaPago(
    IdFormaPago bigint not null PRIMARY KEY IDENTITY(1,1),
    Descripcion varchar(30) not null,
    Estado bit not null
);
GO

CREATE TABLE Ventas(
    IdVenta bigint not null PRIMARY KEY IDENTITY(1,1),
    Fecha date null check (Fecha <= getdate()),
    IdUsuario bigint not null,
    IdFormaPago bigint not null,
    DescripcionVenta varchar(300) null,
    DireccionEnvio varchar (150) null,
    EstadoEnvio bit not null,
    Estado bit not null
);
GO

ALTER TABLE Ventas ADD Total money not null;
GO
ALTER TABLE Ventas ADD EstadoRetiro bit not null;
GO

CREATE TABLE Categoria(
    IdCategoria bigint not null PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(30),
    Estado bit not null
);
GO

CREATE TABLE Productos(
    IdProducto bigint not null PRIMARY KEY IDENTITY(1,1),
    IdCategoria bigint not null FOREIGN KEY REFERENCES Categoria(IdCategoria),
    Descripcion varchar(150) not null,
    Stock bigint not null,
    Precio money not null,
    Estado bit not null,
    UrlImagen varchar(500)not null
);
GO

CREATE TABLE DetalleVenta(
	IdDetalleVenta bigint not null PRIMARY KEY IDENTITY(1,1),
    IdVenta bigint not null FOREIGN KEY REFERENCES Ventas(IdVenta),
    IdProducto bigint not null FOREIGN KEY REFERENCES Productos(IdProducto),
    Precio money not null,
    Cantidad bigint not null,
    Estado bit not null
);
GO

CREATE TABLE Contacto(
    IdContacto bigint not null PRIMARY KEY IDENTITY(1,1),
    Email varchar(50) not null,
    Celular varchar(20)not null,
    DescripcionProblema varchar (500) not null,
    Estado bit not null
);
GO

 