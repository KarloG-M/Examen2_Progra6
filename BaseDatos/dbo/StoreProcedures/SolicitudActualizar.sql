CREATE PROCEDURE [dbo].[SolicitudActualizar]
	@IdSolicitud INT,
	@IdCliente INT,
	 @IdServicio INT,
	@Cantidad INT,
	@Monto DECIMAL (18, 2),
	@FechaEntrega DateTime,
	@UsuarioEntraga varchar(50) ,
	@Observaciones VARCHAR (250)
AS
	BEGIN
		SET NOCOUNT ON

		BEGIN TRANSACTION TRASA

		BEGIN TRY

		UPDATE dbo.Solicitud SET
		IdCliente = @IdCliente
		, IdServicio = @IdServicio
		, Cantidad = @Cantidad
		, Monto = @Monto
		, FechaEntrega = @FechaEntrega
		, UsuarioEntrega = @UsuarioEntraga
		, Observaciones = @Observaciones
		
		WHERE 
			IdSolicitud = @IdSolicitud

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

