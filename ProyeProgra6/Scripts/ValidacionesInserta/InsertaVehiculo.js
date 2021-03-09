///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario de insertar una nueva
function creaValidaciones() {
    $("#frmNuevoVehiculo").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            placa: {
                required: true,
            },
            numeropuertas: {
                required: true,
                digits: true
            },
            numeroruedas: {
                required: true,
                  digits: true
            },
            idMarcaVehiculos: {
                required: true
            },
            idTipoVehiculo: {
                required: true

            }

        }
    });
}