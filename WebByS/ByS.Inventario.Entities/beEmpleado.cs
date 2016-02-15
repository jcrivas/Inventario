using System;

namespace ByS.Inventario.Entities
{
    public class beEmpleado
    {
        public beEmpleado() { }

        public int IdEmpleado { get; set; }
        public int IdPersona { get; set; }
        public int IdCargo { get; set; }
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int intActivo { get; set; }
        public string UsuarioCreacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public string NombrePC { get; set; }
        public int intEliminado { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
