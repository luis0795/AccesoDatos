// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");
namespace AccesoDatos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LeerRegistroDept();
            //InsertarDatosDept();
        }
        static void InsertarDatosDept()
        {
            string connectionString = @"Data Source=sqleoi.database.windows.net;Initial Catalog=AZUREALUMNOS;Persist Security Info=True;User ID=adminsql;Password=Admin123";
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand();
            string sql = "insert into DEPT values (88, 'INFORMATICA', 'OVIEDO')";
            com.Connection= cn;
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = sql;
            cn.Open();
            int insertados = com.ExecuteNonQuery();
            cn.Close();
            Console.WriteLine("registros Insertados: " + insertados);
        }
        static void LeerRegistroDept()
        {
            string connectionString = @"Data Source=sqleoi.database.windows.net;Initial Catalog=AZUREALUMNOS;Persist Security Info=True;User ID=adminsql;Password=Admin123";
            SqlConnection cn = new SqlConnection(connectionString);
            SqlCommand com = new SqlCommand();
            SqlDataReader lector;
            string sql = "select * from DEPT";
            com.Connection= cn;
            com.CommandType = System.Data.CommandType.Text;
            com.CommandText = sql;
            cn.Open();
            lector = com.ExecuteReader();
            while (lector.Read())
            {
                string nombre = lector["DNOMBRE"].ToString();
                string localidad = lector["LOC"].ToString();
                Console.WriteLine(nombre+ " " + localidad);

            }
          
            lector.Close();
            cn.Close();
            Console.WriteLine("FIN DE PROGRAMA");
        }
    }
}