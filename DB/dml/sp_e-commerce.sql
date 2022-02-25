--===========================================
--=== m-puente-m/DB/dml/sp_e-commerce.sql ===
--===========================================

--//////////////// EMPIEZA PRODUCTOS ///////////////////

CREATE PROCEDURE SP_AgregarProducto
(
    @idCategoria bigint,
    @descripcion VARCHAR(150),
    @stock bigint,
    @precio money,
    @urlImagen varchar(500)
)
AS 
BEGIN

INSERT INTO Productos (IdCategoria,Descripcion,Stock,Precio,UrlImagen,Estado)
VALUES(@idCategoria,@descripcion,@stock,@precio,@urlImagen,1)

END
GO

CREATE PROCEDURE SP_ListaProducto
AS 
BEGIN

SELECT 
      p.IdProducto,
      p.IdCategoria,
      p.Descripcion,
      p.Stock,
      p.Precio,
      p.UrlImagen
FROM Productos AS p WHERE Estado = 1

END
GO

CREATE PROCEDURE SP_ModificarProducto
(
    @idProducto bigint,
    @idCategoria bigint,
    @descripcion varchar(150),
    @stock bigint,
    @precio money,
    @urlImagen varchar(500)

)
AS
BEGIN

UPDATE Productos SET IdCategoria = @idCategoria,
     Descripcion = @descripcion, Stock = @stock, Precio = @precio, UrlImagen = @urlImagen
     WHERE IdProducto = @idProducto  
END
GO

CREATE PROCEDURE SP_EliminarProducto
(
 @idProducto bigint
)
AS
BEGIN
-- DELETE FROM Productos WHERE IdProducto = @idProducto
	UPDATE Productos SET Estado = 0 where IdProducto = @idProducto
END

-- SELECT TOP 1 * FROM Productos ORDER BY IdProducto DESC
GO

CREATE PROCEDURE SP_ValidarStock
(
    @idProducto bigint,
    @cantidad bigint
)
AS
BEGIN

    SELECT COUNT(*) AS r FROM Productos WHERE IdProducto = @idproducto AND Stock >= @cantidad;
        
END


CREATE PROCEDURE SP_BajaStock
(
    @idProducto bigint
)
AS 
BEGIN

UPDATE Productos SET Stock = Stock -1 WHERE IdProducto = @idProducto;

END

CREATE PROCEDURE SP_AltaStock
(
    @idProducto bigint
)
AS
BEGIN

UPDATE Productos SET Stock = Stock +1 WHERE IdProducto = @idProducto

END

CREATE PROCEDURE SP_BuscarProducto
(
    @idProducto bigint
)
AS
BEGIN
SELECT p.IdProducto,
        p.Descripcion,
        p.Estado,
        p.IdCategoria,
        p.Precio,
        p.Stock,
        p.UrlImagen
FROM Productos AS P WHERE p.IdProducto = @idProducto

END
-- ///////////////// TERMINA PRODUCTOS /////////////////////////////--
GO
--/////////////// EMPIEZA FORMA DE PAGO ////////////////////////////-
CREATE PROCEDURE SP_ListaFormaPago
AS
BEGIN

SELECT IdFormaPago,
	   Descripcion
FROM FormaPago WHERE Estado = 1
END
GO
--//////////////// TERMINA FORMA DE PAGO/////////////////-

--///////////////////// EMPIEZA VENTA /////////////////////////
CREATE PROCEDURE SP_FinalizarVenta
(
 @idUsuario bigint,
 @idPago bigint,
 @descripcion varchar(300),
 @direccion varchar(150),
 @estadoenvio bit,
 @total money,
 @estadoretiro bit
)
AS 
BEGIN
INSERT INTO Ventas (IdUsuario, IdFormaPago, DescripcionVenta,
DireccionEnvio, EstadoEnvio, Total, Fecha, Estado, EstadoRetiro)
VALUES (@idUsuario, @idPago, @descripcion, @direccion, @estadoenvio, @total,GETDATE(),1, @estadoretiro)
END

go
create PROCEDURE SP_VentaxID
(
	@idVenta bigint
)
AS
BEGIN

	select Total,
			IdUsuario,
			IdFormaPago,
			DireccionEnvio,
			Fecha



	from Ventas where IdVenta = @idVenta

END

GO
create PROCEDURE SP_ListaVentasDespacho
AS
BEGIN
select v.Fecha,
		v.Total,
		v.EstadoEnvio,
		v.EstadoRetiro,
		v.IdVenta,
		v.DireccionEnvio,
		v.DescripcionVenta,
		v.IdUsuario


from Ventas as V where v.Estado =1

END

go
CREATE PROCEDURE SP_ListaVentas
AS
BEGIN
select v.Fecha,
		v.Total,
		v.EstadoEnvio,
		v.EstadoRetiro,
		v.IdVenta,
		v.DireccionEnvio,
		v.DescripcionVenta,
		v.IdUsuario,
		v.Estado


from Ventas as V 

END



GO
create procedure SP_ConcretarVenta
(
	@idventa bigint
)
AS
BEGIN

UPDATE Ventas set Estado =0 where IdVenta = @idventa
END

GO
create PROCEDURE SP_VentasxUsuario
(
	@idusuario bigint
)
as 
BEGIN

select 
		v.Fecha,
		v.Total,
		v.EstadoEnvio,
		v.EstadoRetiro,
		v.IdVenta,
		v.DireccionEnvio,
		v.DescripcionVenta,
		v.Estado

from Ventas as v where IdUsuario = @idusuario

END

--///////////////////// TERMINA VENTA ////////////////////////////

--//////////// EMPIEZA DETALLE VENTA ///////////////////////////
CREATE PROCEDURE SP_UltimoIdVenta
AS
BEGIN

SELECT TOP 1 IdVenta FROM Ventas WHERE Estado=1 ORDER BY IdVenta DESC 
END
GO

CREATE PROCEDURE SP_RegistrarDetalle
(
    @idVenta bigint,
    @idProducto bigint,
    @precio money,
    @cantidad bigint
)
AS

BEGIN
INSERT INTO DetalleVenta (IdVenta, IdProducto, Precio, Cantidad, Estado)
VALUES (@idVenta, @idProducto, @precio, @cantidad, 1)
END

GO
CREATE PROCEDURE SP_DetalleVenta
(
	@idventa bigint
)
AS

BEGIN
	select d.IdProducto,
			p.Descripcion,
			d.Precio,
			d.Cantidad,
			d.IdDetalleVenta,
			p.UrlImagen


	from DetalleVenta as D 
	inner join Productos as p on p.IdProducto = d.IdProducto
	where d.IdVenta = @idventa
END

exec SP_DetalleVenta 1



--///////////////// TERMINA DETALLE VENTA ////////////////////

-- TODO -> FALTA COMPLETAR Y CORREGIR WIP
/****** Object:  StoredProcedure SP_AgregarUsuario ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_AgregarUsuario
-- Table Usuarios
@usuario VARCHAR(50),
@clave VARCHAR(50),
@patron VARCHAR(50),
@nombre varchar(100),
@apellido varchar(100),
@documento varchar(8),
@domicilio varchar(150),
@celular varchar(20),
@estado BIT,
@idTipoUsuario INT

AS
BEGIN

DECLARE @IdUsuario AS BIGINT;

INSERT INTO Usuarios(Usuario, Clave, Nombre, Apellido, Documento, Domicilio, Celular, Estado, TipoUsuario) 
VALUES (@usuario, ENCRYPTBYPASSPHRASE(@patron, @clave), @nombre, @apellido, @documento, @domicilio, @celular, @estado, @idTipoUsuario)

SELECT @IdUsuario = IdUsuario FROM Usuarios WHERE Usuario = @usuario;

END
GO
-- EXECUTE SP_AgregarUsuario 'nlopez@gmail.com','gogogo','e-commerce', 'Nicolas', 'Lopez', '290000001', 'Paunero 1856', '1500001111', 1, 1;
 -- EXECUTE SP_AgregarUsuario 'jsnow@gmail.com','gogogo','e-commerce', 'John', 'Snow', '300000002', 'Italia 936', '1533332222', 1, 1;
-- EXECUTE SP_AgregarUsuario 'eharris@gmail.com','gogogo','e-commerce', 'Ed', 'Harris', '450000001', 'Delia 5618', '1599992222', 1, 2;
-- DROP PROCEDURE SP_AgregarUsuario;  
 
 
/****** Object:  StoredProcedure SP_ValidarUsuario ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_ValidarUsuario
@usuario VARCHAR(50),
@clave VARCHAR(50),
@patron VARCHAR(50)
AS
BEGIN
SELECT * 
FROM Usuarios 
WHERE Usuario = @usuario and CONVERT(VARCHAR(50),DECRYPTBYPASSPHRASE(@patron, Clave)) = @clave and Estado = 1;
END
GO

-- EXECUTE SP_ValidarUsuario 'jsnow','winter','e-commerce'
-- DROP PROCEDURE SP_ValidarUsuario;

/****** Object:  StoredProcedure SP_ActualizarClaveUsuario ******/      
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_ActualizarClaveUsuario
(@prmIdUsuario bigint,
@prmClave varchar(50),
@patron VARCHAR(50))
AS
	BEGIN
		UPDATE Usuarios
		SET Usuarios.Clave = ENCRYPTBYPASSPHRASE(@patron, @prmClave)		
		WHERE Usuarios.idUsuario = @prmIdUsuario
	END
GO

/****** Object:  StoredProcedure SP_EliminarUsuario ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_EliminarUsuario
(@prmUsuario VARCHAR(50))
AS
	BEGIN
		BEGIN TRANSACTION
		 
		SAVE TRANSACTION EliminarUsuario;
		 
		DECLARE @IdUsuario AS BIGINT
		 
		SELECT @IdUsuario = IdUsuario FROM Usuarios WHERE Usuario = @prmUsuario;
		
		BEGIN TRY
				 
			UPDATE Usuarios
			SET Estado = 0
			WHERE idUsuario = @IdUsuario
		
			COMMIT TRANSACTION 
		END TRY
		BEGIN CATCH
				IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRANSACTION EliminarUsuario; -- rollback de EliminarUsuario.
				END
		END CATCH
	END
GO

-- DROP PROCEDURE SP_EliminarUsuario
/****** Object:  StoredProcedure SP_BuscarUsuarioPorEmail ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_BuscarUsuarioPorEmail
(@prmUsuario varchar(50))
AS
	BEGIN
		SELECT U.IdUsuario			
			 , U.Usuario
			 , U.Clave
			 , U.Nombre
			 , U.Apellido
			 , U.Documento
			 , U.Domicilio
			 , U.Celular
			 , U.Estado
			 , U.TipoUsuario
		
		FROM Usuarios U 		
		WHERE U.Usuario = @prmUsuario
	END
GO


-- DROP PROCEDURE SP_BuscarUsuarioPorEmail; 

/****** Object:  StoredProcedure SP_BuscarSiExisteUsuarioPorEmail ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_BuscarSiExisteUsuarioPorEmail
(@prmUsuario varchar(50))
AS
BEGIN   
      IF EXISTS(SELECT U.Usuario
                        FROM Usuarios U
                        WHERE U.Usuario = @prmUsuario)
		SELECT 1
      ELSE
		SELECT 0      
END
GO

/****** Object:  StoredProcedure SP_ListarUsuarios ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_ListarUsuarios
AS
BEGIN

SELECT U.Usuario
      --,U.Clave
      ,U.Estado
      --,U.TipoUsuario
	  ,U.Nombre
      ,U.Apellido
      ,U.Documento
      ,U.Domicilio
      ,U.Celular,
	  u.IdUsuario
  FROM Usuarios U 
  WHERE U.Estado = 1 AND U.TipoUsuario = 2;
END 
GO

-- DROP PROCEDURE SP_ListarUsuarios;

/****** Object:  StoredProcedure SP_ActualizarDatosUsuario ******/      
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_ActualizarDatosUsuario
(@prmUsuario VARCHAR(50),
@prmNombre varchar(100),
@prmApellido varchar(100),
@prmDocumento varchar(8),
@prmDomicilio varchar(150),
@prmCelular varchar(20))
AS
	BEGIN
		BEGIN TRANSACTION
		 SAVE TRANSACTION ActualizarDatosUsuario;
			DECLARE @IdUsuario AS BIGINT

			SELECT @IdUsuario = IdUsuario FROM Usuarios WHERE Usuario = @prmUsuario;

			BEGIN TRY
				UPDATE Usuarios
				SET 		
				Usuarios.Nombre = @prmNombre,
				Usuarios.Apellido = @prmApellido,				
				Usuarios.Documento = @prmDocumento,
				Usuarios.Domicilio = @prmDomicilio,
				Usuarios.Celular = @prmCelular		
				WHERE Usuarios.IdUsuario = @IdUsuario	
			COMMIT TRANSACTION 
			END TRY
			BEGIN CATCH
				IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRANSACTION ActualizarDatosUsuario; -- rollback de ActualizarDatosUsuario
				END
			END CATCH
	END
GO


/****** Object:  StoredProcedure SP_ActualizarPasswordUsuario ******/      
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_ActualizarPasswordUsuario
(@prmUsuario VARCHAR(50),
@prmClave VARCHAR(50),
@prmNombre varchar(100),
@prmApellido varchar(100),
@prmDocumento varchar(8),
@prmDomicilio varchar(150),
@prmCelular varchar(20),
@prmPatron VARCHAR(50))
AS
	BEGIN
		BEGIN TRANSACTION
		 SAVE TRANSACTION ActualizarPasswordUsuario;
			DECLARE @IdUsuario AS BIGINT

			SELECT @IdUsuario = IdUsuario FROM Usuarios WHERE Usuario = @prmUsuario;

			BEGIN TRY
				UPDATE Usuarios
				SET 		
				Usuarios.Clave = ENCRYPTBYPASSPHRASE(@prmPatron, @prmClave)						
				WHERE Usuarios.IdUsuario = @IdUsuario	
			COMMIT TRANSACTION 
			END TRY
			BEGIN CATCH
				IF @@TRANCOUNT > 0
				BEGIN
					ROLLBACK TRANSACTION ActualizarPasswordUsuario; -- rollback de ActualizarPasswordUsuario
				END
			END CATCH
	END
GO

create PROCEDURE SP_ListarUsuarioXid
(
	@idUsuario bigint
)
AS
BEGIN
select 
	U.Usuario
	  ,U.Nombre
      ,U.Apellido
      ,U.Documento
      ,U.Domicilio
      ,U.Celular
	 


from Usuarios as u where IdUsuario = @idUsuario
END


-- DROP PROCEDURE [SP_ActualizarDatosUsuario];

-- EXECUTE SP_ActualizarDatosUsuario 'max@gmail.com','jon','snow', '50222111', 'Italia 300', '1533331111';

--///////////////// TERMINA USUARIOS ////////////////////


--/////////// EMPIEZA CATEGORIA /////////
CREATE PROCEDURE SP_ListaCategoria
AS
BEGIN

SELECT IdCategoria,
	   Descripcion
FROM Categoria WHERE Estado = 1
END

go
create PROCEDURE SP_AgregarCategoria
(
	@descripcion varchar(30)
)
AS
BEGIN

insert into Categoria (Descripcion,Estado)

VALUES (@descripcion,1)

END

go
CREATE PROCEDURE SP_EliminarCategoria
(
	@idcategoria bigint
)
AS
BEGIN
UPDATE Productos set Estado =0 where IdCategoria = @idcategoria

UPDATE Categoria set Estado =0 where IdCategoria = @idcategoria

END

go
create PROCEDURE SP_DarDeAltaCategoria
(
	@idcategoria bigint
)
AS
BEGIN
UPDATE Productos set Estado =1 where IdCategoria = @idcategoria

UPDATE Categoria set Estado =1 where IdCategoria = @idcategoria

END

go
CREATE PROCEDURE SP_ListaCategoriaDeBaja
AS
BEGIN

SELECT IdCategoria,
	   Descripcion
FROM Categoria WHERE Estado = 0
END




select * from Categoria

--////// TERMINA CATEGORIA /////////

--/////////EMPIEZA CONTACTO ////////
GO
CREATE PROCEDURE SP_RegistrarConsulta
(
	@email VARCHAR(50),
	@celular VARCHAR(20),
	@descripcion varchar(500)
)
as 
BEGIN
	insert into Contacto(Email,Celular,DescripcionProblema,Estado)
	VALUEs (@email,@celular,@descripcion,1)
END

--/////////// TERMINA CONTACTO ///////////

--////////// EMPIEZA ADMIN //////////

/****** Object:  StoredProcedure SP_AgregarAdminEcommerce ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE SP_AgregarAdminEcommerce
-- Table AdminCommerce
@nombreComercio VARCHAR(100),
@email VARCHAR(50),
@clave VARCHAR(50),
@patron VARCHAR(50),
@nombre varchar(100),
@apellido varchar(100),
@documento varchar(8),
@domicilio varchar(150),
@celular varchar(20),
@estado BIT,
@idTipoUsuario INT

AS
BEGIN

DECLARE @IdAdminCommerce AS BIGINT;

INSERT INTO AdminCommerce(NombreComercio, Email, Clave, Nombre, Apellido, Documento, Domicilio, Celular, Estado, TipoUsuario) 
VALUES (@nombreComercio, @email, ENCRYPTBYPASSPHRASE(@patron, @clave), @nombre, @apellido, @documento, @domicilio, @celular, @estado, @idTipoUsuario)

SELECT @IdAdminCommerce = IdAdminCommerce FROM AdminCommerce WHERE Email = @email;

END
GO
 --EXECUTE SP_AgregarAdminEcommerce 'TiendaBerreta','nlopez@gmail.com','gogogo','e-commerce', 'Nicolas', 'Lopez', '290000001', 'Paunero 1856', '1500001111', 1, 1;
 --EXECUTE SP_AgregarAdminEcommerce 'TiendaBerreta','eharris@gmail.com','gogogo','e-commerce', 'Ed', 'Harris', '450000001', 'Delia 5618', '1599992222', 1, 2;
 --DROP PROCEDURE SP_AgregarAdminEcommerce;  
 

GO
CREATE PROCEDURE SP_ListaAdmin
AS
BEGIN

SELECT U.Usuario
      --,U.Clave
      ,U.Estado
      --,U.TipoUsuario
	  ,U.Nombre
      ,U.Apellido
      ,U.Documento
      ,U.Domicilio
      ,U.Celular,
	   U.IdUsuario
  FROM Usuarios U 
  WHERE U.TipoUsuario = 1;

END


-- DROP PROCEDURE SP_ListaAdmin;

GO
CREATE PROCEDURE SP_EliminarAdmin
(
	@idUsuario BIGINT
)
AS
BEGIN
	UPDATE Usuarios SET Estado = 0 WHERE IdUsuario = @idUsuario

END

select * from Usuarios where TipoUsuario=1
--DROP PROCEDURE SP_EliminarAdmin

GO
CREATE PROCEDURE SP_AltaAdmin
(
	@idUsuario BIGINT
)
AS
BEGIN
	UPDATE Usuarios SET Estado = 1 WHERE IdUsuario = @idUsuario
END

--DROP PROCEDURE SP_AltaAdmin


--////////// TERMINA ADMIN //////////