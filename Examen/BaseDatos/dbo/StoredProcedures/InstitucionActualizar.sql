-- =============================================
-- Author:		Jeffry Vargas
-- Create date: 04-03-2022
-- Description:	Procedimiento que actualiza una institucion
-- =============================================
CREATE PROCEDURE [dbo].[InstitucionActualizar]
    @Id_Institucion int,
	@Codigo varchar(250),
	@Nombre varchar(250),
	@Telefono varchar(250),
	@Estado bit
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	UPDATE dbo.Institucion SET
	   Codigo=@Codigo,
       Nombre=@Nombre,
	   Telefono=@Telefono,
	   Estado=@Estado
	WHERE 
	   Id_Institucion = @Id_Institucion
	
	COMMIT TRANSACTION TRASA
	SELECT 0 AS CodeError, '' AS MsgError

	END TRY
	BEGIN CATCH

	  SELECT ERROR_NUMBER() AS CodeError,
	         ERROR_MESSAGE() AS MsgError

	  ROLLBACK TRANSACTION TRASA

	END CATCH


END
GO