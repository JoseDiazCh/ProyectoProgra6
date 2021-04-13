
$(function () {
    creaElementosJqueryUI();
    creaValidacionesRegistrar();
    creaEventosRegistra();

});


//crea las validaciones para el formulario de insertar una nueva
function creaValidacionesRegistrar() {
    $("#frmRegistrar").validate({
        ///objeto que contiene "las condiciones" que el formulario
        ///debe cumplir para ser considerado válido
        rules: {
            cedula: {
                required: true,
                digits: true,
                minlength: 4,
                maxlength: 9

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

    });
}
///Función que crea los elementos de jqueryUI
function creaElementosJqueryUI() {


    ///creamos el control de tipo datepicker
    crearDatePicker();
    ///creamos el div divDialog como elemento de tipo Dialog
    crearDialog();
    ///evento click del botón btMostrarDialog          
    $("#btMostraDialog").click(function () {
        $("#divDialog").dialog("open");
    });
    //evento click del botón btCerrar   
    $("#btCerrar").click(function () {
        $("#divDialog").dialog("close");
    });

}

//}
/*
 * Crea un datepicker
 */

function crearDatePicker() {
    $("#FechaNacimiento").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "c-80:c+1",
        dateFormat: "yy/mm/dd"

    });

}

function crearDialog() {
    $("#divDialog").dialog({
        autoOpen: false,
        height: 500,
        width: 600,
        modal: true,
        title: "Registro de Datos",
        resizable: false,
        close: function () {
            alert("Ventana Cerrada");
        },

        open: function () {
            alert("Ventana Abierta");
        }
    });
}



///Llamar Eventos
///Al Iniciar Session
function creaEventosRegistra() {
    $("#btnInsertar").on("click", function () {
        ///Asignar a la variable formulario
        ///el resultado del selector
        var formulario = $("#frmRegistrar");
        ///Ejecutar El MEtodo De Validacion
        formulario.validate();
        ///Si El Formulario Es Valido
        ///Ejecutar la funcion invocaMetodosPost
        if (formulario.valid()) {
            invocarMetodoPost();
        }
    });
}





///se encarga de llamar al método del controlador y procesar el resultado
///Pasamos Los Parametros Ingresados Por El Usuario
function invocarMetodoPost() {
    var url = '/Registrarse/Registrar';
    ///Parametros del metodo, es CASE SENSITIVE
    var parametros = {
        pCedula: $("#cedula").val(),
        pGenero: $("#Genero").val(),
        pFechaNacimiento: $("#FechaNacimiento").val(),
        pNombre: $("#Nombre").val(),
        pApellido1: $("#Apellido1").val(),
        pApellido2: $("#Apellido2").val(),
        pCorreo: $("#correo").val(),
        pTipoUsuario: $("#TipoUsuario").val(),
        pid_Provincia: $("#id_Provincia").val(),
        pid_Canton: $("#id_Canton").val(),
        pid_Distrito: $("#id_Distrito").val(),
        pContrasenia: $("#Contrasenia").val()

    };

    var funcion = cargaMensaje;

    ejecutaAjax(url, parametros, funcion)
}



function cargaMensaje(data) {
    var resultadoFuncion = data;
    var ddlTexto = $("#EstadoInfo");
    ddlTexto.empty();
    ddlTexto.text(resultadoFuncion);
    showMessage(resultadoFuncion);
    $("#divDialog").dialog("close");
}



//Modal Pequeño
function showMessage(msg) {



    const message = document.querySelector("#message");




    var html = "<div class='modal' data-backdrop='static' id='myModal' tabindex='-1' role='dialog'> " +
        " <div class='modal-dialog modal-dialog-centered' >" +
        " <div class='modal-content'>" +
        " <div class='modal-header'>" +
        " <h5 class='modal-title'>Validación De Insercion De Datos </h5>" +
        " <button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
        " <span aria-hidden='true'>&times;</span>" +
        " </button>" +
        " </div>" +
        " <div class='modal-body'>" +
        " <p>" + msg + "</p>" +
        " </div>" +
        " <div class='modal-footer'>" +
        " <button type='button' class='btn btn-primary' data-dismiss='modal'>Ok</button>" +
        " </div>" +
        " </div>" +
        "</div >" +
        "</div >";



    message.innerHTML = html;

    $("#myModal").modal('show');

}
