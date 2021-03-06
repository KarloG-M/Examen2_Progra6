using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class SolicitudEntity: DBEntity
    {
        public SolicitudEntity()
        {
            client = client ?? new ClienteEntity();
            serv = serv ?? new ServicioEntity();
        }

        public int? IdSolicitud { get; set; }
        public int IdCliente { get; set; }
        public virtual ClienteEntity client { get; set; }
        public int IdServicio { get; set; }
        public virtual ServicioEntity serv { get; set; }
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string UsuarioEntrega { get; set; }
        public string Observaciones { get; set; }
        
       
    }
}
