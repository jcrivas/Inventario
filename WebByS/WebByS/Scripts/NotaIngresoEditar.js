window.onload = function () {
    var btnGrabar = document.getElementById("btnGrabar");

    btnGrabar.onclick = function () {
        //var txtNumeroOrdenCompra = document.getElementById("txtNumeroOrdenCompra");
        if (validarCampo("NumeroOrdenCompra", "Número de Orden de Compra") == false) return false;
        if (validarCampo("GuiaRemision", "Guía de proveedor") == false) return false;
        if (validarCampo("IdEmpleado", "Supervisor") == false) return false;
        if (validarCampoLista("IdAlmacen", "Almacén") == false) return false;
        if (validarCampoLista("idProveedor", "Proveedor") == false) return false;
        //var cboAlmacen = document.getElementById("IdAlmacen");
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