CREATE PROCEDURE [dbo].[SolicitudObtener]
	@IdSolicitud int = NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT 
		
		S.Cantidad,
		S.Monto,
		S.FechaEntrega,
		S.UsuarioEntrega,
		S.Observaciones,
		C.IdCliente,
		P.IdServicio
		FROM
			dbo.Solicitud S
					INNER JOIN dbo.Cliente C
					ON C.IdCliente =S.IdCliente
					INNER JOIN dbo.Servicio P 
					ON P.IdServicio  =S.IdServicio
		WHERE
		(@IdSolicitud IS NULL OR S.IdSolicitud = @IdSolicitud)

END

