using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brProgramacionPicking : brGeneral
    {
        public beProgramacionPicking ListarxID(int id)
        {
            beProgramacionPicking fila = new beProgramacionPicking();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odadaProgramacionPicking = new daProgramacionPicking();
                    fila = odadaProgramacionPicking.ListarxID(con, id);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return fila;
        }

        public List<beProgramacionPicking> Listar()
        {
            List<beProgramacionPicking> lista = new List<beProgramacionPicking>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odadaProgramacionPicking = new daProgramacionPicking();
                    lista = odadaProgramacionPicking.Listar(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public List<beProgramacionPicking> ListarPickar()
        {
            List<beProgramacionPicking> lista = new List<beProgramacionPicking>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odadaProgramacionPicking = new daProgramacionPicking();
                    lista = odadaProgramacionPicking.ListarPickar(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public List<beProgramacionPicking> ListarPickarFiltro(String strNumeroPedido)
        {
            List<beProgramacionPicking> lista = new List<beProgramacionPicking>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odadaProgramacionPicking = new daProgramacionPicking();
                    lista = odadaProgramacionPicking.ListarPickarFiltro(con, strNumeroPedido);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public Boolean Insertar(beProgramacionPicking obeProgramacionPicking)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odaProgramacionPicking = new daProgramacionPicking();
                    odaProgramacionPicking.Insertar(con, obeProgramacionPicking);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }

        public beDetalleProgramacionPicking ListarDetallexID(int idProgramacionPicking, string numeroPedido, int idProducto)
        {
            beDetalleProgramacionPicking obeDetalleProgramacionPicking = new beDetalleProgramacionPicking();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odadaProgramacionPicking = new daProgramacionPicking();
                    obeDetalleProgramacionPicking = odadaProgramacionPicking.ListarDetallexID(con, idProgramacionPicking, numeroPedido, idProducto);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return obeDetalleProgramacionPicking;
        }

        public List<beDetalleProgramacionPicking> ListarDetallexPicking(int id)
        {
            List<beDetalleProgramacionPicking> lista = new List<beDetalleProgramacionPicking>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odadaProgramacionPicking = new daProgramacionPicking();
                    lista = odadaProgramacionPicking.ListarDetallexPicking(con, id);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public List<beDetalleProgramacionPicking> ListarDetallexPedido(String id)
        {
            List<beDetalleProgramacionPicking> lista = new List<beDetalleProgramacionPicking>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odadaProgramacionPicking = new daProgramacionPicking();
                    lista = odadaProgramacionPicking.ListarDetallexPedido(con, id);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public Boolean InsertarDetalle(beDetalleProgramacionPicking obeDetalleProgramacionPicking)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odaProgramacionPicking = new daProgramacionPicking();
                    odaProgramacionPicking.InsertarDetalle(con, obeDetalleProgramacionPicking);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }

        public Boolean ActualizarDetalleCantidad(beDetalleProgramacionPicking obeDetalleProgramacionPicking)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionPicking odaProgramacionPicking = new daProgramacionPicking();
                    odaProgramacionPicking.ActualizarDetalleCantidad(con, obeDetalleProgramacionPicking);
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
