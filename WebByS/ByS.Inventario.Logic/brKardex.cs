using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brKardex : brGeneral
    {
        public Boolean Insertar(beKardex obeKardex)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daKardex odaKardex = new daKardex();
                    odaKardex.Insertar(con, obeKardex);
                    return true;
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                    return false;
                }
            }
        }

        public Boolean InsertarDetalle(beDetalleKardex beDetalleKardex)
        {
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daKardex odaKardex = new daKardex();
                    odaKardex.InsertarDetalle(con, beDetalleKardex);
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
