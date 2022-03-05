namespace EditInstitucion {

    declare var MensajeApp;

    //Muestra modal mensaje
    if (MensajeApp != "") {
        Swal.fire({
            icon: 'success',
            title: MensajeApp
        }).then(function (result) {
            window.location.href = "Institucion/Grid";
        });
    }
}