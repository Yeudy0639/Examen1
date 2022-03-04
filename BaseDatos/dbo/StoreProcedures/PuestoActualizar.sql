CREATE PROCEDURE [dbo].[PuestoActualizar]
	@Id_Puesto INT,
	@Nombre varchar(250)	,
	@Salario INT,
	@Estado BIT

AS BEGIN
SET NOCOUNT ON

	BEGIN TRANSACTION TRASA

	BEGIN TRY
	-- AQUI VA EL CODIGO
		
	UPDATE dbo.Puestos SET
	 Nombre=@Nombre,
	 Estado=@Estado
	 
	WHERE  Id_Puesto=@Id_Puesto

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
