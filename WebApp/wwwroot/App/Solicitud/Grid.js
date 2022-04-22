"use strict";
var GridSolicitud;
(function (GridSolicitud) {
    /*Muestra modal de mensaje*/
    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }
    /*Mostrar el modal de confirmación*/
    function OnclickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el formulario?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Solicitud/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    GridSolicitud.OnclickEliminar = OnclickEliminar;
    /*Datable*/
    $("#GridView").DataTable();
})(GridSolicitud || (GridSolicitud = {}));
//# sourceMappingURL=Grid.js.map