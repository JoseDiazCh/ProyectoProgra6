$(function () {
    ///Carga inicialmente la lista der provincias, ya que es
    //la lista con la que iniciaremos.
    cargaDropdownListServicio();
    cargaDropdownListEncabezado();
    creaValidaciones();
    creaEventos();
});


function creaValidaciones() {
    $("#frmInserta").validate({
        rules: {
            idServProduc: {
                required: true
            },
            cantidadsp: {
                required: true,
                digits: true
            },
            preciototal: {
                required: true,
                digits:true

            },
            idEncabezadoFac: {
                required: true
            },
        }
    });
    {
        $("#frmNuevaFactura").validate({
            rules: {
                idUsuario: {
                    required: true
                },
                idVehiculo: {
                    required: true
                },
                fecha: {
                    required: true
                },
                montofinal: {
                    required: true,
                },
                EstadoFactura: {
                    required: true
                },

            }
        });
    }

}


///carga los registros de las provincias
function cargaDropdownListServicio() {
    ///dirección a donde se enviarán los datos
    var urlMetodo = '/Facturacion/RetornaServioPro';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {};

    var funcion = cargaServProdc;

    ///Llamar al Metodo Que Se Comunica con el servidor
    ejecutaAjax(urlMetodo, parametros, funcion)
}

///Cargar Datos Al DropDownList Representantes
function cargaServProdc(data) {

    ///Mediante Selector Nos Posicionamos sobre la lista 
    var ddlservicio = $("#idServProduc");
    ///Limpiamos todas las opciones de la lista de provincias
    ddlservicio.empty();
    ///Creamos la primera opcion de la lista, con valor vacio y el texto "Seleccion Un valor"
    var nuevaOpcion = "<option value=''>Seleccione El Servicio Deciado</option>";
    ddlservicio.append(nuevaOpcion);
    ///Empezamos A Recorrer Los Registros Obtenidos
    $(data).each(function () {
        ///Obtenemos el objeto de tipo provincia haciendo uso de la clausula "this"
        ///Ahora podemos acceder a todas las propiedades
        ///Por ejemplo provinicaActual.nombre nos retorna el nombre de la provincia
        var servicioActual = this;
        ///Creamos la opcion de la lista, con el valor del id de la provincia y el texto con el nombre
        nuevaOpcion = "<option value='" + servicioActual.idServProduc + "'>" + servicioActual.Descripcion + "</option>";
        ///Agregamos la Opcion Al DropDownList
        ddlservicio.append(nuevaOpcion);
    });

}

///carga los registros de las provincias
function cargaDropdownListEncabezado() {
    ///dirección a donde se enviarán los datos
    var urlMetodo = '/Facturacion/RetornaEncabezado';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {};

    var funcion = cargaEncabezado;

    ///Llamar al Metodo Que Se Comunica con el servidor
    ejecutaAjax(urlMetodo, parametros, funcion)
}

///Cargar Datos Al DropDownList Representantes
function cargaEncabezado(data) {

    ///Mediante Selector Nos Posicionamos sobre la lista 
    var ddlencabezado = $("#idEncabezadoFac");
    ///Limpiamos todas las opciones de la lista de provincias
    ddlencabezado.empty();
    ///Creamos la primera opcion de la lista, con valor vacio y el texto "Seleccion Un valor"
    var nuevaOpcion = "<option value=''>Seleccione El ID_Encabezado Factura</option>";
    ddlencabezado.append(nuevaOpcion);
    ///Empezamos A Recorrer Los Registros Obtenidos
    $(data).each(function () {
        ///Obtenemos el objeto de tipo provincia haciendo uso de la clausula "this"
        ///Ahora podemos acceder a todas las propiedades
        ///Por ejemplo provinicaActual.nombre nos retorna el nombre de la provincia
        var encabezadoActual = this;
        ///Creamos la opcion de la lista, con el valor del id de la provincia y el texto con el nombre
        nuevaOpcion = "<option value='" + encabezadoActual.idEncabezadoFac + "'>" + encabezadoActual.idUsuario + "</option>";
        ///Agregamos la Opcion Al DropDownList
        ddlencabezado.append(nuevaOpcion);
    });


}

///Llamar Eventos
///Al Iniciar Session
function creaEventos() {
    $("#btnInsertar").on("click", function () {
        ///Asignar a la variable formulario
        ///el resultado del selector
        var formulario = $("#frmInserta");
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
    var url = '/Facturacion/InsertaDetalleFa';
    ///Parametros del metodo, es CASE SENSITIVE
    var parametros = {
        pIdServProduc: $("#idServProduc").val(),
        pCantidadSoP: $("#cantidadsp").val(),
        pPrecioTotal: $("#preciototal").val(),
        pIdEncabezadoFac: $("#idEncabezadoFac").val()
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