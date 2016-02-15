using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities;

namespace ByS.Inventario.Data
{
    public class daProducto
    {
        public List<beProducto> Listar(SqlConnection con)
        {
            List<beProducto> lista = new List<beProducto>();
            SqlCommand cmd = new SqlCommand("uspProductoListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beProducto obeProducto = new beProducto();
                    obeProducto.IdProducto = drd.GetInt32(0);
                    obeProducto.Descripcion = drd.GetString(1);
                    obeProducto.UnidadMedida = drd.GetString(2);
                    obeProducto.Presentacion = drd.GetString(3);
                    lista.Add(obeProducto);
                }
                drd.Close();
            }
            return lista;
        }

        public beProducto ListarxId(SqlConnection con, int intProducto)
        {
            beProducto obeProducto = new beProducto();
            SqlCommand cmd = new SqlCommand("uspProductoListarxId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProducto", intProducto);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (drd != null)
            {
                if (drd.HasRows)
                {
                    drd.Read();
                    obeProducto.IdProducto = drd.GetInt32(0);
                    obeProducto.Descripcion = drd.GetString(1);
                    obeProducto.UnidadMedida = drd.GetString(2);
                    obeProducto.Presentacion = drd.GetString(3);
                }
                drd.Close();
            }
            return obeProducto;
        }
    }
}
