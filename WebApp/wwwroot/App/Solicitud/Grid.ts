namespace GridServicio {

    declare var MensajeApp;

    /*Muestra modal de mensaje*/
    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }

    /*Mostrar el modal de confirmación*/
    export function OnclickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el formulario?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(result => {
                if (result.isConfirmed) {
                    window.location.href = "Solicitud/Grid?handler=Eliminar&id=" + id;
                }

            });

    }

    /*Datable*/
    $("#GridView").DataTable();




}