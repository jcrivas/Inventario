using System;
using System.Collections.Generic;
using io=System.IO;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Reflection;

namespace ByS.General.CodigoUsuario
{
    public class ucExportar
    {
        public enum Tipos
        {
            PorDefecto = 0,
            PorHoja = 1,
            PorArchivo = 2
        }

        public static void ListaATexto<T>(List<T> lista, string archivo, string separador)
        {
            PropertyInfo[] propiedades = lista[0].GetType().GetProperties();
            using (io.StreamWriter sw = new io.StreamWriter(archivo,false,Encoding.Default))
            {
                for (int i = 0; i < propiedades.Length - 1; i++)
                {
                    sw.Write(propiedades[i].Name);
                    sw.Write(separador);
                }
                sw.WriteLine(propiedades[propiedades.Length-1].Name);
                foreach (T obj in lista)
                {
                    for (int i = 0; i < propiedades.Length - 1; i++)
                    {
                        sw.Write(propiedades[i].GetValue(obj,null).ToString());
                        sw.Write(separador);
                    }
                    sw.WriteLine(propiedades[propiedades.Length - 1].GetValue(obj, null).ToString());
                }
            }
        }

        public static void TextoAExcel(string archivo, string hoja, bool eliminar = true)
        {
            string ruta = io.Path.GetDirectoryName(archivo);
            string nombre = io.Path.GetFileNameWithoutExtension(archivo);
            string archivoExcel = ruta + "\\" + nombre + ".xlsx";
            if(eliminar)
            {
                if(io.File.Exists(archivoExcel)) io.File.Delete(archivoExcel);
            }
            using(OleDbConnection con = new OleDbConnection
                ("provider=Microsoft.Ace.oledb.12.0;data source=" + ruta + ";extended properties=Text;"))
            {
                con.Open();
                OleDbCommand cmd = new OleDbCommand("Select * Into " + hoja + " In ''[Excel 12.0 xml;Database=" + archivoExcel + "]From " + nombre + "#TXT", con);
                cmd.ExecuteNonQuery();
            }
        }

        public static void ListaAExcel<T>(List<T> lista, string archivo, string separador,string hoja)
        {
            ListaATexto<T>(lista, archivo, separador);
            TextoAExcel(archivo, hoja, true);
        }

        public static string obtenerTipoContenido(string archivo)
        {
            string tipoArchivo = io.Path.GetExtension(archivo).ToLower();
            string tipo = "";
            if (tipoArchivo.Equals(".txt")) tipo = "text/plain";
            else
            {
                if (tipoArchivo.StartsWith(".xls")) tipo = "application/ms-excel";
                else
                {
                    if (tipoArchivo.StartsWith(".doc")) tipo = "application/vnd.ms-word";
                    else tipo = "text/html";
                }
            }
            return tipo;
        }
    }
}
