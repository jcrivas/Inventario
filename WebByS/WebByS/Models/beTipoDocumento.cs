using System;

namespace WebByS.Models
{
    public class beTipoDocumento
    {
        public beTipoDocumento() { }

        public beTipoDocumento(String codigo, String descripcion) { Codigo = codigo; Descripcion = descripcion; }

        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}