using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using BD;
namespace WBL
{
    public interface ISolicitudService1
    {
        Task<DBEntity> CREATE(SolicitudEntity entity);
        Task<DBEntity> DELETE(SolicitudEntity entity);
        Task<IEnumerable<SolicitudEntity>> GET();
        Task<SolicitudEntity> GETBYID(SolicitudEntity entity);
        Task<DBEntity> UPDATE(SolicitudEntity entity);
    }

    public class SolicitudService : ISolicitudService1
    {
        private readonly IDataAccess sql;

        public SolicitudService(IDataAccess _sql)
        {
            sql = _sql;
        }
        #region MetodosCRUD
        //Metodo Get
        public async Task<IEnumerable<SolicitudEntity>> GET()
        {
            try
            {
                var result = sql.QueryAsync<SolicitudEntity, ClienteEntity, ServicioEntity>(sp: "dbo.SolicitudObtener", "IdSolicitud, IdCliente, IdServicio");
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Metodo GetById
        public async Task<SolicitudEntity> GETBYID(SolicitudEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<SolicitudEntity>(sp: "dbo.SolicitudObtener", Param: new { entity.IdSolicitud });
                return await result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Metodo Create
        public async Task<DBEntity> CREATE(SolicitudEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.SolicitudInsertar", Param: new
                {
                    entity.IdCliente,
                    entity.IdServicio,
                    entity.Cantidad,
                    entity.Monto,
                    entity.FechaEntrega,
                    entity.UsuarioEntrega,
                    entity.Observaciones

                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Metodo update
        public async Task<DBEntity> UPDATE(SolicitudEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.SolicitudActualizar", Param: new
                {
                    entity.IdCliente,
                    entity.IdServicio,
                    entity.Cantidad,
                    entity.Monto,
                    entity.FechaEntrega,
                    entity.UsuarioEntrega,
                    entity.Observaciones
                });


                return await result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        //Motodo Eliminar
        public async Task<DBEntity> DELETE(SolicitudEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync(sp: "dbo.SolicitudEliminar", Param: new
                {
                    entity.IdSolicitud
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
