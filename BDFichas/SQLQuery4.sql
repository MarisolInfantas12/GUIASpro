
If EXISTS (SELECT * FROM SysObjects WHERE Id= Object_Id(N'sp_GenerarCodigoFicha')
	    AND ObjectProperty (Id, N'IsProcedure')=1)
  DROP PROCEDURE  sp_GenerarCodigoFicha
 Go
create procedure sp_GenerarCodigoFicha
@Codigo as VarChar(6) Output,
@Prefijo as  varchar(5), 
@Tamaño as tinyint
AS
BEGIN
DECLARE @Max_Codigo varchar(6),
        @Indice as varchar(10),
        @Contador as tinyint
---Inicia variables
select @Indice=''
---Selecciona el codigo maximo
select @Max_Codigo =MAX(CodFicha) from TFicha
-----Verifica si es vacio
if @Max_Codigo is null
begin
     ---Crea el codigo inicial
         select @Contador=1
         while (@Contador <@Tamaño)
         begin
		select @Contador= @Contador+1
                select @Indice=@Indice+'0'
	 end
end
else 
   begin
	 select @Contador=Len(@Prefijo)
	 select @Indice=SubString(@Max_Codigo,@Contador+1,@Tamaño)
	-----Incrementa un caracter al ultimo digito
	 select @Indice=Cast(Cast(@Indice as int )+1 as varchar(10))
	while @Tamaño <> Len(@Prefijo+ @Indice)
	begin
		select @Indice='0'+ @Indice
	end
   end
Select @Codigo=@Prefijo +@Indice
return 0
end