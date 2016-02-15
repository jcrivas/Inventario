using System;

namespace ByS.Inventario.Entities
{
    public class beUsuario
    {
        public beUsuario() { }

        public int IdUsuario { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
