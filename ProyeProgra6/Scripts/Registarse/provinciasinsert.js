$(function () {
    ///llamamos a la función que se encargará de crear los eventos
    //que nos permitirán controlar cuando se haga una selección en las respectivas listas
    estableceEventosChange();
    ///Carga inicialmente la lista der provincias, ya que es 
    //la lista con la que iniciaremos.
    cargaDropdownListProvincias();
});

//función que registrará los eventos necesarios para "monitorear"
//cuando se ejecute el método change de las respectivas listas
function estableceEventosChange() {

    ///evento change de la lista de PROVINCIAS
    $("#id_Provincia").change(function () {
        ///obtener el id de la provincia seleccionada
        var provincia = $("#id_Provincia").val();
        ///llamar la funcion que nos permite cargar
        ///todos los cantones asociados a la provincia seleccionada
        cargaDropdownListCantones(provincia);
    });

    ///evento change de la lista de CANTONES
    $("#id_Canton").change(function () {
        ///obtener el id del canton seleccionada
        var canton = $("#id_Canton").val();
        ///llamar la funcion que nos permite cargar
        ///todos los cantones asociados a la provincia seleccionada
        cargaDropdownListDistritos(canton);
    });
}


///carga los registros de las PROVINCIAS
function cargaDropdownListProvincias() {
    ///dirección a donde se enviarán los datos
    var url = '/Registrarse/RetornaProvincias';
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
            procesarResultadoProvincias(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

/*
 * toma el resultado del método RetornaProvincias
 * y lo procesa, recorriendo cada posición
 */
function procesarResultadoProvincias(data) {
    ///mediante un selector nos posicionamos sobre la lista de provincias
    var ddlProvincias = $("#id_Provincia");

    ///Limpiar todas las opciones de la lista de provincias
    ddlProvincias.empty();

    /// Creamos la primera opcion de la lista con un valor vacio
    var nuevaOpcion = "<option value=''> Seleccione una provincia</option>";

    ///agregar la opcion al dropdownlist
    ddlProvincias.append(nuevaOpcion);

    ///empezar a recorrer cada uno de los registros
    $(data).each(function () {
        ///obtenemos el objeto de tipo provincia haciendo uso del calculo this 
        ///ahora podemos acceder a todas las propiedades 
        ///por ejemplo provinciaActual.nombre nos retorna el nombre de la provincia
        var provinciaActual = this;

        ///creamos la opcion de la list, con el valor del id provincia y el texto nombre
        nuevaOpcion = "<option value='" + provinciaActual.id_Provincia + "'>" + provinciaActual.nombre + "</option>"

        ///agregamos la opcion del dropdownlist
        ddlProvincias.append(nuevaOpcion);

    });

}

///carga los registros de los CANTONES
function cargaDropdownListCantones(pIdProvincia) {
    ///dirección a donde se enviarán los datos
    var url = '/Registrarse/RetornaCantones';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        id_Provincia: pIdProvincia
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            ///se invoca la funcion creada
            procesarResultadoCantones(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}
function procesarResultadoCantones(data) {

    ///mediante un selector nos posicionamos sobre la lista de CANTONES
    var ddlCantones = $("#id_Canton");

    ///Limpiar todas las opciones de la lista de CANTONES
    ddlCantones.empty();

    /// Creamos la primera opcion de la lista con un valor vacio
    var nuevaOpcion = "<option value=''> Seleccione un Canton</option>";

    ///agregar la opcion al dropdownlist
    ddlCantones.append(nuevaOpcion);

    ///empezar a recorrer cada uno de los registros obtenidos
    $(data).each(function () {
        ///obtenemos el objeto de tipo provincia haciendo uso del calculo this 
        ///ahora podemos acceder a todas las propiedades 
        ///por ejemplo provinciaActual.nombre nos retorna el nombre de la provincia
        var cantonActual = this;

        ///creamos la opcion de la list, con el valor del id canton y el texto nombre
        nuevaOpcion = "<option value='" + cantonActual.id_Canton + "'>" + cantonActual.nombre + "</option>"

        ///agregamos la opcion del dropdownlist
        ddlCantones.append(nuevaOpcion);
    });
}
function procesarResultadoCantones(data) {

    ///mediante un selector nos posicionamos sobre la lista de CANTONES
    var ddlCantones = $("#id_Canton");

    ///Limpiar todas las opciones de la lista de CANTONES
    ddlCantones.empty();

    /// Creamos la primera opcion de la lista con un valor vacio
    var nuevaOpcion = "<option value=''> Seleccione un Canton</option>";

    ///agregar la opcion al dropdownlist
    ddlCantones.append(nuevaOpcion);

    ///empezar a recorrer cada uno de los registros obtenidos
    $(data).each(function () {
        ///obtenemos el objeto de tipo provincia haciendo uso del calculo this 
        ///ahora podemos acceder a todas las propiedades 
        ///por ejemplo cantonActual.nombre nos retorna el nombre del canton
        var cantonActual = this;

        ///creamos la opcion de la list, con el valor del id canton y el texto nombre
        nuevaOpcion = "<option value='" + cantonActual.id_Canton + "'>" + cantonActual.nombre + "</option>"

        ///agregamos la opcion del dropdownlist
        ddlCantones.append(nuevaOpcion);
    });

}
///carga los registros de los DISTRITOS
function cargaDropdownListDistritos(pIdCanton) {
    ///dirección a donde se enviarán los datos
    var url = '/Registrarse/RetornaDistritos';
    ///parámetros del método, es CASE-SENSITIVE
    var parametros = {
        id_Canton: pIdCanton
    };
    ///invocar el método
    $.ajax({
        url: url,
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(parametros),
        success: function (data, textStatus, jQxhr) {
            ///se invoca la funcion creada
            procesarResultadoDistritos(data);
        },
        error: function (jQxhr, textStatus, errorThrown) {
            alert(errorThrown);
        },
    });
}

function procesarResultadoDistritos(data) {
    ///mediante un selector nos posicionamos sobre la lista de DISTRITOS
    var ddlDistritos = $("#id_Distrito");

    ///Limpiar todas las opciones de la lista de DISTRITOS
    ddlDistritos.empty();

    /// Creamos la primera opcion de la lista con un valor vacio
    var nuevaOpcion = "<option value=''> Seleccione un Distrito</option>";

    ///agregar la opcion al dropdownlist
    ddlDistritos.append(nuevaOpcion);

    ///empezar a recorrer cada uno de los registros obtenidos
    $(data).each(function () {
        ///obtenemos el objeto de tipo provincia haciendo uso del calculo this 
        ///ahora podemos acceder a todas las propiedades 
        ///por ejemplo distritoActual.nombre nos retorna el nombre del distrito
        var distritoActual = this;

        ///creamos la opcion de la list, con el valor del id canton y el texto nombre
        nuevaOpcion = "<option value='" + distritoActual.id_Distrito + "'>" + distritoActual.nombre + "</option>"

        ///agregamos la opcion del dropdownlist
        ddlDistritos.append(nuevaOpcion);
    });

}