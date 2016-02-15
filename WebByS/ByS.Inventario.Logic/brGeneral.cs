using System;
using System.Configuration;
using ByS.General.Entities; //beLog
using ByS.General.CodigoUsuario; //ucObjeto

namespace ByS.Inventario.Logic
{
    public class brGeneral
    {
        public string CadenaConexion { get; set; }
        private string rutaLog;

        public brGeneral()
        {
           CadenaConexion =  ConfigurationManager.ConnectionStrings["conBD"].ConnectionString;
           rutaLog = ConfigurationManager.AppSettings["rutaLog"];
        }

        public void GrabarLog(Exception ex)
        {
            beLog obeLog = new beLog();
            obeLog.MensajeError = ex.Message;
            obeLog.DetalleError = ex.StackTrace;
            string archivo = String.Format("{0}LogError_{1}_{2}_{3}.txt",rutaLog,DateTime.Now.Year,
                DateTime.Now.Month.ToString().PadLeft(2, '0'), DateTime.Now.Day.ToString().PadLeft(2, '0'));
            ucObjeto.Grabar(obeLog, archivo);
        }
    }
}
