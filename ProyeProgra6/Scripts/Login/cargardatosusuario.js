$(function () {
    cargarDatosUsuario1();
    ocultarEtiquetas();
});

function cargarDatosUsuario1() {
    ///dirección a donde se enviarán los datos
    var url = '/Login/MostrarInfoUsuario';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {

            var usuarioIdObtenido = data.usuarioActual;
            if (usuarioIdObtenido === 0) {
                var msj = 'Debes Iniciar Sesion Antes De Usar El Sistema';
                alert(msj);
                setTimeout(function () {
                    window.location.href = '/Login/InicioSesion';

                }, 5000);
            }
            else {
                procesarResultadoUsuarioA(data);
            }

        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}



///
function ocultarEtiquetas() {
    ///dirección a donde se enviarán los datos
    var url = '/Login/MostrarInfoUsuario';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {

            var tipoUsuarioActual = data.tipoUsuario;
            ///Si El usuario Es Cliente 
            ///Quitar Etiquetas De La Vista
            ///
            if (tipoUsuarioActual === 'Cliente') {

                $("#admi").hide();
                $("#admi1").hide();
                $("#admi2").hide();
                $("#admi3").hide();
                $("#admi4").hide();
                $("#admi5").hide();
                $("#admi6").hide();
                $("#admi7").hide();
                $("#admi8").hide();
                $("#admi9").hide();
                $("#admi10").hide();
                $("#admi11").hide();
                $("#admi12").hide();
                $("#admi13").hide();
                $("#admi14").hide();
                $("#admi15").hide();
                $("#admi16").hide();
            }

        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

///Metodo Que Modifca La Etiqueta Por Id #Bienvenida
///Muestra EL Nombre Del Usuario que Inicio Session
function procesarResultadoUsuarioA(data) {


    var resultadoFuncion = data.resultado;
    var ddlTexto = $("#Bienvenida");
    var ddlTextoPrincipal = $("#tipoUsuarioActual");
    var textoNombre = $("#nombreUsuarioActual");

    /*
    var pathnameActual = window.location.pathname;
    if (pathnameActual == '/Home/PaginaPrincipal') {
        var htmlboton = "<a class='btn btn-primary' href='/Usuarios/ListaUsuarioActual?idClienteActual=" + data.usuarioActual + "'>Mis Datos</a>"

        var botonClienteActual = document.querySelector("#clienteActualDatos");
        botonClienteActual.innerHTML = htmlboton;
    }*/


    if (data.tipoUsuario === 'Cliente') {
        $("#btnListaUsuario").hide();
    }

    textoNombre.text(data.resultado);

    ddlTextoPrincipal.text(" " + data.tipoUsuario);
    ddlTexto.text("Bienvenido Al Sistema: " + resultadoFuncion);
}