using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities;

namespace ByS.Inventario.Data
{
    public class daProveedor
    {
        public List<beProveedor> Listar(SqlConnection con)
        {
            List<beProveedor> lista = new List<beProveedor>();
            SqlCommand cmd = new SqlCommand("uspProveedorListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beProveedor obeProveedor = new beProveedor();

                    obeProveedor.IdProveedor = drd.GetInt32(0);
                    obeProveedor.NombreProveedor = drd.GetString(1);
                    obeProveedor.Ruc = drd.GetString(2);
                    obeProveedor.Direccion = drd.GetString(3);

                    lista.Add(obeProveedor);
                }
                drd.Close();
            }
            return lista;
        }
    }
}
