using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Loteria.Datos
{
    internal class Conexion
    {
        public static string DB = "Base";
        public static string CN = "Data source = .; Initial Catalog= "+DB+"; Integrated Security= False ";
        public static SqlConnection Conectar = new SqlConnection(CN);

        public static void Abrir()
        {
            if (Conectar.State == ConnectionState.Closed)
            {
                Conectar.Open();
            }
        }

        public static void Cerrar()
        {
            if (Conectar.State == ConnectionState.Open)
            {
                Conectar.Close();
            }
        }




    }
}
