using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities;

namespace ByS.Inventario.Data
{
    public class daProgramacionInventario
    {
        public List<beProgramacionInventario> Listar(SqlConnection con)
        {
            List<beProgramacionInventario> lista = new List<beProgramacionInventario>();
            SqlCommand cmd = new SqlCommand("uspProgramacionInventarioListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beProgramacionInventario obeProgramacionInventario = new beProgramacionInventario();
                    obeProgramacionInventario.IdProgramacionInventario = drd.GetInt32(0);
                    obeProgramacionInventario.IdSucursal = drd.GetInt32(1);
                    obeProgramacionInventario.IdAlmacen = drd.GetInt32(2);
                    obeProgramacionInventario.FechaInventario = drd.GetDateTime(3);
                    obeProgramacionInventario.DescripcionInventario = drd.GetString(4);
                    obeProgramacionInventario.FechaRegistro = drd.GetDateTime(5);
                    obeProgramacionInventario.NombreSucursal = drd.GetString(6);
                    obeProgramacionInventario.NombreAlmacen = drd.GetString(7);
                    obeProgramacionInventario.FechaFormateada = obeProgramacionInventario.FechaInventario.ToString("dd/MM/yyyy");

                    lista.Add(obeProgramacionInventario);
                }
                drd.Close();
            }
            return lista;
        }

        public beProgramacionInventario ListarxID(SqlConnection con, int intProgramacionInventario)
        {
            beProgramacionInventario fila = new beProgramacionInventario();
            SqlCommand cmd = new SqlCommand("uspProgramacionInventarioListarxId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProgramacionInventario", intProgramacionInventario);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (drd != null)
            {
                while (drd.Read())
                {
                    fila.IdProgramacionInventario = drd.GetInt32(0);
                    fila.IdSucursal = drd.GetInt32(1);
                    fila.IdAlmacen = drd.GetInt32(2);
                    fila.FechaInventario = drd.GetDateTime(3);
                    fila.DescripcionInventario = drd.GetString(4);
                    fila.FechaRegistro = drd.GetDateTime(5);
                    fila.NombreSucursal = drd.GetString(6);
                    fila.NombreAlmacen = drd.GetString(7);
                    fila.FechaInventarioTexto = fila.FechaInventario.ToString("dd/MM/yyyy");
                    fila.FechaFormateada = fila.FechaInventario.ToString("dd/MM/yyyy");

                }
                drd.Close();
            }
            return fila;
        }

        public List<beProgramacionInventario> Filtrar(SqlConnection con, String pstrDescripcion, int intSucursal)
        {
            List<beProgramacionInventario> lista = new List<beProgramacionInventario>();
            SqlCommand cmd = new SqlCommand("uspProgramacionInventarioFiltrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idSucursal", intSucursal);
            cmd.Parameters.AddWithValue("@descripcionInventario", pstrDescripcion);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beProgramacionInventario obeProgramacionInventario = new beProgramacionInventario();
                    obeProgramacionInventario.IdProgramacionInventario = drd.GetInt32(0);
                    obeProgramacionInventario.IdSucursal = drd.GetInt32(1);
                    obeProgramacionInventario.IdAlmacen = drd.GetInt32(2);
                    obeProgramacionInventario.FechaInventario = drd.GetDateTime(3);
                    obeProgramacionInventario.DescripcionInventario = drd.GetString(4);
                    obeProgramacionInventario.FechaRegistro = drd.GetDateTime(5);
                    obeProgramacionInventario.NombreSucursal = drd.GetString(6);
                    obeProgramacionInventario.NombreAlmacen = drd.GetString(7);
                    obeProgramacionInventario.FechaFormateada = obeProgramacionInventario.FechaInventario.ToString("dd/MM/yyyy");

                    lista.Add(obeProgramacionInventario);
                }
                drd.Close();
            }
            return lista;
        }

        public Boolean Insertar(SqlConnection con, beProgramacionInventario obeProgramacionInventario)
        {
            SqlCommand cmd = new SqlCommand("uspProgramacionInventarioInsertar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            obeProgramacionInventario.FechaInventario = DateTime.Parse(obeProgramacionInventario.FechaInventarioTexto);
            cmd.Parameters.AddWithValue("@idProgramacionInventario", obeProgramacionInventario.IdProgramacionInventario);
            cmd.Parameters.AddWithValue("@idSucursal", obeProgramacionInventario.IdSucursal);
            cmd.Parameters.AddWithValue("@IdAlmacen", obeProgramacionInventario.IdAlmacen);
            cmd.Parameters.AddWithValue("@fechaInventario", obeProgramacionInventario.FechaInventario);
            cmd.Parameters.AddWithValue("@descripcionInventario", obeProgramacionInventario.DescripcionInventario);
            //cmd.Parameters.AddWithValue("@fechaRegistro", obeProgramacionInventario.FechaRegistro);

            cmd.ExecuteNonQuery();

            return true;
        }

        public Boolean Actualizar(SqlConnection con, beProgramacionInventario obeProgramacionInventario)
        {
            SqlCommand cmd = new SqlCommand("uspProgramacionInventarioActualizar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            obeProgramacionInventario.FechaInventario = DateTime.Parse(obeProgramacionInventario.FechaInventarioTexto);
            cmd.Parameters.AddWithValue("@idProgramacionInventario", obeProgramacionInventario.IdProgramacionInventario);
            cmd.Parameters.AddWithValue("@idSucursal", obeProgramacionInventario.IdSucursal);
            cmd.Parameters.AddWithValue("@IdAlmacen", obeProgramacionInventario.IdAlmacen);
            cmd.Parameters.AddWithValue("@fechaInventario", obeProgramacionInventario.FechaInventario);
            cmd.Parameters.AddWithValue("@descripcionInventario", obeProgramacionInventario.DescripcionInventario);
            //cmd.Parameters.AddWithValue("@fechaRegistro", obeProgramacionInventario.FechaRegistro);

            cmd.ExecuteNonQuery();

            return true;
        }

        public void EliminarRegistro(SqlConnection con, int intProgramacionInventario)
        {
            List<beNotaIngreso> lista = new List<beNotaIngreso>();
            SqlCommand cmd = new SqlCommand("uspProgramacionInventarioEliminarxId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProgramacionInventario", intProgramacionInventario);
            cmd.ExecuteNonQuery();
        }
    }
}
