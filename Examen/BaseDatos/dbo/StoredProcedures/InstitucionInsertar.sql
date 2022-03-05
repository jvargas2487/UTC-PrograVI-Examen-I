-- =============================================
-- Author:		Jeffry Vargas
-- Create date: 04-03-2022
-- Description:	Procedimiento que registra una institucion
-- =============================================
CREATE PROCEDURE [dbo].[InstitucionInsertar]
	@Codigo varchar(250),
	@Nombre varchar(250),
	@Telefono varchar(250),
	@Estado varchar(250)
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	INSERT INTO dbo.Institucion
	(Codigo, Nombre, Telefono, Estado)
	VALUES
	(
	   @Codigo,
	   @Nombre,
	   @Telefono,
	   @Estado
	)

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