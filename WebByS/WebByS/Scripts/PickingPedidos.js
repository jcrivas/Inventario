window.onload = function () {
    var btnFiltrar = document.getElementById("btnFiltrar");

    btnFiltrar.onclick = function () {
        var txtPedidoInicio = document.getElementById("txtPedidoInicio");
        var txtPedidoFin = document.getElementById("txtPedidoFin");
        //var cboSucursal = document.getElementById("IdSucursal");
        
        //$.ajax({
        //    type: "get",
        //    url: "../Picking/Filtro/?PedidoInicio=" + txtPedidoInicio.value + "&PedidoFin=" + txtPedidoFin.value + "&Sucursal=" + cboSucursal.value,
        //    dataType: "json",
        //    success: mostrarConsulta,
        //    error: errorConsulta
        //});
    }
}

function mostrarConsulta(data) {
    //var str = JSON.stringify(data);
    alert('redibujar');
    var n = data.length;
    var contenido = "";
    for (i = 0; i < n; i++) {
        contenido += "<tr>";
        contenido += "<td>Pedido: " + data[i].NumeroPedido + "</td>";
        contenido += "<td>" + data[i].NombreSucursal + "</td>";
        contenido += "<td>" + data[i].FechaFormateada + "</td>";
        contenido += "<td><input type='checkbox' value='" + data[i].Seleccionado + "'></td>";
        //contenido += "<td><a title='Eliminar' onclick='return confirm(\"¿Está seguro de eliminar?\");' href='Delete/" + data[i].NumeroNotaIngreso + "'>Eliminar</a> | <a title='Editar' href='Editar/" + data[i].NumeroNotaIngreso + "'>Editar</a></td>";

        contenido += "</tr>";
    }
    $("#tbPedido").html(contenido);
}

function errorConsulta(rpta) {
    alert(rpta.statusText);
}