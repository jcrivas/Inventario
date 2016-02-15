using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brAlmacen : brGeneral
    {
        public List<beAlmacen> Listar()
        {
            List<beAlmacen> lista = new List<beAlmacen>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daAlmacen odaAlmacen = new daAlmacen();
                    lista = odaAlmacen.Listar(con);
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
