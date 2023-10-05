using EjercicioConexionbdCRUD.entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioConexionbdCRUD.utils
{
    public class ADto
    {
        public List<LibroDto> ResultsALibrosDto(NpgsqlDataReader resultadoConsulta)
        {
            List<LibroDto> listaLibros = new List<LibroDto>();

            try
            {
                while (resultadoConsulta.Read())
                {
                    LibroDto libroDto = new LibroDto
                    {
                        IdLibro = Convert.ToInt64(resultadoConsulta["id_libro"]),
                        Titulo = Convert.ToString(resultadoConsulta["titulo"]),
                        Autor = Convert.ToString(resultadoConsulta["autor"]),
                        Isbn = Convert.ToString(resultadoConsulta["isbn"]),
                        Edicion = Convert.ToInt32(resultadoConsulta["edicion"])
                    };

                    listaLibros.Add(libroDto);
                }

                int i = listaLibros.Count;
                Console.WriteLine("[INFORMACIÓN-ADto-resultsALibrosDto] Número libros: " + i);

            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR-ADto-resultsALibrosDto] Error al pasar el result set a lista de LibroDto" + e);
            }

            return listaLibros;
        }
    }
}
