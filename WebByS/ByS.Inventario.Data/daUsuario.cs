using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities; //beCliente

namespace ByS.Inventario.Data
{
    public class daUsuario
    {
        public beEmpleado ValidarLogin(SqlConnection con, string usuario, string clave)
        {
            beEmpleado obeEmpleado = null;
            SqlCommand cmd = new SqlCommand("uspEmpleadoValidarLogin", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Usuario", usuario);
            cmd.Parameters.AddWithValue("@Clave", clave);
            SqlDataReader drd = cmd.ExecuteReader(CommandBehavior.SingleRow);
            if (drd != null)
            {
                if (drd.HasRows)
                {
                    drd.Read();
                    obeEmpleado = new beEmpleado();
                    obeEmpleado.IdEmpleado = drd.GetInt32(0);
                    obeEmpleado.IdPersona = drd.GetInt32(1);
                    obeEmpleado.IdCargo = drd.GetInt32(2);
                    obeEmpleado.IdArea = drd.GetInt32(3);
                    obeEmpleado.Nombre = drd.GetString(4);
                    obeEmpleado.Apellido = drd.GetString(5);
                    obeEmpleado.Login = drd.GetString(13);
                    obeEmpleado.Password = drd.GetString(14);
                }
                drd.Close();
            }
            return obeEmpleado;
        }
    }
}
