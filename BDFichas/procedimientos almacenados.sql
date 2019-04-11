------------- PROCEDIMIENTOS ALMACENADOS ---------
use BDFichas

-----------Procedimiento Almacenado para Adicionar-----------------------------
 If EXISTS (SELECT * FROM SysObjects WHERE Id= Object_Id(N'sp_Ficha_Agregar')
	    AND ObjectProperty (Id, N'IsProcedure')=1)
  DROP PROCEDURE  sp_Ficha_Agregar
 Go
create procedure sp_Ficha_Agregar
@CodFicha TCodFicha ,
@Curso  varchar(40),
@Nombreguia  varchar(50)

AS
BEGIN
	   -- Inserta el registro 
	    INSERT INTO TFicha  VALUES (@CodFicha, @Curso,@Nombreguia )	   
END
GO

EXEC sp_Ficha_Agregar 'F1', 'Sistemas de informacion 1', 'guia1'
GO

-----------Procedimiento Almacenado para Modificar-----------------------------
 If EXISTS (SELECT * FROM SysObjects WHERE Id= Object_Id(N'sp_Ficha_Modificar')
	    AND ObjectProperty (Id, N'IsProcedure')=1)
  DROP PROCEDURE  sp_Ficha_Modificar
 Go
create procedure sp_Ficha_Modificar
@CodFicha TCodFicha ,
@Curso  varchar(40),
@NombreGuia  varchar(11)
AS
 BEGIN        
	-- Modifica el Registro 
	UPDATE TFicha SET 
	    Curso=@Curso,	  
		NombreGuia=@NombreGuia					
	  WHERE CodFicha=@CodFicha       			  
END
GO	

-----------Procedimiento Almacenado para Eliminar-----------------------------
 If EXISTS (SELECT * FROM SysObjects WHERE Id= Object_Id(N'sp_Ficha_Eliminar')
	    AND ObjectProperty (Id, N'IsProcedure')=1)
  DROP PROCEDURE  sp_Ficha_Eliminar
 Go
  CREATE PROCEDURE sp_Ficha_Eliminar
       @CodFicha TCodFicha 
  As
   BEGIN
           -- Eliminamos el Registro 
	   DELETE TFicha 
	   WHERE Codficha=@CodFicha 	
   END	
Go

-----------Procedimiento Almacenado para Listar-----------------------------
 If EXISTS (SELECT * FROM SysObjects WHERE Id= Object_Id(N'sp_Ficha_Listar')
	    AND ObjectProperty (Id, N'IsProcedure')=1)
  DROP PROCEDURE  sp_Ficha_Listar
 Go
create procedure sp_Ficha_Listar 
AS
BEGIN 
	Select * 
	from TFicha
	Order by CodFicha
END
GO
EXEC sp_Ficha_Agregar 'F1', 'Sistemas de informacion 1', 'guia1'
EXEC sp_Ficha_Modificar 'F10', 'Sistemas de informacion 1', 'guia1'