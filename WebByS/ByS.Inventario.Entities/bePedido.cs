using System;

namespace ByS.Inventario.Entities
{
    public class bePedido
    {
        public bePedido() { }

        public String NumeroPedido { get; set; }
        public DateTime Fecha { get; set; }
        public int IdSucursal { get; set; }
        public int Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public String UsuarioRegistro { get; set; }
        public String UsuarioAsignado { get; set; }
        public int IdProducto { get; set; }
        public String NombreSucursal { get; set; }
        public String FechaFormateada { get; set; }
        public Boolean Seleccionado { get; set; }
        public String Direccion { get; set; }
    }

    public class beDetallePedido
    {
        public beDetallePedido() { }

        public int Item { get; set; }
        public String NumeroPedido { get; set; }
        public int IdProducto { get; set; }
        public String NombreProducto { get; set; }
        public Decimal Cantidad { get; set; }
    }
}
