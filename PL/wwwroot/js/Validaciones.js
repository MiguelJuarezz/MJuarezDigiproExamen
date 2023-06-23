﻿function SoloLetras(e, idTextBox, idLabel, idAddon) {
    var caracter = e.key;
    if (!/^[a-zA-Z]/g.test(caracter)) {
        $('#' + idLabel).text("Solo se permiten letras");
        $('#' + idLabel).css({ "color": "red" });
        $('#' + idTextBox).css({ "border-color": "red" });
        $('#' + idAddon).css({ "border-color": "red", "background-color": "#f8d7da" });
        return false;
    }
    else {
        $('#' + idLabel).text("");
        $('#' + idLabel).css({ "color": "green" });
        $('#' + idTextBox).css({ "border-color": "green" });
        $('#' + idAddon).css({ "border-color": "green", "background-color": "#5CB443" });

    }
}
function SoloNumeros(e, idTextBox, idLabel, input) {
    var caracter = e.key;
    if (!/^\d+$/g.test(caracter)) {
        $('#' + idLabel).text("Solo se permiten numeros");
        $('#' + idLabel).css({ "color": "red" });
        $('#' + idTextBox).css({ "border-color": "red" });
        $('#' + input).css({ "border-color": "red", "background-color": "#f8d7da" });
        return false;
    }
    else {
        $('#' + idLabel).text("");
        $('#' + idLabel).css({ "color": "green" });
        $('#' + idTextBox).css({ "border-color": "green" });
        $('#' + input).css({ "border-color": "green", "background-color": "#5CB443" });

    }
}