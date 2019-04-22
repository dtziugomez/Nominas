function GetValidatorNumSinDecimal(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[1234567890]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);

}
function GetValidatorLetras(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[a-zA-ZÑñ]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);

}
function GetValidatorNumConDecimal(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    patron = /[1234567890.]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}