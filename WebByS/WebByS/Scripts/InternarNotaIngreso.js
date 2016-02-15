function enviarServidor(url, metodo) {
    var xhr = new XMLHttpRequest();
    xhr.open("get", url, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            metodo(xhr.responseText);
        }
    }
    xhr.send();
}

window.onload = function () {
    var btnGrabar = document.getElementById("btnGrabar");

    btnGrabar.onclick = function () {

        if (validarCampoLista("IdAlmacen", "Almacén") == false) return false;

        //$("#tbDetalle tbody tr").each(function (index) {
        //    var campo1, campo2, campo3;
        //    var data = {};
        //    $(this).children("td").each(function (index2) {
        //        switch (index2) {
        //            case 0: campo1 = $(this).text();
        //                break;
        //            case 1: campo2 = $(this).text();
        //                break;
        //            case 2: campo3 = $(this).text();
        //                break;
        //            case 3:
        //                campo4 = $(this).find('input[name^="CantidadInternar"]').val();
        //                break;
        //        }
        //        $(this).css("background-color", "#ECF8E0");
        //    })
        //    alert('Obtener los datos para grabar:\n ' + 'Codigo=>' + campo1 + ' Articulo=> ' + campo2 + ' Cantidad=> ' + campo4);
        //})
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

function OnSuccess(response) {
    console.log(response.d)
}

function recorrerTabla() {
    //var str = JSON.stringify(data);
    $("#tbDocumento tbody tr").each(function (index) {
        var campo1, campo2, campo3;
        $(this).children("td").each(function (index2) {
            switch (index2) {
                case 0: campo1 = $(this).text();
                    break;
                case 1: campo2 = $(this).text();
                    break;
                case 2: campo3 = $(this).text();
                    break;
            }
            $(this).css("background-color", "#ECF8E0");
        })
        alert(campo1 + ' - ' + campo2 + ' - ' + campo3);
    })
}

function clear() {
    alert('OK');
}

function errorConsulta(rpta) {
    alert(rpta.statusText);
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}