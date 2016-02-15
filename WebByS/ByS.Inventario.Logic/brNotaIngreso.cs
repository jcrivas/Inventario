using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brNotaIngreso : brGeneral
    {
        public List<beNotaIngreso> Listar()
        {
            List<beNotaIngreso> lista = new List<beNotaIngreso>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daNotaIngreso odaNotaIngreso = new daNotaIngreso();
                    lista = odaNotaIngreso.Listar(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public beNotaIngreso ListarxID(int id)
        {
            beNotaIngreso obeNotaIngreso = new beNotaIngreso();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daNotaIngreso odaNotaIngreso = new daNotaIngreso();
                    obeNotaIngreso = odaNotaIngreso.ListarxID(con, id);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return obeNotaIngreso;
        }

        public List<beNotaIngreso> ListarxEstado(String pstrEstado)
        {
            List<beNotaIngreso> lista = new List<beNotaIngreso>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daNotaIngreso odaNotaIngreso = new daNotaIngreso();
                    lista = odaNotaIngreso.ListarxEstado(con,pstrEstado);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public List<beNotaIngreso> Filtrar(String pstrFechaInicio, String pstrFechaFin, int pintNumero, int pintProveedor)
        {
            List<beNotaIngreso> lista = new List<beNotaIngreso>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daNotaIngreso odaNotaIngreso = new daNotaIngreso();
                    lista = odaNotaIngreso.Filtrar(con, pstrFechaInicio, pstrFechaFin, pintNumero, pintProveedor);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public Boolean ActualizarEstado(beNotaIngreso obeNotaIngreso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daNotaIngreso odaNotaIngreso = new daNotaIngreso();
                    odaNotaIngreso.ActualizarEstado(con, obeNotaIngreso);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }

        public Boolean Actualizar(beNotaIngreso obeNotaIngreso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daNotaIngreso odaNotaIngreso = new daNotaIngreso();
                    odaNotaIngreso.Actualizar(con, obeNotaIngreso);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }

        public Boolean Insertar(beNotaIngreso obeNotaIngreso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daNotaIngreso odaNotaIngreso = new daNotaIngreso();
                    odaNotaIngreso.Insertar(con, obeNotaIngreso);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }

        public void EliminarRegistro(int intNumeroNotaIngreso)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daNotaIngreso odaNotaIngreso = new daNotaIngreso();
                    odaNotaIngreso.EliminarRegistro(con, intNumeroNotaIngreso);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
        }
    }
}
