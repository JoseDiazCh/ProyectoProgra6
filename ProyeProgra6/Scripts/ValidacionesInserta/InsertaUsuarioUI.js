$(function () {
    creaElementosJqueryUI();
});
///Función que crea los elementos de jqueryUI
function creaElementosJqueryUI() {
    ///creamos el control de tipo datepicker
    crearDatePicker();
}

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