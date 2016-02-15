using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brProducto : brGeneral
    {
        public List<beProducto> Listar()
        {
            List<beProducto> lista = new List<beProducto>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProducto odaProducto = new daProducto();
                    lista = odaProducto.Listar(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public beProducto ListarxId(int intProducto)
        {
            beProducto obeProducto = new beProducto();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProducto odaProducto = new daProducto();
                    obeProducto = odaProducto.ListarxId(con, intProducto);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return obeProducto;
        }
    }
}
