CREATE PROCEDURE [dbo].[ClienteObtener]
@IdCliente int = NULL

AS BEGIN
	SET NOCOUNT ON

	SELECT 
		c.IdCliente,
        C.Identificacion ,
		c.IdTipoIdentificacion ,
        c.Nombre  ,
       c.PrimerApellido ,
       c.SegundoApellido ,
       c.FechaNacimiento ,
         c.Nacionalidad ,
         c.FechaDefuncion ,
        c.Genero  ,
        c.NombreApellidosPadre  ,
        c.NombreApellidosMadre ,
        c.Pasaporte ,
        c.CuentaIBAN V,
         c.CorreoNotifica 

		FROM dbo.Cliente C
		WHERE
		(@IdCliente IS NULL OR IdCliente = @IdCliente)

END