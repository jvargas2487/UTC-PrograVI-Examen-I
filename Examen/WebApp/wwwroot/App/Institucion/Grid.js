"use strict";
var GridInstitucion;
(function (GridInstitucion) {
    //Muestra modal mensaje
    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }
    //Muestra modal confirmacion
    function OnClickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el registro?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Institucion/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    GridInstitucion.OnClickEliminar = OnClickEliminar;
    //Datatable
    $("#GridView").DataTable();
})(GridInstitucion || (GridInstitucion = {}));
//# sourceMappingURL=Grid.js.map