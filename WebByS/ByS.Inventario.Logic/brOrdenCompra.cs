using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brOrdenCompra : brGeneral
    {
        #region Cabecera
        public List<beOrdenCompra> ListarxEstado(String pstrEstado)
        {
            List<beOrdenCompra> lista = new List<beOrdenCompra>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daOrdenCompra odaOrdenCompra = new daOrdenCompra();
                    lista = odaOrdenCompra.ListarxEstado(con, pstrEstado);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public List<beOrdenCompra> ListarxAlmacenar()
        {
            List<beOrdenCompra> lista = new List<beOrdenCompra>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daOrdenCompra odaOrdenCompra = new daOrdenCompra();
                    lista = odaOrdenCompra.ListarxAlmacenar(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public List<beOrdenCompra> FiltrarxAlmacenar(String pstrFechaInicio, String pstrFechaFin, string pstrTipo, string pstrNumero)
        {
            List<beOrdenCompra> lista = new List<beOrdenCompra>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daOrdenCompra odaOrdenCompra = new daOrdenCompra();
                    lista = odaOrdenCompra.FiltrarxAlmacenar(con, pstrFechaInicio, pstrFechaFin, pstrTipo, pstrNumero);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public Boolean ActualizarEstado(beOrdenCompra obeOrdenCompra)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daOrdenCompra odaOrdenCompra = new daOrdenCompra();
                    odaOrdenCompra.ActualizarEstado(con, obeOrdenCompra);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }

        #endregion

        #region Detalle
        public List<beDetalleOrdenCompra> ListarDetallexOrden(String pstrOrden)
        {
            List<beDetalleOrdenCompra> lista = new List<beDetalleOrdenCompra>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daOrdenCompra odaOrdenCompra = new daOrdenCompra();
                    lista = odaOrdenCompra.ListarDetallexOrden(con, pstrOrden);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }
        #endregion
    }
}
