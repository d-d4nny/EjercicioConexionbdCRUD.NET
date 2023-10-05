using EjercicioConexionbdCRUD.entidades;
using Npgsql;
using System.Collections.Generic;


namespace EjercicioConexionbdCRUD.servicios
{
    public interface IntzCRUD
    {
        /// <summary>
        /// Método para seleccionar libros de la base de datos.
        /// </summary>
        /// <param name="conexionGenerada">Objeto NpgsqlConnection que representa la conexión a la base de datos.</param>
        /// <returns>Lista de objetos LibroDto que representan los libros seleccionados.</returns>
        List<LibroDto> SeleccionaLibros(NpgsqlConnection conexionGenerada);

        /// <summary>
        /// Método para insertar libros en la base de datos.
        /// </summary>
        /// <param name="conexionGenerada">Objeto NpgsqlConnection que representa la conexión a la base de datos.</param>
        /// <returns>Lista de objetos LibroDto que representan los libros insertados.</returns>
        List<LibroDto> InsertarLibros(NpgsqlConnection conexionGenerada);

        /// <summary>
        /// Método para modificar libros en la base de datos.
        /// </summary>
        /// <param name="conexionGenerada">Objeto NpgsqlConnection que representa la conexión a la base de datos.</param>
        /// <returns>Lista de objetos LibroDto que representan los libros modificados.</returns>
        List<LibroDto> ModificarLibros(NpgsqlConnection conexionGenerada);

        /// <summary>
        /// Método para eliminar libros de la base de datos.
        /// </summary>
        /// <param name="conexionGenerada">Objeto NpgsqlConnection que representa la conexión a la base de datos.</param>
        /// <returns>Lista de objetos LibroDto que representan los libros eliminados.</returns>
        List<LibroDto> EliminarLibros(NpgsqlConnection conexionGenerada);
    }
}

