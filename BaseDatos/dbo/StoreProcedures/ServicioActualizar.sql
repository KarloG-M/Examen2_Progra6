CREATE PROCEDURE [dbo].[ServicioActualizar]
    @IdServicio INT,
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

		UPDATE dbo.Servicio SET
		
		
		NombreServicio = @NombreServicio
		, PlazoEntrega = @PlazoEntrega
		, CostoServicio = @CostoServicio
		, Estado = @Estado
		, CuentaContable = @CuentaContable
		
		WHERE 
			IdServicio = @IdServicio

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