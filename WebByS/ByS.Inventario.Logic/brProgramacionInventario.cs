using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brProgramacionInventario : brGeneral
    {
        public List<beProgramacionInventario> Listar()
        {
            List<beProgramacionInventario> lista = new List<beProgramacionInventario>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionInventario odaProgramacionInventario = new daProgramacionInventario();
                    lista = odaProgramacionInventario.Listar(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public beProgramacionInventario ListarxID(int intProgramacionInventario)
        {
            beProgramacionInventario obeProgramacionInventario = new beProgramacionInventario();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionInventario odaProgramacionInventario = new daProgramacionInventario();
                    obeProgramacionInventario = odaProgramacionInventario.ListarxID(con, intProgramacionInventario);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return obeProgramacionInventario;
        }

        public List<beProgramacionInventario> Filtrar(String pstrDescripcion, int intSucursal)
        {
            List<beProgramacionInventario> lista = new List<beProgramacionInventario>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionInventario odaProgramacionInventario = new daProgramacionInventario();
                    lista = odaProgramacionInventario.Filtrar(con, pstrDescripcion, intSucursal);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }

        public Boolean Insertar(beProgramacionInventario obeProgramacionInventario)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionInventario odaProgramacionInventario = new daProgramacionInventario();
                    odaProgramacionInventario.Insertar(con, obeProgramacionInventario);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }

        public Boolean Actualizar(beProgramacionInventario obeProgramacionInventario)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionInventario odaProgramacionInventario = new daProgramacionInventario();
                    odaProgramacionInventario.Actualizar(con, obeProgramacionInventario);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }

        public void EliminarRegistro(int intProgramacionInventario)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daProgramacionInventario odaProgramacionInventario = new daProgramacionInventario();
                    odaProgramacionInventario.EliminarRegistro(con, intProgramacionInventario);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
        }
    }
}
