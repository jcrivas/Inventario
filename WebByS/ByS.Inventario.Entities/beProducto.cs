using System;

namespace ByS.Inventario.Entities
{
    public class beProducto
    {
        public beProducto() { }

        public int IdProducto { get; set; }
        public String Descripcion { get; set; }
        public String UnidadMedida { get; set; }
        public String Presentacion { get; set; }
    }
}
