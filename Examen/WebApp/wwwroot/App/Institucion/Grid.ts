namespace GridInstitucion {

    declare var MensajeApp;

    //Muestra modal mensaje
    if (MensajeApp != "") {
        Toast.fire({ icon: "success", title: MensajeApp });
    }

    //Muestra modal confirmacion
    export function OnClickEliminar(id) {
        ComfirmAlert("¿Desea eliminar el registro?", "Eliminar", "warning", '#3085d6', '#d33')
            .then(result => {
                if (result.isConfirmed) {
                    window.location.href = "Institucion/Grid?handler=Eliminar&id=" + id;
                }
            });
    }

    //Datatable
    $("#GridView").DataTable();
}