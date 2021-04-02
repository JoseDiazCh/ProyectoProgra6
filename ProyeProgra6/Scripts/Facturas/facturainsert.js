$(function () {
    
    ///Carga inicialmente la lista , ya que es
    //la lista con la que iniciaremos.
    cargaDropdownListUsuario();
    cargaDropdownListVehiculo();
    creaElementosJqueryUI();

});

function creaElementosJqueryUI() {


    ///creamos el control de tipo datepicker
    crearDatePicker();
    //creamos el div divDialog como elemento de tipo Dialog
    crearDialog();
    ///evento click del botón btMostrarDialog          
    $("#btMostrarDialog").click(function () {
        $("#divDialog").dialog("open");
    });
    //evento click del botón btCerrar   
    $("#btCerrar").click(function () {
        $("#divDialog").dialog("close");
    });
 
}

///carga los registros de los usuarios
function cargaDropdownListUsuario() {
    ///dirección a donde se enviarán los datos
    var urlMetodo = '/Facturacion/RetornaUsuario';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {};

    var funcion = cargaUsuario;

    ///Llamar al Metodo Que Se Comunica con el servidor
    ejecutaAjax(urlMetodo, parametros, funcion)
}


///Cargar Datos Al DropDownList Representantes
function cargaUsuario(data) {

    ///Mediante Selector Nos Posicionamos sobre la lista 
    var ddlUsuario = $("#idUsuario");
    ///Limpiamos todas las opciones de la lista de provincias
    ddlUsuario.empty();
    ///Creamos la primera opcion de la lista, con valor vacio y el texto "Seleccion Un valor"
    var nuevaOpcion = "<option value=''>Seleccione Un Nombre</option>";
    ddlUsuario.append(nuevaOpcion);
    ///Empezamos A Recorrer Los Registros Obtenidos
    $(data).each(function () {
        ///Obtenemos el objeto de tipo provincia haciendo uso de la clausula "this"
        ///Ahora podemos acceder a todas las propiedades
        ///Por ejemplo provinicaActual.nombre nos retorna el nombre de la provincia
        var usuarioActual = this;
        ///Creamos la opcion de la lista, con el valor del id de la provincia y el texto con el nombre
        nuevaOpcion = "<option value='" + usuarioActual.idUsuario + "'>" + usuarioActual.nombre + "</option>";
        ///Agregamos la Opcion Al DropDownList
        ddlUsuario.append(nuevaOpcion);
    });
}

function cargaDropdownListVehiculo() {
    ///dirección a donde se enviarán los datos
    var urlMetodo = '/Facturacion/RetornaVehiculo';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {};

    var funcion = cargaVehiculo;

    ///Llamar al Metodo Que Se Comunica con el servidor
    ejecutaAjax(urlMetodo, parametros, funcion)
}

//Cargar Datos Al DropDownList Representantes
function cargaVehiculo(data) {

    ///Mediante Selector Nos Posicionamos sobre la lista 
    var ddlVehiculo = $("#idVehiculo");
    ///Limpiamos todas las opciones de la lista de provincias
    ddlVehiculo.empty();
    ///Creamos la primera opcion de la lista, con valor vacio y el texto "Seleccion Un valor"
    var nuevaOpcion = "<option value=''>Seleccione Una Placa</option>";
    ddlVehiculo.append(nuevaOpcion);
    ///Empezamos A Recorrer Los Registros Obtenidos
    $(data).each(function () {
        ///Obtenemos el objeto de tipo provincia haciendo uso de la clausula "this"
        ///Ahora podemos acceder a todas las propiedades
        ///Por ejemplo provinicaActual.nombre nos retorna el nombre de la provincia
        var vehiculoActual = this;
        ///Creamos la opcion de la lista, con el valor del id de la provincia y el texto con el nombre
        nuevaOpcion = "<option value='" + vehiculoActual.idVehiculo + "'>" + vehiculoActual.placa + "</option>";
        ///Agregamos la Opcion Al DropDownList
        ddlVehiculo.append(nuevaOpcion);
    });
}

///Crea un datepicker

function crearDatePicker() {

    $("#fecha").datepicker({
        changeMonth: true,
        changeYear: true,
        yearRange: "c-4:c+1",
        dateFormat: "yy/mm/dd"

    });
}
/*
 * Crea un datepicker
 */
function crearDialog() {
    $("#divDialog").dialog({
        autoOpen: false,
        height: 500,
        width: 500,
        modal: true,
        title: "Registro de Factura",
        resizable: false,
        close: function () {
            alert("Ventana Cerrada");
        },

        open: function () {
            alert("Ventana Abierta");
        }
    });
}
