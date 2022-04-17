CREATE PROCEDURE [dbo].[ServicioInsertar]
	@NombreServicio  Varchar(128),
	@PlazoEntrega INT NULL,
	@CostoServicio DECIMAL (18, 2),
	@Estado  BIT NULL ,
	@CuentaContable VARCHAR (50)
AS
	BEGIN
		SET NOCOUNT ON

		BEGIN TRANSACTION TRASA

		BEGIN TRY

		INSERT INTO dbo.Servicio
		(
			
		NombreServicio
		, PlazoEntrega
		, CostoServicio
		, Estado
		, CuentaContable
		)
		VALUES
		(
			
		 @NombreServicio
		, @PlazoEntrega
		, @CostoServicio
		, @Estado
		, @CuentaContable
		)
		COMMIT TRANSACTION TRASA
		SELECT 0 AS CodError, '' AS MsgError

		END TRY

		BEGIN CATCH
			SELECT
			ERROR_NUMBER() AS CodError,
			ERROR_MESSAGE() AS MsgError
		ROLLBACK TRANSACTION TRASA
		END CATCH

		END
