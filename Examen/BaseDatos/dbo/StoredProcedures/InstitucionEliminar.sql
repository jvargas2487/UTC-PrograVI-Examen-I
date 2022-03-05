-- =============================================
-- Author:		Jeffry Vargas
-- Create date: 04-03-2022
-- Description:	Procedimiento que elimina una institucion
-- =============================================
CREATE PROCEDURE [dbo].[InstitucionEliminar]
    @Id_Institucion int
AS
BEGIN

	SET NOCOUNT ON;

	BEGIN TRANSACTION TRASA

	BEGIN TRY

	DELETE FROM dbo.Institucion
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