using System;

namespace ByS.Inventario.Entities
{
    public class beDetalleNotaIngreso
    {
        public beDetalleNotaIngreso() { }

        public int NumeroNotaIngreso { get; set; }
        public int IdProducto { get; set; }
        public String NombreProducto { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal CantidadInternar { get; set; }
    }
}
