$(function () {
    creaValidaciones();
    creaEventos();
});

///crea las validaciones para el formulario
function creaValidaciones() {
    $("#frmIniciodeSesion").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            correo: {
                required: true
            },
            contrasenia: {
                required: true
            },
        }
    });
}
///llamar eventos al iniciar secion
function creaEventos() {
    $("#btnAceptar").on("click", function () {
        var formulario = $('#frmIniciodeSesion');
        formulario.validate();

        if (formulario.valid()) {
            invocarMetodoPost();
        }
    });
}
///se encarga de llamar al metodo del controlador y procesar el resultado
///pasamos los parametros ingresados por el usuario
function invocarMetodoPost() {
    var url = '/Home/ValidarUsuario';

    var parametros = {
        pCorreo: $("#correo").val(),
        pContrasenia: $("#contrasenia").val(),
    };

    ///invocar al metodo
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            procesarResultadoMetodo(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}


///apartir de la validacion de usuario desde el server
///Iniciar secion o mandar msj de error
function procesarResultadoMetodo(data) {

    var resultadoFuncion = data.resultado;

    if (resultadoFuncion.validado == true) {

        cargarDatosUsuario();
        $("#myModal").modal();

        setTimeout(function () {
            window.location.href = '/Home/PaginaPrincipal';
        }, 5000);
    }
    else {
        $("#myModal1").modal;
    }
}
///metodo que modifica la etiqueta por id bienvenida
///muestra el nombre del usuario que inicion secion
function procesarResultadoUsuario(data) {
    var resultadoFuntion = data.resultado;
    var ddlTexto = $("#Bienvenida");
    ddlTexto.text("Bienvenido al sistema: " + resultadoFuntion);

}