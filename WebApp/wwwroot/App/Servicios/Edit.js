"use strict";
var ServiciosEdit;
(function (ServiciosEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(ServiciosEdit || (ServiciosEdit = {}));
//# sourceMappingURL=Edit.js.map