using System;

namespace ByS.Inventario.Entities
{
    public class beSucursal
    {
        public beSucursal() { }

        public int IdSucursal { get; set; }
        public String NombreSucursal { get; set; }
        public String Direccion { get; set; }
        public String Ruc { get; set; }
        public String Telefono { get; set; }
        public String Responsable { get; set; }
    }
}
