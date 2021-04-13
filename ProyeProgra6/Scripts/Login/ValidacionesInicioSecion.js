$(function () {
    creaValidacionesInicioSesionLogin();
   

});

///crea las validaciones para el formulario
function creaValidacionesInicioSesionLogin() {
    $("#frmIniciodeSesion").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            correoInicioSesion: {
                required: true
            },
            contraseniaInicioSesion: {
                required: true
            },
        }
    });
}