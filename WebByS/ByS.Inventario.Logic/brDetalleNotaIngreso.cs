using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brDetalleNotaIngreso : brGeneral
    {
        public List<beDetalleNotaIngreso> ListarxNota(int idNota)
        {
            List<beDetalleNotaIngreso> lista = new List<beDetalleNotaIngreso>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDetalleNotaIngreso odaDetalleNotaIngreso = new daDetalleNotaIngreso();
                    lista = odaDetalleNotaIngreso.ListarxNota(con, idNota);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public beDetalleNotaIngreso ListarxNotaProducto(int idNota, int idProducto)
        {
            beDetalleNotaIngreso obeDetalleNotaIngreso = new beDetalleNotaIngreso();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDetalleNotaIngreso odaDetalleNotaIngreso = new daDetalleNotaIngreso();
                    obeDetalleNotaIngreso = odaDetalleNotaIngreso.ListarxNotaProducto(con, idNota, idProducto);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return obeDetalleNotaIngreso;
        }

        public Boolean ActualizarCantidad(beDetalleNotaIngreso obeDetalleNotaIngreso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDetalleNotaIngreso odaDetalleNotaIngreso = new daDetalleNotaIngreso();
                    odaDetalleNotaIngreso.ActualizarCantidad(con, obeDetalleNotaIngreso);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
                
            }
        }

        public Boolean Insertar(beDetalleNotaIngreso obeDetalleNotaIngreso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDetalleNotaIngreso odaDetalleNotaIngreso = new daDetalleNotaIngreso();
                    odaDetalleNotaIngreso.Insertar(con, obeDetalleNotaIngreso);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }

            }
        }

        public void EliminarProducto(beDetalleNotaIngreso obeDetalleNotaIngreso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daDetalleNotaIngreso odaDetalleNotaIngreso = new daDetalleNotaIngreso();
                    odaDetalleNotaIngreso.EliminarProducto(con, obeDetalleNotaIngreso);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
        }
    }
}
