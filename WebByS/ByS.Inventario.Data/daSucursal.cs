using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities;

namespace ByS.Inventario.Data
{
    public class daSucursal
    {
        public List<beSucursal> Listar(SqlConnection con)
        {
            List<beSucursal> lista = new List<beSucursal>();
            SqlCommand cmd = new SqlCommand("uspSucursalListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beSucursal obebeSucursal = new beSucursal();

                    obebeSucursal.IdSucursal = drd.GetInt32(0);
                    obebeSucursal.NombreSucursal = drd.GetString(1);
                    obebeSucursal.Direccion = drd.GetString(2);
                    obebeSucursal.Ruc = drd.GetString(3);
                    obebeSucursal.Telefono = drd.GetString(4);
                    obebeSucursal.Responsable = drd.GetString(5);

                    lista.Add(obebeSucursal);
                }
                drd.Close();
            }
            return lista;
        }
    }
}
