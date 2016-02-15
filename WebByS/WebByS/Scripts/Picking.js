window.onload = function () {
    var btnFiltrar = document.getElementById("btnFiltrar");

    $('#txtFecha').datepicker({ dateFormat: 'dd/mm/yy' });

    btnFiltrar.onclick = function () {

        var txtPedidoInicio = document.getElementById("txtPedidoInicio");
        var txtPedidoFin = document.getElementById("txtPedidoFin");
        var cboSucursal = document.getElementById("IdSucursal");

        if (txtPedidoInicio.value.length > 0 && txtPedidoFin.value.length == 0) {
            alert('¡¡ Ingrese pedido final !!')
            txtPedidoFin.focus();
            return false;
        }

        if (txtPedidoInicio.value.length == 0 && txtPedidoFin.value.length > 0) {
            alert('¡¡ Ingrese pedido inicial !!')
            txtPedidoInicio.focus();
            return false;
        }
        if (txtPedidoInicio.value.length > 0 && txtPedidoFin.value.length > 0 && txtPedidoInicio.value > txtPedidoFin.value) {
            alert('¡¡ Pedido inicial no debe de ser mayor que pedido final !!')
            txtPedidoInicio.focus();
            return false;
        }

        if (txtPedidoInicio.value.length == 0 && txtPedidoFin.value.length == 0 && cboSucursal.value.length == 0) {
            alert('¡¡ Ingrese un criterio de filtro !!')
            txtPedidoInicio.focus();
            return false;
        }
        //if (val(txtPedidoFin) < val(txtPedidoInicio))

        //    $.ajax({
        //        type: "get",
        //        url: "../Picking/Filtro/?PedidoInicio=" + txtPedidoInicio.value + "&PedidoFin=" + txtPedidoFin.value + "&Sucursal=" + cboSucursal.value,
        //        dataType: "json",
        //        success: mostrarConsulta,
        //        error: errorConsulta
        //    });
    }

    var btnGrabar = document.getElementById("btnGrabar");

    btnGrabar.onclick = function () {
        if (validarCampoLista("IdEmpleado", "Responsable") == false) return false;

        var txtFecha = document.getElementById("txtFecha");

        var fecha_inicio = new Date(txtFecha.value.substring(3, 5) + "/" + txtFecha.value.substring(0, 2) + "/" + txtFecha.value.substring(6, 10));
        var fecha_fin = new Date();

        if (fecha_inicio < fecha_fin) {
            alert('La fecha de grabación no puede ser menor que la fecha actual');
            return false;
        }
    }
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

function mostrarConsulta(data) {
    //var str = JSON.stringify(data);
    var n = data.length;
    var contenido = "";
    for (i = 0; i < n; i++) {
        contenido += "<tr>";
        contenido += "<td>Pedido: " + data[i].NumeroPedido + "</td>";
        contenido += "<td>" + data[i].NombreSucursal + "</td>";
        contenido += "<td>" + data[i].FechaFormateada + "</td>";
        contenido += "<td><input type='checkbox' value='" + data[i].Seleccionado + "'><input name='" + [i].Seleccionado + " type='hidden' value='" + data[i].Seleccionado + "'></td>";
        //contenido += "<td><a title='Eliminar' onclick='return confirm(\"¿Está seguro de eliminar?\");' href='Delete/" + data[i].NumeroNotaIngreso + "'>Eliminar</a> | <a title='Editar' href='Editar/" + data[i].NumeroNotaIngreso + "'>Editar</a></td>";

        contenido += "</tr>";
    }
    $("#tbPedido").html(contenido);
}

function errorConsulta(rpta) {
    alert(rpta.statusText);
}