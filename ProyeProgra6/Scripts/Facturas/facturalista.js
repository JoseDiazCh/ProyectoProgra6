
$(function () {
    obtenerRegistros();
});


/// funcion que obtiene los registros
// del metodo del controlador
// RetornaPersonasLista()
function obtenerRegistros() {
    /////construir la dirección del método del servidor
    var urlMetodo = '/Facturacion/RetornaListaFactura'
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
                field: 'nombreUsuario',
                ///texto del encabezado
                title: 'Nombre Cliente'
            },
            {
                field: 'plcaVehiculo',
                title: 'Placa Vehiculo'
            },
            {
                field: 'Fecha',
                title: 'Fecha Creacion'
            },
            {
                field: 'MontoTotalServicio',
                title: 'Monto Final'
            },
            {
                field: 'EstadoFactura',
                title: 'Estado Factura'
            },
            {
                title: "Acciones",
                template: function (dataItem) {
                    return "<a href='/Facturacion/EncabezadoFacModifica?idEncabezadoFac=" + dataItem.idEncabezadoFac + "'>Modificar</a>"
                }
            }
        ],
        filterable: true,
        toolbar: ["excel", "pdf"],
        excel: {
            fileName: "Lista de Personas.xlsx",
            filterable: true,
            allPages: true
        },
        pdf: {
            fileName: "Lista de Personas.pdf",
            autor: "UMCA",
            creator: "Daniel Diaz",
            date: new Date(),
        }

    });
}