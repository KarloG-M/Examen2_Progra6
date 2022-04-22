CREATE PROCEDURE [dbo].[Serviciolista]
	@IdServicio int = NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT 
		IdServicio,
		NombreServicio
	
		FROM dbo.Servicio 
		WHERE
		(@IdServicio IS NULL OR IdServicio = @IdServicio)

END
