﻿///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario de insertar una nueva
function creaValidaciones() {
    $("#frmTipoVehiculo").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            Codigo: {
                required: true,
                digits: true

            },
            Tipo: {
                required: true
            },
        }
    });
}