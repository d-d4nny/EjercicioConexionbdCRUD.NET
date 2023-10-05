using Npgsql;

namespace EjercicioConexionbdCRUD.servicios 
{
    public interface IntzConexion
    {
        /// <summary>
        /// Genera una conexión a la base de datos utilizando la implementación específica de la clase que implemente esta interfaz.
        /// </summary>
        /// <returns>Objeto NpgsqlConnection que representa la conexión a la base de datos.</returns>
        NpgsqlConnection GeneraConexion();
    }
}
