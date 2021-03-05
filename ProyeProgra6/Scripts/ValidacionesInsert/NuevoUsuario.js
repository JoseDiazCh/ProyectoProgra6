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
            cedula: {
                required: true,
                digits: true
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
<<<<<<< HEAD:ProyeProgra6/Scripts/ValidacionesInsert/NuevoUsuario.js
            
=======
                maxlength: 12,
                 number: true
>>>>>>> 85744f24503fbdcfd854d7ca8f64a3e3648e23d7:ProyeProgra6/Scripts/Usuarios/NuevoUsuario.js
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

        }
    });
}
