using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities; 

namespace ByS.Inventario.Data
{
    public class daNotaIngreso
    {
        public List<beNotaIngreso> Listar(SqlConnection con)
        {
            List<beNotaIngreso> lista = new List<beNotaIngreso>();
            SqlCommand cmd = new SqlCommand("uspNotaIngresoListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beNotaIngreso obeNotaIngreso = new beNotaIngreso();
                    obeNotaIngreso.NumeroNotaIngreso = drd.GetInt32(0);
                    obeNotaIngreso.Fecha = drd.GetDateTime(1);
                    obeNotaIngreso.NumeroOrdenCompra = drd.GetString(2);
                    obeNotaIngreso.IdEmpleado = drd.GetInt32(3);
                    obeNotaIngreso.UsuarioRecibo = drd.GetString(4);
                    obeNotaIngreso.IdAlmacen = drd.GetInt32(5);
                    obeNotaIngreso.GuiaRemision = drd.GetString(6);
                    obeNotaIngreso.Observaciones = drd.GetString(7);
                    obeNotaIngreso.EstadoNotaIngreso = drd.GetString(8);
                    obeNotaIngreso.IdProveedor = drd.GetInt32(9);
                    obeNotaIngreso.NombreProveedor = drd.GetString(10);
                    obeNotaIngreso.EstadoDescripcion = drd.GetString(11);
                    obeNotaIngreso.FechaFormateada = obeNotaIngreso.Fecha.ToString("dd/MM/yyyy");
                    lista.Add(obeNotaIngreso);
                }
                drd.Close();
            }
            return lista;
        }

        public beNotaIngreso ListarxID(SqlConnection con, int id)
        {
            beNotaIngreso obeNotaIngreso = new beNotaIngreso();
            SqlCommand cmd = new SqlCommand("uspNotaIngresoListarxID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (drd != null)
            {
                while (drd.Read())
                {
                    obeNotaIngreso.NumeroNotaIngreso = drd.GetInt32(0);
                    obeNotaIngreso.Fecha = drd.GetDateTime(1);
                    obeNotaIngreso.NumeroOrdenCompra = drd.GetString(2);
                    obeNotaIngreso.IdEmpleado = drd.GetInt32(3);
                    obeNotaIngreso.UsuarioRecibo = drd.GetString(4);
                    obeNotaIngreso.IdAlmacen = drd.GetInt32(5);
                    obeNotaIngreso.GuiaRemision = drd.GetString(6);
                    obeNotaIngreso.Observaciones = drd.GetString(7);
                    obeNotaIngreso.EstadoNotaIngreso = drd.GetString(8);
                    obeNotaIngreso.IdProveedor = drd.GetInt32(9);
                    obeNotaIngreso.NombreAlmacen = drd.GetString(10);
                    obeNotaIngreso.FechaFormateada = obeNotaIngreso.Fecha.ToString("dd/MM/yyyy");
                }
                drd.Close();
            }
            return obeNotaIngreso;
        }

        public List<beNotaIngreso> ListarxEstado(SqlConnection con, String pstrEstado)
        {
            List<beNotaIngreso> lista = new List<beNotaIngreso>();
            SqlCommand cmd = new SqlCommand("uspNotaIngresoListarxEstado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estado", pstrEstado);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beNotaIngreso obeNotaIngreso = new beNotaIngreso();
                    obeNotaIngreso.NumeroNotaIngreso = drd.GetInt32(0);
                    obeNotaIngreso.Fecha = drd.GetDateTime(1);
                    obeNotaIngreso.NumeroOrdenCompra = drd.GetString(2);
                    obeNotaIngreso.IdEmpleado = drd.GetInt32(3);
                    obeNotaIngreso.UsuarioRecibo = drd.GetString(4);
                    obeNotaIngreso.IdAlmacen = drd.GetInt32(5);
                    obeNotaIngreso.GuiaRemision = drd.GetString(6);
                    obeNotaIngreso.Observaciones = drd.GetString(7);
                    obeNotaIngreso.EstadoNotaIngreso = drd.GetString(8);
                    obeNotaIngreso.IdProveedor = drd.GetInt32(9);
                    obeNotaIngreso.NombreAlmacen = drd.GetString(10);
                    obeNotaIngreso.EstadoDescripcion = drd.GetString(11);
                    obeNotaIngreso.FechaFormateada = obeNotaIngreso.Fecha.ToString("dd/MM/yyyy");
                    lista.Add(obeNotaIngreso);
                }
                drd.Close();
            }
            return lista;
        }

        public List<beNotaIngreso> Filtrar(SqlConnection con, String pstrFechaInicio, String pstrFechaFin, int pintNumero, int pintProveedor)
        {
            List<beNotaIngreso> lista = new List<beNotaIngreso>();
            SqlCommand cmd = new SqlCommand("uspNotaIngresoFiltrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FechaInicio", pstrFechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", pstrFechaFin);
            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", pintNumero);
            cmd.Parameters.AddWithValue("@IdProveedor", pintProveedor);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beNotaIngreso obeNotaIngreso = new beNotaIngreso();
                    obeNotaIngreso.NumeroNotaIngreso = drd.GetInt32(0);
                    obeNotaIngreso.Fecha = drd.GetDateTime(1);
                    obeNotaIngreso.NumeroOrdenCompra = drd.GetString(2);
                    obeNotaIngreso.IdEmpleado = drd.GetInt32(3);
                    obeNotaIngreso.UsuarioRecibo = drd.GetString(4);
                    obeNotaIngreso.IdAlmacen = drd.GetInt32(5);
                    obeNotaIngreso.GuiaRemision = drd.GetString(6);
                    obeNotaIngreso.Observaciones = drd.GetString(7);
                    obeNotaIngreso.EstadoNotaIngreso = drd.GetString(8);
                    obeNotaIngreso.IdProveedor = drd.GetInt32(9);
                    obeNotaIngreso.NombreProveedor = drd.GetString(10);
                    obeNotaIngreso.EstadoDescripcion = drd.GetString(11);
                    obeNotaIngreso.FechaFormateada = obeNotaIngreso.Fecha.ToString("dd/MM/yyyy");
                    lista.Add(obeNotaIngreso);
                }
                drd.Close();
            }
            return lista;
        }

        public Boolean ActualizarEstado(SqlConnection con, beNotaIngreso obeNotaIngreso)
        {
            SqlCommand cmd = new SqlCommand("uspNotaIngresoActualizarEstado", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", obeNotaIngreso.NumeroNotaIngreso);
            cmd.Parameters.AddWithValue("@EstadoNotaIngreso", obeNotaIngreso.EstadoNotaIngreso);
            cmd.ExecuteNonQuery();

            return true;
        }

        public Boolean Actualizar(SqlConnection con, beNotaIngreso obeNotaIngreso)
        {
            SqlCommand cmd = new SqlCommand("uspNotaIngresoActualizar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", obeNotaIngreso.NumeroNotaIngreso);
            cmd.Parameters.AddWithValue("@Fecha", obeNotaIngreso.Fecha);
            cmd.Parameters.AddWithValue("@NumeroOrdenCompra", obeNotaIngreso.NumeroOrdenCompra);
            cmd.Parameters.AddWithValue("@IdEmpleado", obeNotaIngreso.IdEmpleado);
            //cmd.Parameters.AddWithValue("@UsuarioRecibo", obeNotaIngreso.UsuarioRecibo);
            cmd.Parameters.AddWithValue("@IdAlmacen", obeNotaIngreso.IdAlmacen);
            cmd.Parameters.AddWithValue("@GuiaRemision", obeNotaIngreso.GuiaRemision);
            cmd.Parameters.AddWithValue("@Observaciones", obeNotaIngreso.Observaciones);
            cmd.Parameters.AddWithValue("@EstadoNotaIngreso", obeNotaIngreso.EstadoNotaIngreso);
            cmd.Parameters.AddWithValue("@IdProveedor", obeNotaIngreso.IdProveedor);
            cmd.ExecuteNonQuery();
            
            return true;
        }

        public Boolean Insertar(SqlConnection con, beNotaIngreso obeNotaIngreso)
        {
            SqlCommand cmd = new SqlCommand("uspNotaIngresoInsertar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", obeNotaIngreso.NumeroNotaIngreso);
            cmd.Parameters.AddWithValue("@Fecha", obeNotaIngreso.Fecha);
            cmd.Parameters.AddWithValue("@NumeroOrdenCompra", obeNotaIngreso.NumeroOrdenCompra);
            cmd.Parameters.AddWithValue("@IdEmpleado", obeNotaIngreso.IdEmpleado);
            //cmd.Parameters.AddWithValue("@UsuarioRecibo", obeNotaIngreso.UsuarioRecibo);
            cmd.Parameters.AddWithValue("@IdAlmacen", obeNotaIngreso.IdAlmacen);
            cmd.Parameters.AddWithValue("@GuiaRemision", obeNotaIngreso.GuiaRemision);
            cmd.Parameters.AddWithValue("@Observaciones", obeNotaIngreso.Observaciones);
            cmd.Parameters.AddWithValue("@EstadoNotaIngreso", obeNotaIngreso.EstadoNotaIngreso);
            cmd.Parameters.AddWithValue("@IdProveedor", obeNotaIngreso.IdProveedor);
            obeNotaIngreso.NumeroNotaIngreso = (int)cmd.ExecuteScalar();

            return true;
        }

        public void EliminarRegistro(SqlConnection con, int intNumeroNotaIngreso)
        {
            List<beNotaIngreso> lista = new List<beNotaIngreso>();
            SqlCommand cmd = new SqlCommand("uspNotaIngresoEliminarxId", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", intNumeroNotaIngreso);
            cmd.ExecuteNonQuery();
        }
    }
}
