namespace SolicitudEdit {
    var Entity = $("#AppEdit").data("entity")
    var Formulario = new Vue(
        {
            data:
            {
                Formulario: "FormEdit",
                Entity: Entity
            },

            methods: {
                Save() {
                    if (BValidateData(this.Formulario)) {
                        Loading.fire("Guardando...");

                        App.AxiosProvider.GuardarSolicitud(this.Entity).then(data => {
                            Loading.close();

                            if (data.CodError == 0) {
                                Toast.fire({ title: "La solicitud se inserto correctamente", icon: "success" }).then
                                    (() => window.location.href = "Solicitud/Grid")
                            } else {
                                Toast.fire({ title: data.MsgError, icon: "error" })
                            }
                        });
                    } else {
                        Toast.fire({ title: "Complete los campos requeridos" })
                    }
                }
            },
            mounted() {
                CreateValidator(this.Formulario);
            }
        });
    Formulario.$mount("#AppEdit");

}