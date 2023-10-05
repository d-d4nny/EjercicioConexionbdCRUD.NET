using EjercicioConexionbdCRUD.entidades;
using Npgsql;
using System;
using System.Collections.Generic;

namespace EjercicioConexionbdCRUD.utils
{
    public class ADto
    {
        /// <summary>
        /// Convierte un NpgsqlDataReader en una lista de objetos LibroDto.
        /// </summary>
        /// <param name="resultadoConsulta">NpgsqlDataReader que representa el resultado de la consulta.</param>
        /// <returns>Lista de objetos LibroDto.</returns>
        public List<LibroDto> ResultsALibrosDto(NpgsqlDataReader resultadoConsulta)
        {
            List<LibroDto> listaLibros = new List<LibroDto>(); // Crea una lista de objetos LibroDto

            try
            {
                while (resultadoConsulta.Read()) // Itera sobre el resultado de la consulta
                {
                    LibroDto libroDto = new LibroDto // Crea un objeto LibroDto y asigna valores
                    {
                        IdLibro = Convert.ToInt64(resultadoConsulta["id_libro"]), // Convierte y asigna el Id del libro
                        Titulo = Convert.ToString(resultadoConsulta["titulo"]), // Convierte y asigna el título del libro
                        Autor = Convert.ToString(resultadoConsulta["autor"]), // Convierte y asigna el autor del libro
                        Isbn = Convert.ToString(resultadoConsulta["isbn"]), // Convierte y asigna el ISBN del libro
                        Edicion = Convert.ToInt32(resultadoConsulta["edicion"]) // Convierte y asigna la edición del libro
                    };

                    listaLibros.Add(libroDto); // Agrega el objeto LibroDto a la lista de libros
                }

                int i = listaLibros.Count; // Obtiene el número de libros en la lista
                Console.WriteLine("[INFORMACIÓN-ADto-resultsALibrosDto] Número libros: " + i); // Imprime el número de libros

            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR-ADto-resultsALibrosDto] Error al pasar el result set a lista de LibroDto" + e); // Imprime un mensaje de error en caso de excepción
            }

            return listaLibros; // Devuelve la lista de libros
        }
    }
}
