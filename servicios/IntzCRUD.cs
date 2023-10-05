using EjercicioConexionbdCRUD.entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioConexionbdCRUD.servicios
{
    public interface IntzCRUD
    {
        // Método para seleccionar libros
        List<LibroDto> SeleccionaLibros(NpgsqlConnection conexionGenerada);

        // Método para insertar libros
        List<LibroDto> InsertarLibros(NpgsqlConnection conexionGenerada);

        // Método para modificar libros
        List<LibroDto> ModificarLibros(NpgsqlConnection conexionGenerada);

        // Método para eliminar libros
        List<LibroDto> EliminarLibros(NpgsqlConnection conexionGenerada);
    }
}
