window.onload = function () {
    var btnFiltrar = document.getElementById("btnFiltrar");
    $('#txtFechaInicio').datepicker({ dateFormat: 'dd/mm/yy' });
    $('#txtFechaFin').datepicker({ dateFormat: 'dd/mm/yy' });

    btnFiltrar.onclick = function () {

        var txtFechaInicio = document.getElementById("txtFechaInicio");
        var txtFechaFin = document.getElementById("txtFechaFin");
        var txtNumeroNotaIngreso = document.getElementById("txtNumeroNotaIngreso");
        var cboProveedor = document.getElementById("Proveedor");

        var fecha_inicio = new Date(txtFechaInicio.value.substring(3, 5) + "/" + txtFechaInicio.value.substring(0, 2) + "/" + txtFechaInicio.value.substring(6, 10));
        var fecha_fin = new Date(txtFechaFin.value.substring(3, 5) + "/" + txtFechaFin.value.substring(0, 2) + "/" + txtFechaFin.value.substring(6, 10));
        //var fecha_inicio = new Date(txtFechaInicio.value);
        //var fecha_fin = new Date(txtFechaFin.value);
        if (fecha_inicio > fecha_fin) {
            alert('La fecha de inicio no puede ser mayor que la fecha final');
            return false;
        }

        $.ajax({
            type: "get",
            url: "../NotaIngreso/Filtro/?FechaInicio=" + txtFechaInicio.value + "&FechaFin=" + txtFechaFin.value + "&Numero=" + txtNumeroNotaIngreso.value + "&Proveedor=" + cboProveedor.value,
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
        contenido += "<td><a title='Editar' href='Editar/" + data[i].NumeroNotaIngreso + "'><img src='../../Content/images/editar-icono.png' alt='Editar' /></a>"
        if (data[i].EstadoNotaIngreso == "G") {
            contenido += "<a title='Eliminar' onclick='return confirm(\"¿Está seguro de anular?\");' href='Delete/" + data[i].NumeroNotaIngreso + "'><img src='../../Content/images/eliminar-icono.png' alt='Eliminar' /></a>"
        }
        contenido += "</td>";
        contenido += "<td>" + data[i].NumeroNotaIngreso + "</td>";
        contenido += "<td>" + data[i].NumeroOrdenCompra + "</td>";
        contenido += "<td>" + data[i].FechaFormateada + "</td>";
        contenido += "<td>" + data[i].NombreProveedor + "</td>";
        contenido += "<td>" + data[i].EstadoDescripcion + "</td>";
        contenido += "</tr>";
    }
    $("#tbNotaIngreso").html(contenido);
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
