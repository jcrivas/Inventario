using System;

namespace ByS.Inventario.Entities
{
    public class beNotaIngreso
    {
        public beNotaIngreso() { }

        public int NumeroNotaIngreso { get; set; }
        public DateTime Fecha { get; set; }
        public String NumeroOrdenCompra { get; set; }
        public int IdEmpleado { get; set; }
        public String UsuarioRecibo { get; set; }
        public int IdAlmacen { get; set; }
        public String GuiaRemision { get; set; }
        public String Observaciones { get; set; }
        public String EstadoNotaIngreso { get; set; }
        public String EstadoDescripcion { get; set; }
        public int IdProveedor { get; set; }
        public String NombreAlmacen { get; set; }
        public String NombreProveedor { get; set; }
        public String DescrionEstado { get; set; }
        public String FechaFormateada { get; set; }
    }
}
