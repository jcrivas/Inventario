using System;

namespace ByS.Inventario.Entities
{
    public class beAlmacen
    {
        public beAlmacen() { }

        public int IdAlmacen { get; set; }
        public String NombreAlmacen { get; set; }
        public String Direccion { get; set; }
        public String UsuarioRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
