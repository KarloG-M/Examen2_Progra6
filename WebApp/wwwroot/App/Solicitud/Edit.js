"use strict";
var SolicitudEdit;
(function (SolicitudEdit) {
    var Entity = $("#AppEdit").data("entity");
    var Formulario = new Vue({
        data: {
            Formulario: "FormEdit",
            Entity: Entity
        },
        methods: {
            Save: function () {
                if (BValidateData(this.Formulario)) {
                    Loading.fire("Guardando...");
                    App.AxiosProvider.GuardarSolicitud(this.Entity).then(function (data) {
                        Loading.close();
                        if (data.CodError == 0) {
                            Toast.fire({ title: "La solicitud se inserto correctamente", icon: "success" }).then(function () { return window.location.href = "Solicitud/Grid"; });
                        }
                        else {
                            Toast.fire({ title: data.MsgError, icon: "error" });
                        }
                    });
                }
            },
            mounted: function () {
                CreateValidator(this.Formulario);
            }
        }
    });
    Formulario.$mount("#AppEdit");
})(SolicitudEdit || (SolicitudEdit = {}));
//# sourceMappingURL=Edit.js.map