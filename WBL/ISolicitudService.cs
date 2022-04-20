using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WBL
{
    public interface ISolicitudService
    {
        Task<DBEntity> CREATE(SolicitudEntity entity);
        Task<DBEntity> DELETE(SolicitudEntity entity);
        Task<IEnumerable<SolicitudEntity>> GET();
        Task<SolicitudEntity> GETBYID(SolicitudEntity entity);
        Task<DBEntity> UPDATE(SolicitudEntity entity);
    }
}