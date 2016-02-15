using System;

namespace ByS.Inventario.Entities
{
    public class beOrdenCompra
    {
        public beOrdenCompra() { }

        public String nOrdenCompra { get; set; }
        public DateTime Fecha { get; set; }
        public String Transportista { get; set; }
        public String DireccionEntrega { get; set; }
        public int IdProducto { get; set; }
        public int IdProveedor { get; set; }
        public String Estado { get; set; }
        public String EstadoDescripcion { get; set; }
        public String Tipo { get; set; }
        public String Sigla { get; set; }
        public String FechaFormateada { get; set; }
    }

    public class beDetalleOrdenCompra
    {
        public beDetalleOrdenCompra() { }

        public String nOrdenCompra { get; set; }
        public int IdProducto { get; set; }
        public String NombreProducto { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal CantidadInternar { get; set; }
    }
}
