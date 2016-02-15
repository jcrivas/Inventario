using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities;

namespace ByS.Inventario.Data
{
    public class daPedido
    {
        public List<bePedido> ListarxEstado(SqlConnection con, int intEstado)
        {
            List<bePedido> lista = new List<bePedido>();
            SqlCommand cmd = new SqlCommand("uspPedidoListarxEstado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estado", intEstado);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    bePedido obeProducto = new bePedido();

                    obeProducto.NumeroPedido = drd.GetString(0);
                    obeProducto.Fecha = drd.GetDateTime(1);
                    obeProducto.IdSucursal = drd.GetInt32(2);
                    obeProducto.Estado = drd.GetInt32(3);
                    obeProducto.FechaRegistro = drd.GetDateTime(4);
                    obeProducto.UsuarioRegistro = drd.GetString(5);
                    obeProducto.UsuarioAsignado = drd.GetString(6);
                    obeProducto.IdProducto = drd.GetInt32(7);
                    obeProducto.NombreSucursal = drd.GetString(8);
                    obeProducto.FechaFormateada = obeProducto.FechaRegistro.ToString("dd/MM/yyyy");
                    obeProducto.Seleccionado = false;
                    lista.Add(obeProducto);
                }
                drd.Close();
            }
            return lista;
        }

        public bePedido ListarPickarxPedido(SqlConnection con, String strNumeroPedido)
        {
            bePedido obeProducto = new bePedido();
            SqlCommand cmd = new SqlCommand("uspPedidoListarPickarxPedido", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NumeroPedido", strNumeroPedido);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    obeProducto.NumeroPedido = drd.GetString(0);
                    obeProducto.IdSucursal = drd.GetInt32(1);
                    obeProducto.NombreSucursal = drd.GetString(2);
                    obeProducto.Direccion = drd.GetString(3);
                    obeProducto.Fecha = drd.GetDateTime(4);
                    obeProducto.FechaFormateada = obeProducto.Fecha.ToString("dd/MM/yyyy");
                }
                drd.Close();
            }
            return obeProducto;
        }

        public List<bePedido> Filtrar(SqlConnection con, String strPedidoInicio, String strPedidoFin, int intSucursal)
        {
            List<bePedido> lista = new List<bePedido>();
            SqlCommand cmd = new SqlCommand("uspPedidoFiltrar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PedidoInicio", strPedidoInicio);
            cmd.Parameters.AddWithValue("@PedidoFin", strPedidoFin);
            cmd.Parameters.AddWithValue("@IdSucursal", intSucursal);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    bePedido obeProducto = new bePedido();

                    obeProducto.NumeroPedido = drd.GetString(0);
                    obeProducto.Fecha = drd.GetDateTime(1);
                    obeProducto.IdSucursal = drd.GetInt32(2);
                    obeProducto.Estado = drd.GetInt32(3);
                    obeProducto.FechaRegistro = drd.GetDateTime(4);
                    obeProducto.UsuarioRegistro = drd.GetString(5);
                    obeProducto.UsuarioAsignado = drd.GetString(6);
                    obeProducto.IdProducto = drd.GetInt32(7);
                    obeProducto.NombreSucursal = drd.GetString(8);
                    obeProducto.FechaFormateada = obeProducto.FechaRegistro.ToString("dd/MM/yyyy");
                    obeProducto.Seleccionado = false;
                    lista.Add(obeProducto);
                }
                drd.Close();
            }
            return lista;
        }

        public Boolean ActualizarEstado(SqlConnection con, bePedido obePedido)
        {
            SqlCommand cmd = new SqlCommand("uspPedidoActualizarEstado", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NumeroPedido", obePedido.NumeroPedido);
            cmd.Parameters.AddWithValue("@Estado", obePedido.Estado);
            cmd.ExecuteNonQuery();

            return true;
        }
    }
}
