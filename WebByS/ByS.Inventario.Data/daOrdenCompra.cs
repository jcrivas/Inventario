using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities; 

namespace ByS.Inventario.Data
{
    public class daOrdenCompra
    {
        #region Cabecera
        public List<beOrdenCompra> ListarxEstado(SqlConnection con, String pstrEstado)
        {
            List<beOrdenCompra> lista = new List<beOrdenCompra>();
            SqlCommand cmd = new SqlCommand("uspOrdenCompraListarxEstado", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@estado", pstrEstado);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beOrdenCompra obeOrdenCompra = new beOrdenCompra();
                    obeOrdenCompra.nOrdenCompra = drd.GetString(0);
                    obeOrdenCompra.Fecha = drd.GetDateTime(1);
                    obeOrdenCompra.Transportista = drd.GetString(2);
                    obeOrdenCompra.DireccionEntrega = drd.GetString(3);
                    obeOrdenCompra.IdProducto = drd.GetInt32(4);
                    obeOrdenCompra.IdProveedor = drd.GetInt32(5);
                    obeOrdenCompra.Estado = drd.GetString(6);
                    lista.Add(obeOrdenCompra);
                }
                drd.Close();
            }
            return lista;
        }

        public List<beOrdenCompra> ListarxAlmacenar(SqlConnection con)
        {
            List<beOrdenCompra> lista = new List<beOrdenCompra>();
            SqlCommand cmd = new SqlCommand("uspOrdenCompraListarxAlmacenar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beOrdenCompra obeOrdenCompra = new beOrdenCompra();
                    obeOrdenCompra.Fecha = drd.GetDateTime(0);
                    obeOrdenCompra.Tipo = drd.GetString(1);
                    obeOrdenCompra.nOrdenCompra = drd.GetString(2);
                    obeOrdenCompra.Estado = drd.GetString(3);
                    obeOrdenCompra.Sigla = drd.GetString(4);
                    obeOrdenCompra.EstadoDescripcion = drd.GetString(5);
                    obeOrdenCompra.FechaFormateada = obeOrdenCompra.Fecha.ToString("dd/MM/yyyy");
                    lista.Add(obeOrdenCompra);
                }
                drd.Close();
            }
            return lista;
        }

        public List<beOrdenCompra> FiltrarxAlmacenar(SqlConnection con, String pstrFechaInicio, String pstrFechaFin, string pstrTipo, string pstrNumero)
        {
            List<beOrdenCompra> lista = new List<beOrdenCompra>();
            SqlCommand cmd = new SqlCommand("uspOrdenCompraFiltrarxAlmacenar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FechaInicio", pstrFechaInicio);
            cmd.Parameters.AddWithValue("@FechaFin", pstrFechaFin);
            cmd.Parameters.AddWithValue("@Tipo", pstrTipo);
            cmd.Parameters.AddWithValue("@nOrdenCompra", pstrNumero);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beOrdenCompra obeOrdenCompra = new beOrdenCompra();
                    obeOrdenCompra.Fecha = drd.GetDateTime(0);
                    obeOrdenCompra.Tipo = drd.GetString(1);
                    obeOrdenCompra.nOrdenCompra = drd.GetString(2);
                    obeOrdenCompra.Estado = drd.GetString(3);
                    obeOrdenCompra.Sigla = drd.GetString(4);
                    obeOrdenCompra.EstadoDescripcion = drd.GetString(5);
                    obeOrdenCompra.FechaFormateada = obeOrdenCompra.Fecha.ToString("dd/MM/yyyy");
                    lista.Add(obeOrdenCompra);
                }
                drd.Close();
            }
            return lista;
        }

        public Boolean ActualizarEstado(SqlConnection con, beOrdenCompra obeOrdenCompra)
        {
            SqlCommand cmd = new SqlCommand("uspOrdenCompraActualizarEstado", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nOrdenCompra", obeOrdenCompra.nOrdenCompra);
            cmd.Parameters.AddWithValue("@Estado", obeOrdenCompra.Estado);
            cmd.ExecuteNonQuery();

            return true;
        }
        #endregion

        #region Detalle
        public List<beDetalleOrdenCompra> ListarDetallexOrden(SqlConnection con, String pstrOrden)
        {
            List<beDetalleOrdenCompra> lista = new List<beDetalleOrdenCompra>();
            SqlCommand cmd = new SqlCommand("uspDetalleOrdenCompraListarxOrden", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nOrdenCompra", pstrOrden);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beDetalleOrdenCompra obeDetalleOrdenCompra = new beDetalleOrdenCompra();
                    obeDetalleOrdenCompra.nOrdenCompra = drd.GetString(0);
                    obeDetalleOrdenCompra.IdProducto = drd.GetInt32(1);
                    obeDetalleOrdenCompra.NombreProducto = drd.GetString(2);
                    obeDetalleOrdenCompra.Cantidad = drd.GetDecimal(3);
                    obeDetalleOrdenCompra.CantidadInternar = Decimal.Round(obeDetalleOrdenCompra.Cantidad);
                    lista.Add(obeDetalleOrdenCompra);
                }
                drd.Close();
            }
            return lista;
        }
        #endregion
    }
}
