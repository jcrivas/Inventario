using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brEmpleado : brGeneral
    {
        public List<beEmpleadoRH> Listar()
        {
            List<beEmpleadoRH> lista = new List<beEmpleadoRH>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daEmpleado odaEmpleado = new daEmpleado();
                    lista = odaEmpleado.Listar(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }
    }
}
