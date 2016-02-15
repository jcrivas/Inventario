window.onload = function () {
    var btnGrabar = document.getElementById("btnGrabar");

    btnGrabar.onclick = function () {
        if (validarCampo("Cantidad", "Cantidad") == false) return false;
        if (Cantidad.value == 0) {
            alert('¡¡ Ingrese cantidad a atender !!')
            Cantidad.focus();
            return false;
        }
        if (confirm("¿Está seguro de grabar?") == false) return false;
    }
}

function validarCampo(Tex, Mensaje) {
    var Texto = document.getElementById(Tex);
    if (Texto != null) {
        if (Texto.value.replace(/^\s+|\s+$/g, "").length == 0) {
            alert('¡¡ Favor de ingresar ' + Mensaje + ' !!');
            Texto.focus();
            return false;
        }
        if (Texto.value.match(/([\<])([^\>]{1,})*([\>])/i) != null) {
            alert(Mensaje + ' No debe contener etiquetas html: <etiqueta>');
            Texto.select();
            Texto.focus();
            return false;
        }
        if (Texto.value.match(/[,;]+/) != null) {
            alert(Mensaje + ' No debe contener , o ;');
            Texto.select();
            Texto.focus();
            return false;
        }
    }
    return true;
}
