window.onload = function () {
    var btnGrabar = document.getElementById("btnGrabar");
    var btnReabastecer = document.getElementById("btnReabastecer");

    btnGrabar.onclick = function () {
        if (validarCampo("CantidadAtendida", "Cantidad a atender") == false) return false;
        if (CantidadAtendida.value == 0) {
            alert('¡¡ Ingrese cantidad a atender !!')
            CantidadAtendida.focus();
            return false;
        }
        if (CantidadAtendida.value < CantidadPedido.value) {
            alert("Cantidad atendida es menor a la solicitada, se generará una solicitud de reabastecimiento")
            //if (confirm("Cantidad atendida es menor a la solicitada, desea reabastecer?")) {
            //    CantidadAtendida.focus();
            //    return false;
            //}
        }
        if (CantidadAtendida.value > CantidadPedido.value) {
            alert("Cantidad atendida no puede ser mayor a lo solicitado");
            CantidadAtendida.focus();
            return false;
        }
    }

    btnReabastecer.onclick = function () {
        if (validarCampo("CantidadAtendida", "Cantidad a atender") == false) return false;
        alert("Se envió solicitud de reabastecimiento del producto");
        return false;
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
