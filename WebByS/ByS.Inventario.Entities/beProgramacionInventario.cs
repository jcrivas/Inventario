using System;

namespace ByS.Inventario.Entities
{
    public class beProgramacionInventario
    {
        public beProgramacionInventario() {}

        public int IdProgramacionInventario { get; set; }
        public int IdSucursal { get; set; }
        public int IdAlmacen { get; set; }
        public DateTime FechaInventario { get; set; }
        public String DescripcionInventario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public String NombreSucursal { get; set; }
        public String NombreAlmacen { get; set; }
        public String FechaFormateada { get; set; }
        public String FechaInventarioTexto { get; set; }
    }
}
