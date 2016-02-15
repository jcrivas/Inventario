using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities;

namespace ByS.Inventario.Data
{
    public class daEmpleado
    {
        public List<beEmpleadoRH> Listar(SqlConnection con)
        {
            List<beEmpleadoRH> lista = new List<beEmpleadoRH>();
            SqlCommand cmd = new SqlCommand("uspEmpleadoListar", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleResult);
            if (drd != null)
            {
                while (drd.Read())
                {
                    beEmpleadoRH obeEmpleadoRH = new beEmpleadoRH();
                    obeEmpleadoRH.codEmpleado = drd.GetInt32(0);
                    obeEmpleadoRH.desNombre = drd.GetString(4);
                    obeEmpleadoRH.desApellido = drd.GetString(5);
                    obeEmpleadoRH.desLogin = drd.GetString(13);
                    obeEmpleadoRH.nombreCompleto = obeEmpleadoRH.desNombre + " " + obeEmpleadoRH.desApellido;
                    lista.Add(obeEmpleadoRH);
                }
                drd.Close();
            }
            return lista;
        }
    }
}
