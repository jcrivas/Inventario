window.onload = function () {
    var btnGrabar = document.getElementById("btnGrabar");

    $('#FechaInventarioTexto').datepicker({ dateFormat: 'dd/mm/yy' });

    btnGrabar.onclick = function () {
        if (validarCampoLista("IdSucursal", "Sucursal") == false) return false;
        if (validarCampoLista("IdAlmacen", "Almacén") == false) return false;

        var txtFecha = document.getElementById("FechaInventarioTexto");

        var fecha_inicio = new Date(txtFecha.value.substring(3, 5) + "/" + txtFecha.value.substring(0, 2) + "/" + txtFecha.value.substring(6, 10));
        var fecha_fin = new Date();

        if (fecha_inicio < fecha_fin) {
            alert('La fecha de grabación no puede ser menor que la fecha actual');
            return false;
        }
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

function validarCampoLista(Tex, Mensaje) {
    var Texto = document.getElementById(Tex);
    if (Texto != null) {
        if (Texto.value.length == 0) {
            alert('¡¡ Favor de ingresar ' + Mensaje + ' !!');
            Texto.focus();
            return false;
        }
    }
    return true;
}
