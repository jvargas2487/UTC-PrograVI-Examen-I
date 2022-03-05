"use strict";
var EditInstitucion;
(function (EditInstitucion) {
    //Muestra modal mensaje
    if (MensajeApp != "") {
        Swal.fire({
            icon: 'success',
            title: MensajeApp
        }).then(function (result) {
            window.location.href = "Institucion/Grid";
        });
    }
})(EditInstitucion || (EditInstitucion = {}));
//# sourceMappingURL=Edit.js.map