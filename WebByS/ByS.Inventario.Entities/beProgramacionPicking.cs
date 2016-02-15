using System;

namespace ByS.Inventario.Entities
{
    public class beProgramacionPicking
    {
        public beProgramacionPicking() { }

        public int IdProgramacionPicking { get; set; }
        public int IdEmpleado { get; set; }
        public String Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public String Turno { get; set; }
        public String NumeroPedido { get; set; }
        public String FechaFormateada { get; set; }
        public String Responsable { get; set; }

        //OTRA ESTRUCTURA
        public int IdSucursal { get; set; }
        public int Estado { get; set; }
        public String NombreSucursal { get; set; }
        public String DescripcionEstado { get; set; }
    }

    public class beDetalleProgramacionPicking
    {
        public beDetalleProgramacionPicking() { }

        public int IdProgramacionPicking { get; set; }
        public String NumeroPedido { get; set; }
        public int IdProducto { get; set; }
        public int IdUbicacion { get; set; }
        public String Descripcion { get; set; }
        public int CantidadPedido { get; set; }
        public int CantidadAtendida { get; set; }
        public String NombreProducto { get; set; }
        public String UnidadMedida { get; set; }
        public int Saldo { get; set; }
        public int Stock { get; set; }
    }
}
