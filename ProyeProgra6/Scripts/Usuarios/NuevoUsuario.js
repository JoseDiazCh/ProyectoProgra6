///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
});

///crea las validaciones para el formulario de insertar una nueva
function creaValidaciones() {
    $("#frmNuevaPersona").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            primerApellido: {
                required: true,
                minlength: 3,
                maxlength: 10
            },
            segundoApellido: {
                required: true
            },
            nombre: {
                required: true
            },
            correo: {
                required: true,
                email: true
            },
            telefono: {
                required: true,
                maxlength: 12,
                 number: true
            },
            idProvincia: {
                required: true
            },
            sexo: {
                required: true
            },
            codigo: {
                required: true
            },
            pais: {
                required: true
            },
        }
    });
}
