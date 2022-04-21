CREATE PROCEDURE [dbo].[SolicitudLista]
AS
BEGIN 
	SET NOCOUNT ON

	SELECT 
	       IdSolicitud
		   , IdCliente
		   ,IdServicio
		   , Cantidad
		   ,Monto
		   ,FechaEntrega
		   ,UsuarioEntrega
		   ,Observaciones
		 
		 
	FROM
	    dbo.Solicitud

END
