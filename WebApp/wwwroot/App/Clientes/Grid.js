"use strict";
var GridCliente;
(function (GridCliente) {
    /*Muestra modal de mensaje*/
    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }
    /*Mostrar el modal de confirmación*/
    function OnclickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el Cliente?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Clientes/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    GridCliente.OnclickEliminar = OnclickEliminar;
    /*Datable*/
    $("#GridView").DataTable();
})(GridCliente || (GridCliente = {}));
//# sourceMappingURL=Grid.js.map