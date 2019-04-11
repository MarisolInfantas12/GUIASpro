select *from TFicha
If EXISTS (SELECT * FROM SysObjects WHERE Id= Object_Id(N'sp_Recuperar_Ficha')
	    AND ObjectProperty (Id, N'IsProcedure')=1)
  DROP PROCEDURE  sp_Recuperar_Ficha
 Go
create procedure sp_Recuperar_Ficha
@Parametro varchar(20),
@parametro2 varchar(20)
AS
BEGIN
	SELECT * into #Temp FROM TFicha
	
	SELECT U.Curso, U.NombreGuia, T.*
	  into #Temp2
	  from #Temp T inner join TFicha U on T.CodFicha = U.CodFicha

	select CodFicha,Curso,NombreGuia from #Temp2 where Curso = @parametro or NombreGuia like '%'+ @Parametro2 
END
GO
create proc MostrarGuias
as
select *from TFicha
go
