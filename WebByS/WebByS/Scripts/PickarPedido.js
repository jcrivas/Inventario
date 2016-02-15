window.onload = function () {
    var btnFiltrar = document.getElementById("btnFiltrar");

    btnFiltrar.onclick = function () {
        //if (validarCampo("txtNumeroPedido", "Número de Pedido") == false) return false;

        var txtNumeroPedido = document.getElementById("txtNumeroPedido");

        $.ajax({
            type: "get",
            url: "../Picking/FiltroPickar/?NumeroPedido=" + txtNumeroPedido.value,
            dataType: "json",
            success: mostrarConsulta,
            error: errorConsulta
        });
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

function mostrarConsulta(data) {
    //var str = JSON.stringify(data);
    var n = data.length;
    var contenido = "";
    for (i = 0; i < n; i++) {
        contenido += "<tr>";
        contenido += "<td><a title='Pickar' href='Pickar/" + data[i].NumeroPedido + "'>Pickar</a></td>";
        contenido += "<td>" + data[i].FechaFormateada + "</td>";
        contenido += "<td>" + data[i].NumeroPedido + "</td>";
        contenido += "<td>" + data[i].NombreSucursal + "</td>";
        contenido += "<td>" + data[i].DescripcionEstado + "</td>";
        contenido += "</tr>";
    }
    $("#tbDetalle").html(contenido);
    if (n == 0) {
        alert('No existen registros para criterio seleccionado');
    }
}

function errorConsulta(rpta) {
    alert(rpta.statusText);
}