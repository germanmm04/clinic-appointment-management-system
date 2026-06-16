using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Practica
{
    public class BaseDatos
    {
        public static SqlConnection ObtenerConexion() //Método para conectarse a la base de datos
        {
            SqlConnection conexion = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=CLINIPET;Integrated Security=True");
            conexion.Open(); //Abrir la conexion
            return conexion;
        }


    }
}
