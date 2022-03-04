CREATE PROCEDURE [dbo].[DepartamentoActualizar]
	@Id_Departamento INT,
	@Descripcion varchar(250)	,
	@Ubicacion varchar(250)	,
	@Estado BIT

AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE dbo.Departamentos SET
	 Descripcion=@Descripcion,
	 Ubicacion=@Ubicacion,
	 Estado=@Estado
	 
	WHERE Id_Departamento=@Id_Departamento

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
