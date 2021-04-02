///document on ready del view Registro de Personas
$(function () {
    creaValidaciones();
    creaElementosJqueryUI();
});
///Función que crea los elementos de jqueryUI
function creaElementosJqueryUI() {
    crearDatePicker();
}
function crearDatePicker() {
    $("#FechaNacimiento").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "c-80:c+1",
        dateFormat: "yy/mm/dd"

    });

}
///crea las validaciones para el formulario de insertar una nueva
function creaValidaciones() {
    $("#frmNuevaPersona").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            cedula: {
                required: true,
                digits: true
                //regex: '/^[1-9]-\d{4}-\d{4}$/',
            },
            Genero: {
                required: true
            },
            FechaNacimiento: {
                required: true
            },
            Nombre: {
                required: true
            },
            Apellido1: {
                required: true,
                minlength: 3,
                maxlength: 15
            },
            Apellido2: {
                required: true,
                minlength: 3,
                maxlength: 15
            },

            correo: {
                required: true,
                email: true
            },
            TipoUsuario: {
                required: true,
                maxlength: 20
          

            },
            id_Provincia: {
                required: true
            },

            id_Canton: {
                required: true
            },
            id_Distrito: {
                required: true
            },
            Contrasenia: {
                required: true
            },

        },

        messages: {
            cedula: {
                regex:"Debe ingresar un formato valido"
            }

        },

    });
}