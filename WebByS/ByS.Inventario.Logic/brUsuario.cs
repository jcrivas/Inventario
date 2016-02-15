using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brUsuario : brGeneral
    {
        public beEmpleado ValidarLogin(string usuario, string clave)
        {
            beEmpleado obeEmpleado = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daUsuario odaUsuario = new daUsuario();
                    obeEmpleado = odaUsuario.ValidarLogin(con, usuario, clave);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return obeEmpleado;
        }
    }
}
