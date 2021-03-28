﻿
$(function () {
    obtenerRegistros();

});


/// funcion que obtiene los registros
// del metodo del controlador

function obtenerRegistros() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/GridKendo/RetornaServicio'
    var urlMetodo = '/GridKendo/RetornaCliente'
    var parametros = {};
    var funcion = creaGridKendo;
    ///ejecuta la función $.ajax utilizando un método genérico
    //para no declarar toda la instrucción siempre
    ejecutaAjax(urlMetodo, parametros, funcion);
}
///encargada de crear el grid de kendo y mostrar
//los datos obtenidos al llamar al método
// RetornaListaClientes
function creaGridKendo(data) {
    $("#divKendoGrid").kendoGrid({
        //asiganr la funte de datos KENDO GRID
        dataSource: {
            data: data.resultado,
            //algrega el numero de registros a mostrar
            pageSize: 5
        },
        pageable: true,
        columns: [
            //cada columna se agrega por llaves
            {
                //propiedades de la funte a mostrar
                field: 'Descripcion',
                ///texto del encabezado de pagina
                title: 'Descripcion'
            },
            {
                field: 'Precio',
                title: ' Precio'
            },
            {
                field: 'Nombre',
             
                title: 'Nombre'
            },
            {
                field: 'Apellido1',
                title: ' Apellido'
            },
           
        ]       
    });
}

          
 