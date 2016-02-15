using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities;

namespace ByS.Inventario.Data
{
    public class daProgramacionPicking
    {
        public List<beProgramacionPicking> Listar(SqlConnection con)
        {
            List<beProgramacionPicking> lista = new List<beProgramacionPicking>();
            SqlCommand cmd = new SqlCommand("uspProgramacionPickingListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beProgramacionPicking fila = new beProgramacionPicking();
                    fila.IdProgramacionPicking = drd.GetInt32(0);
                    fila.IdEmpleado = drd.GetInt32(1);
                    fila.Descripcion = drd.GetString(2);
                    fila.Fecha = drd.GetDateTime(3);
                    fila.Turno = drd.GetString(4);
                    fila.Responsable = drd.GetString(5);
                    fila.FechaFormateada = fila.Fecha.ToString("dd/MM/yyyy");

                    lista.Add(fila);
                }
                drd.Close();
            }
            return lista;
        }

        public beProgramacionPicking ListarxID(SqlConnection con, int id)
        {
            beProgramacionPicking fila = new beProgramacionPicking();
            SqlCommand cmd = new SqlCommand("uspProgramacionPickingListarxID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    fila.IdProgramacionPicking = drd.GetInt32(0);
                    fila.IdEmpleado = drd.GetInt32(1);
                    fila.Descripcion = drd.GetString(2);
                    fila.Fecha = drd.GetDateTime(3);
                    fila.Turno = drd.GetString(4);
                    fila.Responsable = drd.GetString(5);
                    fila.FechaFormateada = fila.Fecha.ToString("dd/MM/yyyy");

                }
                drd.Close();
            }
            return fila;
        }

        public List<beProgramacionPicking> ListarPickar(SqlConnection con)
        {
            List<beProgramacionPicking> lista = new List<beProgramacionPicking>();
            SqlCommand cmd = new SqlCommand("uspProgramacionPickingListarPickar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beProgramacionPicking fila = new beProgramacionPicking();
                    fila.Fecha = drd.GetDateTime(0);
                    fila.NumeroPedido = drd.GetString(1);
                    fila.IdSucursal = drd.GetInt32(2);
                    fila.Estado = drd.GetInt32(3);
                    fila.NombreSucursal = drd.GetString(4);
                    fila.DescripcionEstado = drd.GetString(5);
                    fila.FechaFormateada = fila.Fecha.ToString("dd/MM/yyyy");

                    lista.Add(fila);
                }
                drd.Close();
            }
            return lista;
        }

        public List<beProgramacionPicking> ListarPickarFiltro(SqlConnection con, String strNumeroPedido)
        {
            List<beProgramacionPicking> lista = new List<beProgramacionPicking>();
            SqlCommand cmd = new SqlCommand("uspProgramacionPickingListarPickarFiltro", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumeroPedido", strNumeroPedido);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beProgramacionPicking fila = new beProgramacionPicking();
                    fila.Fecha = drd.GetDateTime(0);
                    fila.NumeroPedido = drd.GetString(1);
                    fila.IdSucursal = drd.GetInt32(2);
                    fila.Estado = drd.GetInt32(3);
                    fila.NombreSucursal = drd.GetString(4);
                    fila.DescripcionEstado = drd.GetString(5);
                    fila.FechaFormateada = fila.Fecha.ToString("dd/MM/yyyy");

                    lista.Add(fila);
                }
                drd.Close();
            }
            return lista;
        }

        public Boolean Insertar(SqlConnection con, beProgramacionPicking obeProgramacionPicking)
        {
            SqlCommand cmd = new SqlCommand("uspProgramacionPickingInsertar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProgramacionPicking", obeProgramacionPicking.IdProgramacionPicking);
            cmd.Parameters.AddWithValue("@idEmpleado", obeProgramacionPicking.IdEmpleado);
            cmd.Parameters.AddWithValue("@descripcion", obeProgramacionPicking.Descripcion);
            cmd.Parameters.AddWithValue("@fecha", obeProgramacionPicking.Fecha);
            cmd.Parameters.AddWithValue("@turno", obeProgramacionPicking.Turno);
            cmd.Parameters.AddWithValue("@NumeroPedido", obeProgramacionPicking.NumeroPedido);

            cmd.ExecuteNonQuery();

            return true;
        }

        public beDetalleProgramacionPicking ListarDetallexID(SqlConnection con, int idProgramacionPicking, string numeroPedido, int idProducto)
        {
            beDetalleProgramacionPicking fila = new beDetalleProgramacionPicking();
            SqlCommand cmd = new SqlCommand("uspDetalleProgramacionPickingListarxID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProgramacionPicking", idProgramacionPicking);
            cmd.Parameters.AddWithValue("@numeroPedido", numeroPedido);
            cmd.Parameters.AddWithValue("@idProducto", idProducto);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    fila.IdProgramacionPicking = drd.GetInt32(0);
                    fila.NumeroPedido = drd.GetString(1);
                    fila.IdProducto = drd.GetInt32(2);
                    fila.NombreProducto = drd.GetString(3);
                    fila.CantidadPedido = drd.GetInt32(4);
                    fila.CantidadAtendida = drd.GetInt32(5);
                    fila.Saldo = drd.GetInt32(6);
                    fila.UnidadMedida = drd.GetString(7);
                    fila.Stock = drd.GetInt32(8);
                }
                drd.Close();
            }
            return fila;
        }

        public List<beDetalleProgramacionPicking> ListarDetallexPicking(SqlConnection con, int id)
        {
            List<beDetalleProgramacionPicking> lista = new List<beDetalleProgramacionPicking>();
            SqlCommand cmd = new SqlCommand("uspDetalleProgramacionPickingListarxPicking", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beDetalleProgramacionPicking fila = new beDetalleProgramacionPicking();
                    fila.IdProgramacionPicking = drd.GetInt32(0);
                    fila.NumeroPedido = drd.GetString(1);
                    fila.IdProducto = drd.GetInt32(2);
                    fila.IdUbicacion = drd.GetInt32(3);
                    fila.Descripcion = drd.GetString(4);
                    fila.CantidadPedido = drd.GetInt32(5);
                    fila.CantidadAtendida = drd.GetInt32(6);
                    fila.NombreProducto = drd.GetString(7);
                    lista.Add(fila);
                }
                drd.Close();
            }
            return lista;
        }

        public List<beDetalleProgramacionPicking> ListarDetallexPedido(SqlConnection con, String id)
        {
            List<beDetalleProgramacionPicking> lista = new List<beDetalleProgramacionPicking>();
            SqlCommand cmd = new SqlCommand("uspDetalleProgramacionPickingListarxPedido", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumeroPedido", id);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beDetalleProgramacionPicking fila = new beDetalleProgramacionPicking();
                    fila.IdProgramacionPicking = drd.GetInt32(0);
                    fila.NumeroPedido = drd.GetString(1);
                    fila.IdProducto = drd.GetInt32(2);
                    fila.NombreProducto = drd.GetString(3);
                    fila.CantidadPedido = drd.GetInt32(4);
                    fila.CantidadAtendida = drd.GetInt32(5);
                    fila.Saldo = drd.GetInt32(6);
                    fila.UnidadMedida = drd.GetString(7);

                    lista.Add(fila);
                }
                drd.Close();
            }
            return lista;
        }

        public Boolean InsertarDetalle(SqlConnection con, beDetalleProgramacionPicking obeDetalleProgramacionPicking)
        {
            SqlCommand cmd = new SqlCommand("uspDetalleProgramacionPickingInsertar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@idProgramacionPicking", obeDetalleProgramacionPicking.IdProgramacionPicking);
            cmd.Parameters.AddWithValue("@NumeroPedido", obeDetalleProgramacionPicking.NumeroPedido);
            cmd.Parameters.AddWithValue("@idProducto", obeDetalleProgramacionPicking.IdProducto);
            cmd.Parameters.AddWithValue("@idUbicacion", obeDetalleProgramacionPicking.IdUbicacion);
            cmd.Parameters.AddWithValue("@descripcion", obeDetalleProgramacionPicking.Descripcion);
            cmd.Parameters.AddWithValue("@cantidadPedido", obeDetalleProgramacionPicking.CantidadPedido);
            cmd.Parameters.AddWithValue("@cantidadAtendida", obeDetalleProgramacionPicking.CantidadAtendida);

            cmd.ExecuteNonQuery();

            return true;
        }

        public Boolean ActualizarDetalleCantidad(SqlConnection con, beDetalleProgramacionPicking obeDetalleProgramacionPicking)
        {
            SqlCommand cmd = new SqlCommand("uspDetalleProgramacionPickingActualizarCantidad", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idProgramacionPicking", obeDetalleProgramacionPicking.IdProgramacionPicking);
            cmd.Parameters.AddWithValue("@NumeroPedido", obeDetalleProgramacionPicking.NumeroPedido);
            cmd.Parameters.AddWithValue("@idProducto", obeDetalleProgramacionPicking.IdProducto);
            cmd.Parameters.AddWithValue("@cantidadAtendida", obeDetalleProgramacionPicking.CantidadAtendida);

            cmd.ExecuteNonQuery();

            return true;
        }
    }
}
