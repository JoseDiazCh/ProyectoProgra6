$(function () {
    creaEventCerrar();
});

///Llamar Eventos
///Al Cerrar Sesion
function creaEventCerrar() {
    $("#btncerrarSesion").on("click", function () {
        cerrarSesion();
    });
}


///carga los Datos Del Cliente Desde El Server
function cerrarSesion() {
    ///dirección a donde se enviarán los datos
    var url = '/Login/CerrarSesionCliente';
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
            procesoCerrarSesion(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}



/// Funcion Para Cerrar Sesion
function procesoCerrarSesion(data) {

    var estadoUsuario = data.resultado;

    if (estadoUsuario === "L") {
        var msj = 'Cerrando Sesion!!!';
        showMessageSm(msj);
        setTimeout(function () {

            window.location.href = '/Login/InicioSesion';
        }, 5000);
    }
}





//Modal Pequeño
function showMessageSm(msg) {



    const message = document.querySelector("#mensaje");



    var html = "<div class='modal' data-backdrop='static' id='myModalError' tabindex='-1' role='dialog'> " +
        " <div class='modal-dialog modal-sm modal-dialog-centered' >" +
        " <div class='modal-content'>" +
        " <div class='modal-header'>" +
        " <h6 class='modal-title'>ALERTA!!!</h6>" +
        " </button>" +
        " </div>" +
        " <div class='modal-body'>" +
        " <p>" + msg + "</p>" +
        " </div>" +
        " <div class='modal-footer'>" +
        " <div><div class='spinner'></div>Redireccionando...</div> "
    " </div>" +
        " </div>" +
        "</div >" +
        "</div >";



    message.innerHTML = html;



    $("#myModalError").modal('show');
    //no tiene funcion
    /* $(function () {
    $("#btnShow").click(function () {
    showModal();
    });
    });*/
}