CREATE PROCEDURE dbo.TituloInsertar
	@Descripcion varchar(250)	,
	@Estado BIT
	
AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
		INSERT INTO dbo.Titulos
		(
			
			 Descripcion
			, Estado
	    
		)
		VALUES
		(
			  @Descripcion
			, @Estado
		)


		COMMIT TRANSACTION TRASA
		
		SELECT 0 AS CodeError, '' AS MsgError



	END TRY

	BEGIN CATCH
		SELECT 
				ERROR_NUMBER() AS CodeError
			,	ERROR_MESSAGE() AS MsgError

			ROLLBACK TRANSACTION TRASA
	END CATCH


END
