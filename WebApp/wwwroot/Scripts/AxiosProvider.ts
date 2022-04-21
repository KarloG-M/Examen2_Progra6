
namespace App.AxiosProvider   {

    export const GuardarSolicitud = (entity) => axios.get<DBEntity>("Solicitud/Edit", entity).then(({data})=>data );


}




