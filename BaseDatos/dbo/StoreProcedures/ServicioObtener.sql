--================================
--Autor. <Karlo>
--Create Date: <16/04/2022>/
--Description: Devuelve la lista de la base de datos
--===============================
CREATE PROCEDURE [dbo].[ServicioObtener]
	@IdServicio int = NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT 
		S.IdServicio,
		S.NombreServicio,
		S.PlazoEntrega,
		S.CostoServicio,
		S.Estado,
		S.CuentaContable
		FROM dbo.Servicio S
		WHERE
		(@IdServicio IS NULL OR IdServicio = @IdServicio)

END
