using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Configuration; //ConfigurationManager
using ByS.Inventario.Entities;
using ByS.Inventario.Data;

namespace ByS.Inventario.Logic
{
    public class brSucursal : brGeneral
    {
        public List<beSucursal> Listar()
        {
            List<beSucursal> lista = new List<beSucursal>();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    daSucursal odaSucursal = new daSucursal();
                    lista = odaSucursal.Listar(con);
                }
                catch (Exception ex)
                {
                    GrabarLog(ex);
                }
            }
            return lista;
        }
    }
}
