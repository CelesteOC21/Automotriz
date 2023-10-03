using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class Conexion
    {
        public MySqlConnection connection;

        public Conexion(string servidor, string usuario, string password, string database, uint puerto)
        {
            MySqlConnectionStringBuilder CadenaConexion = new MySqlConnectionStringBuilder();
            CadenaConexion.Server = servidor;
            CadenaConexion.UserID = usuario;
            CadenaConexion.Password = password;
            CadenaConexion.Database = database;
            CadenaConexion.Port = puerto;

            connection = new MySqlConnection(CadenaConexion.ToString());
        }

        public void EjecutarConsulta(string consulta)
        {
            try
            {
                connection.Open();
                using (MySqlCommand comando = new MySqlCommand(consulta, connection))
                {
                    comando.ExecuteNonQuery();
                    Console.WriteLine("Consulta ejecutada correctamente");
                }
                connection.Close();
            }
            catch (Exception)
            {
                connection.Close();
                //throw ex;

            }
        }

        //método utilizado para obtener datos de una base de datos y devolverlos en forma de un objeto DataTable
        public DataTable ObtenerDatos(string consulta)
        {
            //Se crea un nuevo objeto DataTable llamado dataTable, que se utilizará para almacenar los datos recuperados de la bd
            DataTable dataTable = new DataTable();
            try
            {
                connection.Open();
                using (MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, connection))
                {
                    //Se llama al método Fill del adaptador, que ejecuta la consulta y llena el dataTable con los resultados obtenidos
                    //de la base de datos.
                    adaptador.Fill(dataTable);
                    Console.WriteLine("Consulta ejecutada correctamente");
                }
                connection.Close();
            }

            catch (Exception ex)
            {
                connection.Close();
                Console.WriteLine("Error al ejecutar la consulta: ", ex.Message);
            }
            return dataTable;
        }

    }
}
