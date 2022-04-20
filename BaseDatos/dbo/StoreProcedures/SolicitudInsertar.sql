CREATE PROCEDURE [dbo].[SolicitudInsertar]
	@IdCliente INT NOT NULL,
	@IdServicio INt NOT NULL,
	@Cantidad  INT NULL,
	@Monto DECIMAL (18, 2),
	@FechaEntrega datetime  NULL,
	@UsuarioEntrega  VARCHAR (50) null,
	@Observaciones VARCHAR (250) null
AS
	BEGIN
		SET NOCOUNT ON

		BEGIN TRANSACTION TRASA

		BEGIN TRY

		INSERT INTO dbo.Solicitud
		(
			
		IdCliente
		, IdServicio
		, Cantidad
		, Monto
		, FechaEntrega
		, UsuarioEntrega
		, Observaciones
		)
		VALUES
		(
		@IdCliente
		, @IdServicio
		, @Cantidad
		, @Monto
		, @FechaEntrega
		, @UsuarioEntrega
		, @Observaciones
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
