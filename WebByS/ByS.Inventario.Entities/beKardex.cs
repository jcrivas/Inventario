using System;

namespace ByS.Inventario.Entities
{
    public class beKardex
    {
        public beKardex() { }

        public int NumeroKardex { get; set; }
        public int IdProducto { get; set; }
        public int IdAlmacen { get; set; }
        public String Observaciones { get; set; }
        public Decimal SaldoActual { get; set; }
        public int IdNotaIngreso { get; set; }
        public int IdNotaSalida { get; set; }
        public DateTime Fecha { get; set; }
        public int Ingreso { get; set; }
        public int Salidas { get; set; }
        public String CodigoCompra { get; set; }
        public int Cantidad { get; set; }
        public Decimal Costo { get; set; }

    }

    public class beDetalleKardex
    {
        public beDetalleKardex() { }

        public int NumeroKardex { get; set; }
        public String NumeroDocumento { get; set; }
        public int TipodeMovimiento { get; set; }
        public String NumeroNotaIngreso { get; set; }
        public String NumeroSalida { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

    }
}
