window.onload = function () {
    var btnFiltrar = document.getElementById("btnFiltrar");

    $('#txtFechaInicio').datepicker({ dateFormat: 'dd/mm/yy' });
    $('#txtFechaFin').datepicker({ dateFormat: 'dd/mm/yy' });

    btnFiltrar.onclick = function () {
        var txtFechaInicio = document.getElementById("txtFechaInicio");
        var txtFechaFin = document.getElementById("txtFechaFin");
        var txtTipo = document.getElementById("Tipo");
        var txtNumero = document.getElementById("txtNumero");

        //var fecha_inicio = new Date(txtFechaInicio.value);
        //var fecha_fin = new Date(txtFechaFin.value);
        var fecha_inicio = new Date(txtFechaInicio.value.substring(3, 5) + "/" + txtFechaInicio.value.substring(0, 2) + "/" + txtFechaInicio.value.substring(6, 10));
        var fecha_fin = new Date(txtFechaFin.value.substring(3, 5) + "/" + txtFechaFin.value.substring(0, 2) + "/" + txtFechaFin.value.substring(6, 10));

        if (fecha_inicio > fecha_fin) {
            alert('La fecha de inicio no puede ser mayor que la fecha final');
            return false;
        }

        $.ajax({
            type: "get",
            url: "../ProductoAlmacenar/Filtro/?FechaInicio=" + txtFechaInicio.value + "&FechaFin=" + txtFechaFin.value + "&Tipo=" + txtTipo.value + "&Numero=" + txtNumero.value,
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
        contenido += "<td><a title='Internar' href='ProductoAlmacenar/" + data[i].Sigla + "'>Internar</a></td>";
        contenido += "<td>" + data[i].FechaFormateada + "</td>";
        contenido += "<td>" + data[i].Tipo + "</td>";
        contenido += "<td>" + data[i].nOrdenCompra + "</td>";
        contenido += "<td>" + data[i].EstadoDescripcion + "</td>";
        contenido += "</tr>";
    }
    $("#tbDocumento").html(contenido);
    if (n == 0) {
        alert('No existen registros para criterio seleccionado');
    }
}

function errorConsulta(rpta) {
    alert(rpta.statusText);
}