using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brPedido : brGeneral
    {
        public List<bePedido> ListarPendientePicking()
        {
            List<bePedido> lista = new List<bePedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPedido odaPedido = new daPedido();
                    lista = odaPedido.ListarxEstado(con,0);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public bePedido ListarPickarxPedido(String strNumeroPedido)
        {
            bePedido obePedido = new bePedido();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPedido odaPedido = new daPedido();
                    obePedido = odaPedido.ListarPickarxPedido(con, strNumeroPedido);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return obePedido;
        }

        public List<bePedido> Filtrar(String strPedidoInicio, String strPedidoFin, int intSucursal)
        {
            List<bePedido> lista = new List<bePedido>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPedido odaPedido = new daPedido();
                    lista = odaPedido.Filtrar(con, strPedidoInicio, strPedidoFin, intSucursal);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public Boolean ActualizarEstado(bePedido obePedido)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daPedido odaPedido = new daPedido();
                    odaPedido.ActualizarEstado(con, obePedido);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }
    }
}
