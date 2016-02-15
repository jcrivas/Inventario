using System;
using System.Web;

namespace ByS.General.Entities
{
    public class beLog
    {
        public DateTime FechaHora { get; set; }
        public string MensajeError { get; set; }
        public string DetalleError { get; set; }
        public string Aplicacion { get; set; }
        public string Usuario { get; set; }

        public beLog()
        {            
            FechaHora = DateTime.Now;
            //Si es llamado por una aplicacion web
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["InfoApp"] != null)
                {
                    beInfoApp obeInfoApp = (beInfoApp)HttpContext.Current.Session["InfoApp"];
                    Aplicacion = obeInfoApp.Aplicacion;
                    Usuario = obeInfoApp.Usuario;
                }
            }
        }
    }
}
