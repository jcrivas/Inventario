using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities; 

namespace ByS.Inventario.Data
{
    public class daDetalleNotaIngreso
    {
        public List<beDetalleNotaIngreso> ListarxNota(SqlConnection con, int idNota)
        {
            List<beDetalleNotaIngreso> lista = new List<beDetalleNotaIngreso>();
            SqlCommand cmd = new SqlCommand("uspDetalleNotaIngresoListarxNota", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", idNota);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beDetalleNotaIngreso obeNotaIngreso = new beDetalleNotaIngreso();
                    obeNotaIngreso.NumeroNotaIngreso = drd.GetInt32(0);
                    obeNotaIngreso.IdProducto = drd.GetInt32(1);
                    obeNotaIngreso.NombreProducto = drd.GetString(2);
                    obeNotaIngreso.Cantidad = drd.GetDecimal(3);
                    obeNotaIngreso.CantidadInternar = Decimal.Round(obeNotaIngreso.Cantidad,0);
                    lista.Add(obeNotaIngreso);
                }
                drd.Close();
            }
            return lista;
        }

        public beDetalleNotaIngreso ListarxNotaProducto(SqlConnection con, int idNota, int idProducto)
        {
            beDetalleNotaIngreso obeDetalleNotaIngreso = new beDetalleNotaIngreso();
            SqlCommand cmd = new SqlCommand("uspDetalleNotaIngresoListarxNotaProducto", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", idNota);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (drd != null)
            {
                drd.Read();
                obeDetalleNotaIngreso.NumeroNotaIngreso = drd.GetInt32(0);
                obeDetalleNotaIngreso.IdProducto = drd.GetInt32(1);
                obeDetalleNotaIngreso.NombreProducto = drd.GetString(2);
                obeDetalleNotaIngreso.Cantidad = drd.GetDecimal(3);
                drd.Close();
            }
            return obeDetalleNotaIngreso;
        }

        public Boolean ActualizarCantidad(SqlConnection con, beDetalleNotaIngreso obeDetalleNotaIngreso)
        {
            SqlCommand cmd = new SqlCommand("uspDetalleNotaIngresoActualizarCantidad", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", obeDetalleNotaIngreso.NumeroNotaIngreso);
            cmd.Parameters.AddWithValue("@IdProducto", obeDetalleNotaIngreso.IdProducto);
            cmd.Parameters.AddWithValue("@Cantidad", obeDetalleNotaIngreso.Cantidad);

            cmd.ExecuteNonQuery();

            return true;
        }

        public Boolean Insertar(SqlConnection con, beDetalleNotaIngreso obeDetalleNotaIngreso)
        {
            SqlCommand cmd = new SqlCommand("uspDetalleNotaIngresoInsertar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", obeDetalleNotaIngreso.NumeroNotaIngreso);
            cmd.Parameters.AddWithValue("@IdProducto", obeDetalleNotaIngreso.IdProducto);
            cmd.Parameters.AddWithValue("@Cantidad", obeDetalleNotaIngreso.Cantidad);

            cmd.ExecuteNonQuery();

            return true;
        }

        public void EliminarProducto(SqlConnection con, beDetalleNotaIngreso obeDetalleNotaIngreso)
        {
            SqlCommand cmd = new SqlCommand("uspDetalleNotaIngresoEliminarProducto", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", obeDetalleNotaIngreso.NumeroNotaIngreso);
            cmd.Parameters.AddWithValue("@IdProducto", obeDetalleNotaIngreso.IdProducto);

            cmd.ExecuteNonQuery();
        }
    }
}
