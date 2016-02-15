using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brProveedor : brGeneral
    {
        public List<beProveedor> Listar()
        {
            List<beProveedor> lista = new List<beProveedor>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProveedor odaProveedor = new daProveedor();
                    lista = odaProveedor.Listar(con);
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
