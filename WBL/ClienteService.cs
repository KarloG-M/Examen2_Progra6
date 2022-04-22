using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BD;
using Entity;


namespace WBL
{
    public interface IClienteService
    {
        Task<DBEntity> CREATE(ClienteEntity entity);
        Task<DBEntity> DELETE(ClienteEntity entity);
        Task<IEnumerable<ClienteEntity>> GET();
        Task<IEnumerable<ClienteEntity>> GETLISTA();
        Task<ClienteEntity> GETBYID(ClienteEntity entity);
        Task<DBEntity> UPDATE(ClienteEntity entity);
        Task<IEnumerable<ClienteEntity>> GETLISTA();
    }

    public class ClienteService : IClienteService
    {

        private readonly IDataAccess sql;

        public ClienteService(IDataAccess _sql)
        {
            sql = _sql;
        }

        #region MetodosCRUD
        //Metodo Get
        public async Task<IEnumerable<ClienteEntity>> GET()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity>(sp: "dbo.ClienteObtener");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IEnumerable<ClienteEntity>> GETLISTA()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity>(sp: "dbo.ClienteLista");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Metodo GetById
        public async Task<ClienteEntity> GETBYID(ClienteEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ClienteEntity>(sp: "dbo.ClienteObtener", Param: new { entity.IdCliente });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Metodo Create
        public async Task<DBEntity> CREATE(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.ClienteInsertar", Param: new
                {

                  
                    entity.Identificacion,
                    entity.IdTipoIdentificacion,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.FechaNacimiento,
                    entity.Nacionalidad,
                    entity.FechaDefuncion,
                    entity.Genero,
                    entity.NombreApellidosPadre,
                    entity.NombreApellidosMadre,
                    entity.Pasaporte,
                    entity.CuentaIBAN,
                    entity.CorreoNotifica

                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }


        //Metodolista

        public async Task<IEnumerable<ClienteEntity>> GETLISTA()
        {
            try
            {
                var result = sql.QueryAsync<ClienteEntity>("dbo.Clientelista");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }


        }


        //Metodo update
        public async Task<DBEntity> UPDATE(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.ClienteActualizar", Param: new
                {
                    entity.IdCliente,
                    entity.Identificacion,
                    entity.IdTipoIdentificacion,
                    entity.Nombre,
                    entity.PrimerApellido,
                    entity.SegundoApellido,
                    entity.FechaNacimiento,
                    entity.Nacionalidad,
                    entity.FechaDefuncion,
                    entity.Genero,
                    entity.NombreApellidosPadre,
                    entity.NombreApellidosMadre,
                    entity.Pasaporte,
                    entity.CuentaIBAN,
                    entity.CorreoNotifica
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Motodo Eliminar
        public async Task<DBEntity> DELETE(ClienteEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.ClienteEliminar", Param: new
                {
                    entity.IdCliente
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }

}
