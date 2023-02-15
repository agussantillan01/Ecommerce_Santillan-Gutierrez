CREATE DATABASE ECOMMERCE
go
USE ECOMMERCE
GO

CREATE TABLE USUARIOS(
ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
NOMBRE VARCHAR (100) NULL, 
APELLIDO VARCHAR (100) NULL, 
EMAIL VARCHAR (100) NULL, 
CONTRASE�A VARCHAR(100) NULL,
TipoUser int not null
)
GO 
CREATE TABLE MARCAS (
ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
NOMBRE VARCHAR (100) NOT NULL
)
GO
CREATE TABLE TIPOS (
ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
NOMBRE VARCHAR (100)
)
GO
CREATE TABLE COLORES (
ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
NOMBRE VARCHAR (100) NOT NULL
)
GO
CREATE TABLE PRODUCTOS(
ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY, 
NOMBRE VARCHAR(200) NOT NULL, 
DESCRIPCION VARCHAR (200) NULL, 
IDTIPO INT NOT NULL FOREIGN KEY REFERENCES TIPOS(ID),
IDMARCA INT FOREIGN KEY REFERENCES MARCAS (ID),
MEMORIAINTERNA INT NULL, 
MEMORIARAM INT NULL, 
PROCESADOR VARCHAR (200) NULL, 
TIPODISCO VARCHAR(5) NULL,
SISTEMAOPERATIVO VARCHAR(200) NULL,
PLACAVIDEO VARCHAR(200) NULL,
IMAGEN1 VARCHAR (500) NULL,
IMAGEN2 VARCHAR (500) NULL,
IMAGEN3 VARCHAR (500) NULL,
IMAGEN4 VARCHAR (500) NULL,
PRECIO MONEY NULL,
ESTADO BIT
)
GO
CREATE TABLE COLORES_X_PRODUCTO (
IDPRODUCTO INT FOREIGN KEY REFERENCES PRODUCTOS(ID), 
IDCOLOR INT FOREIGN KEY REFERENCES COLORES (ID),
STOCK INT NULL
)
GO
CREATE TABLE VENTAS (
ID INT NOT NULL IDENTITY (1,1) PRIMARY KEY,
IDUSUARIO INT FOREIGN KEY REFERENCES USUARIOS(ID),
FECHAVENTA DATETIME NOT NULL,
PRECIOTOTAL MONEY, 
ESTADO BIT DEFAULT 1
)
GO 
CREATE TABLE DETALLE_VENTA (
IDVENTA INT FOREIGN KEY REFERENCES VENTAS (ID), 
IDPRODUCTO INT FOREIGN KEY REFERENCES PRODUCTOS (ID), 
IDCOLOR INT FOREIGN KEY REFERENCES COLORES (ID),
CANTIDAD INT NOT NULL, 
PRECIO MONEY NOT NULL
)


-- ****************** PROCEDIMIENTOS ALMACENADOS ******************
--AGREGA PRODUCTO
Go
CREATE PROCEDURE SP_AGREGARPRODUCTO (
@Nombre varchar (200), 
@Descripcion varchar (200), 
@Tipo int, 
@Marca int, 
@MemoriaInterna int, 
@MemoriaRam int,
@Procesador varchar(100), 
@Disco varchar(3),
@SistemaOperativo varchar(200),
@PlacaVideo varchar(200),
@Imagen1 varchar (500), 
@Imagen2 varchar (500),
@Imagen3 varchar (500),
@Imagen4 varchar (500),
@Precio money
)AS
BEGIN 
	INSERT INTO PRODUCTOS VALUES(@Nombre,@Descripcion, @Tipo, @Marca,@MemoriaInterna,@MemoriaRam,@Procesador,@Disco,@SistemaOperativo, @PlacaVideo, @Imagen1,@Imagen2,@Imagen3,@Imagen4, @Precio,1)
	
END 

GO 

-- MODIFICA PRODUCTO
CREATE Procedure SP_ModificaProducto(
@Id int, 
@Nombre varchar (100),
@Descripcion VARCHAR (200),
@Tipo int,
@Marca int,
@MemoriaInterna int, 
@MemoriaRam int, 
@Procesador varchar (100),
@Disco varchar(3),
@Imagen1 varchar(500),
@Imagen2 varchar(500),
@Imagen3 varchar(500),
@Imagen4 varchar(500),
@Precio money
)
as
Begin
update PRODUCTOS 
set NOMBRE = @Nombre,
DESCRIPCION = @Descripcion,
IDTIPO = @Tipo,
IDMARCA = @Marca,
MEMORIAINTERNA = @MemoriaInterna, 
MEMORIARAM = @MemoriaRam,
PROCESADOR = @Procesador, 
TIPODISCO = @Disco, 
IMAGEN1 = @Imagen1, 
IMAGEN2 = @Imagen2, 
IMAGEN3 = @Imagen3, 
IMAGEN4 = @Imagen4, 
PRECIO = @Precio
Where ID = @Id
end

--AGREGA EL STOCK DE CADA COLOR POR PRODUCTO
Go
CREATE PROCEDURE SP_AGREGARCOLOR_x_PRODUCTO (
@IdProducto int, 
@IdColor int, 
@Stock int
)AS
BEGIN 
	INSERT INTO COLORES_X_PRODUCTO VALUES (@IdProducto,@IdColor,@Stock)
END 
Go 




--MODIFICA EL COLOR POR PRODUCTO
CREATE PROCEDURE SP_MODIFICARCOLOR_x_PRODUCTO (
@IdProducto int, 
@IdColor int, 
@Stock int
)AS
BEGIN 
	UPDATE COLORES_X_PRODUCTO SET STOCK=@Stock WHERE IDPRODUCTO=@IdProducto AND IDCOLOR=@IdColor
END 




--AGREGA UNA MARCA 
Go
CREATE PROCEDURE SP_AGREGARMARCA (
@Nombre varchar (100)
)AS
BEGIN 
	INSERT INTO MARCAS VALUES(@Nombre)
	
END 




-- LISTA LA CANTIDAD DE STOCK POR PRODUCTO Y COLOR
Go
CREATE PROCEDURE SP_ListarStock (
@IdProducto int, 
@IdColor int 
)
AS BEGIN 
Select CXP.IDPRODUCTO,CXP.IDCOLOR,CXP.STOCK from COLORES_X_PRODUCTO CXP WHERE CXP.IDPRODUCTO= @IdProducto AND @IdColor=@IdColor
END
GO
-- MODIFICA MARCA
CREATE PROCEDURE SP_MODIFICAMARCA (
@Id int, 
@Nombre varchar (100)
) 
AS BEGIN 
	UPDATE MARCAS SET NOMBRE = @Nombre WHERE ID= @Id

END 

-- MODIFICA CATEGORIA
GO
CREATE PROCEDURE SP_MODIFICACATEGORIA (
@Id int, 
@Nombre varchar (100)
) 
AS BEGIN 
	UPDATE TIPOS SET NOMBRE = @Nombre WHERE ID= @Id
END 


-- AGREGA CATEGORIA
Go
CREATE PROCEDURE SP_AGREGARTIPO (
@Nombre varchar (100)
)AS
BEGIN 
	INSERT INTO TIPOS VALUES(@Nombre)
END

Go
CREATE PROCEDURE SP_AgregarCompra(
@Id int, 
@IdUsuario int,
@Total money
) AS BEGIN 
	Insert into VENTAS (IDUSUARIO, FECHAVENTA,PRECIOTOTAL) values(@IdUsuario,GETDATE() ,@Total)
END 



--AGREGA DETALLE VENTA 
Go 
CREATE PROCEDURE SP_agregarDetalleVenta (
@Id int, 
@IdProducto int, 
@IdColor int,
@Cantidad int, 
@Precio money
)AS 
BEGIN 
Insert into DETALLE_VENTA VALUES (@Id, @IdProducto,@IdColor,@Cantidad,@Precio)
DECLARE @Stock int
SELECT @Stock= STOCK FROM COLORES_X_PRODUCTO WHERE IDCOLOR=@IdColor AND IDPRODUCTO=IDPRODUCTO
DECLARE @StockActualizado int 
SET @StockActualizado = (@Stock-@Cantidad)
Update COLORES_X_PRODUCTO set STOCK = @StockActualizado WHERE IDCOLOR=@IdColor AND IDPRODUCTO=@IdProducto
END 


--ELIMINA MARCA
go
Create Procedure SP_EliminaMarca(@Id bigint)
as
Begin
delete MARCAS Where ID = @Id
end

go 
--ELIMINA CATEGORIA
go
Create Procedure SP_EliminaTipo(@Id bigint)
as
Begin
delete TIPOS Where ID = @Id
end
--ELIMINA Producto
go
Create Procedure SP_EliminaProducto(@Id bigint)
as
Begin
Update PRODUCTOS set ESTADO = 0 Where ID = @Id
end

GO
--AGREGAR USUARIO
CREATE PROCEDURE SP_AgregarUsuario( 
@Nombre varchar (100),
@Apellido varchar (100),
@Email varchar (100),
@Contrase�a varchar(100)
) AS
BEGIN
Declare @CantidadUsuarios int 
Select @CantidadUsuarios= COUNT(DISTINCT U.Id) from Usuarios U 
IF (@CantidadUsuarios = 0) BEGIN 
insert into Usuarios (NOMBRE,APELLIDO,Email,Contrase�a,TipoUser) output inserted.Id values (@Nombre,@Apellido,@Email,@Contrase�a,2)
END 
ELSE BEGIN
insert into Usuarios (NOMBRE,APELLIDO,Email,Contrase�a,TipoUser) output inserted.Id values (@Nombre,@Apellido,@Email,@Contrase�a,1)
END 
END

