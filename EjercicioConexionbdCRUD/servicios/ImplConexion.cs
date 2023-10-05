using Npgsql; // Importa la clase Npgsql para trabajar con NpgsqlConnection
using System;
using System.Configuration;

namespace EjercicioConexionbdCRUD.servicios
{
    public class ImplConexion : IntzConexion
    {
        /// <summary>
        /// Genera una conexión a la base de datos utilizando la cadena de conexión a PostgreSQL especificada en la configuración.
        /// </summary>
        /// <returns>Objeto NpgsqlConnection que representa la conexión a la base de datos.</returns>
        public NpgsqlConnection GeneraConexion()
        {
            // Se lee la cadena de conexión a PostgreSQL del archivo de configuración
            string stringConexionPostgresql = ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString;
            NpgsqlConnection conexion = null; // Inicializa la variable de conexión como nula
            string estado = ""; // Variable para almacenar el estado de la conexión

            if (!string.IsNullOrWhiteSpace(stringConexionPostgresql))
            {
                try
                {
                    // Intenta establecer la conexión
                    conexion = new NpgsqlConnection(stringConexionPostgresql);
                    conexion.Open(); // Abre la conexión

                    // Se obtiene el estado de conexión para informarlo por consola
                    estado = conexion.State.ToString();
                    if (estado.Equals("Open"))
                    {
                        Console.WriteLine("[INFORMACIÓN-CrudImplementacion-generarConexionPostgresql] Estado conexión: " + estado);
                    }
                    else
                    {
                        conexion = null; // Si el estado no es "Open", establece la conexión como nula
                    }
                }
                catch (Exception e)
                {
                    // Captura cualquier excepción que pueda ocurrir al generar la conexión
                    Console.WriteLine("[ERROR-CrudImplementacion-generarConexionPostgresql] Error al generar la conexión:" + e);
                    conexion = null; // Establece la conexión como nula en caso de error
                    return conexion; // Retorna la conexión nula

                }
            }

            return conexion; // Retorna la conexión generada o nula si ocurrió un error
        }
    }
}
