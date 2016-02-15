window.onload = function () {
    var btnFiltrar = document.getElementById("btnFiltrar");

    btnFiltrar.onclick = function () {

        var txtDescripcion = document.getElementById("txtDescripcion");
        var cboSucursal = document.getElementById("Sucursal");

        $.ajax({
            type: "get",
            url: "../Inventario/Filtro/?Descripcion=" + txtDescripcion.value + "&Sucursal=" + cboSucursal.value,
            dataType: "json",
            success: mostrarConsulta,
            error: errorConsulta
        });
    }
}

function mostrarConsulta(data) {
    //var str = JSON.stringify(data);
    var n = data.length;
    var contenido = "";
    for (i = 0; i < n; i++) {
        contenido += "<tr>";
        contenido += "<td><a title='Editar' href='Editar/" + data[i].IdProgramacionInventario + "'><img src='../../Content/images/editar-icono.png' alt='Editar' title='Editar' /></a><a title='Eliminar' onclick='return confirm(\"¿Está seguro de eliminar?\");' href='Delete/" + data[i].IdProgramacionInventario + "'><img src='../../Content/images/eliminar-icono.png' alt='Eliminar' title='Eliminar' /></a></td>";
        contenido += "<td>" + data[i].IdProgramacionInventario + "</td>";
        contenido += "<td>" + data[i].FechaFormateada + "</td>";
        contenido += "<td>" + data[i].NombreSucursal + "</td>";
        contenido += "<td>" + data[i].NombreAlmacen + "</td>";
        contenido += "<td>" + data[i].DescripcionInventario + "</td>";
        contenido += "</tr>";
    }
    $("#tbListado").html(contenido);
    if (n == 0) {
        alert('No existen registros para criterio seleccionado');
    }
}

function errorConsulta(rpta) {
    alert(rpta.statusText);
}