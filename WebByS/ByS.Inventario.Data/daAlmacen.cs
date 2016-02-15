using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities;

namespace ByS.Inventario.Data
{
    public class daAlmacen
    {
        public List<beAlmacen> Listar(SqlConnection con)
        {
            List<beAlmacen> lista = new List<beAlmacen>();
            SqlCommand cmd = new SqlCommand("uspAlmacenListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beAlmacen fila = new beAlmacen();

                    fila.IdAlmacen = drd.GetInt32(0);
                    fila.NombreAlmacen = drd.GetString(1);
                    fila.Direccion = drd.GetString(2);
                    fila.UsuarioRegistro = drd.GetString(3);
                    fila.FechaRegistro = drd.GetDateTime(4);

                    lista.Add(fila);
                }
                drd.Close();
            }
            return lista;
        }
    }
}
