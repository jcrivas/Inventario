using System;
using System.Data; //CommandType
using System.Data.SqlClient; //SqlConnection, SqlCommand, SqlDataReader
using System.Collections.Generic; //List
using ByS.Inventario.Entities;

namespace ByS.Inventario.Data
{
    public class daKardex
    {
        public Boolean Insertar(SqlConnection con, beKardex obeKardex)
        {
            SqlCommand cmd = new SqlCommand("uspKardexInsertar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NumeroKardex", obeKardex.NumeroKardex);
            cmd.Parameters.AddWithValue("@IdProducto", obeKardex.IdProducto);
            cmd.Parameters.AddWithValue("@IdAlmacen", obeKardex.IdAlmacen);
            cmd.Parameters.AddWithValue("@Observaciones", obeKardex.Observaciones);
            cmd.Parameters.AddWithValue("@SaldoActual", obeKardex.SaldoActual);
            cmd.Parameters.AddWithValue("@IdNotaIngreso", obeKardex.IdNotaIngreso);
            cmd.Parameters.AddWithValue("@IdNotaSalida", obeKardex.IdNotaSalida);
            cmd.Parameters.AddWithValue("@Fecha", obeKardex.Fecha);
            cmd.Parameters.AddWithValue("@Ingreso", obeKardex.Ingreso);
            cmd.Parameters.AddWithValue("@Salidas", obeKardex.Salidas);
            cmd.Parameters.AddWithValue("@CodigoCompra", obeKardex.CodigoCompra);
            cmd.Parameters.AddWithValue("@Cantidad", obeKardex.Cantidad);
            cmd.Parameters.AddWithValue("@Costo", obeKardex.Costo);
            
            cmd.ExecuteNonQuery();

            return true;
        }

        public Boolean InsertarDetalle(SqlConnection con, beDetalleKardex obeDetalleKardex)
        {
            SqlCommand cmd = new SqlCommand("uspDetalleKardexInsertar", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@NumeroKardex", obeDetalleKardex.NumeroKardex);
            cmd.Parameters.AddWithValue("@NumeroDocumento", obeDetalleKardex.NumeroDocumento);
            cmd.Parameters.AddWithValue("@TipodeMovimiento", obeDetalleKardex.TipodeMovimiento);
            cmd.Parameters.AddWithValue("@NumeroNotaIngreso", obeDetalleKardex.NumeroNotaIngreso);
            cmd.Parameters.AddWithValue("@NumeroSalida", obeDetalleKardex.NumeroSalida);
            cmd.Parameters.AddWithValue("@Fecha", obeDetalleKardex.Fecha);
            cmd.Parameters.AddWithValue("@Cantidad", obeDetalleKardex.Cantidad);

            cmd.ExecuteNonQuery();

            return true;
        }
    }
}
