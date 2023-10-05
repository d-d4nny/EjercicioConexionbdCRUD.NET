using EjercicioConexionbdCRUD.entidades;
using EjercicioConexionbdCRUD.utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EjercicioConexionbdCRUD.servicios
{
    public class ImplCRUD : IntzCRUD
    {

        // Instanciar implementaciones de las interfaces para usar en la aplicación
        ImplMenus intM = new ImplMenus();
        ADto adto = new ADto();
        List<LibroDto> listaLibros = new List<LibroDto>();

        public List<LibroDto> SeleccionaLibros(NpgsqlConnection conexionGenerada)
        {
            bool cerrarMenu = false;
            int opcion;

            try
            {
                do
                {
                    intM.MostrarMenuSelect();
                    Console.WriteLine("Introduce una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            try
                            {
                                NpgsqlCommand comandoSQL = new NpgsqlCommand("SELECT * FROM gbp_almacen.gbp_alm_cat_libros", conexionGenerada);
                                NpgsqlDataReader lector = comandoSQL.ExecuteReader();

                                listaLibros = adto.ResultsALibrosDto(lector);

                                int i = listaLibros.Count;
                                for (int cont = 0; cont < i; cont++)
                                {
                                    Console.WriteLine(listaLibros[cont].QueryBase());
                                }

                                Console.Write("Selecciona el ID del libro que quieres mostrar: ");
                                long selectLibro = Convert.ToInt64(Console.ReadLine());

                                bool libroEncontrado = false;
                                foreach (LibroDto libro in listaLibros)
                                {
                                    if (libro.IdLibro == selectLibro)
                                    {
                                        Console.WriteLine("Detalles del libro:");
                                        Console.WriteLine("ID Libro: " + libro.IdLibro);
                                        Console.WriteLine("Título: " + libro.Titulo);
                                        Console.WriteLine("Autor: " + libro.Autor);
                                        Console.WriteLine("ISBN: " + libro.Isbn);
                                        Console.WriteLine("Edición: " + libro.Edicion);
                                        libroEncontrado = true;
                                        break;
                                    }
                                }

                                if (!libroEncontrado)
                                {
                                    Console.WriteLine("No se encontró un libro con el ID proporcionado.");
                                }

                                lector.Close();
                            }
                            catch (NpgsqlException e)
                            {
                                Console.WriteLine("[ERROR] Error generando o ejecutando el comando SQL: " + e);
                                return listaLibros;
                            }
                            break;
                        case 2:
                            try
                            {
                                NpgsqlCommand comandoSQL = new NpgsqlCommand("SELECT * FROM gbp_almacen.gbp_alm_cat_libros", conexionGenerada);
                                NpgsqlDataReader lector = comandoSQL.ExecuteReader();

                                listaLibros = adto.ResultsALibrosDto(lector);

                                int i = listaLibros.Count;
                                for (int cont = 0; cont < i; cont++)
                                {
                                    Console.WriteLine(listaLibros[cont].ToString());
                                }

                                lector.Close();
                            }
                            catch (NpgsqlException e)
                            {
                                Console.WriteLine("[ERROR] Error generando o ejecutando el comando SQL: " + e);
                                return listaLibros;
                            }
                            break;
                        case 3:
                            cerrarMenu = true;
                            break;
                        default:
                            Console.WriteLine("\n**[ERROR] Opción elegida no disponible **");
                            break;
                    }

                } while (!cerrarMenu);
            }
            catch (FormatException e)
            {
                Console.WriteLine("\n**[ERROR] Entrada inválida: por favor ingresa un número entero **");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n**[ERROR] Ocurrió una excepción no esperada: " + e.Message + " **");
            }

            return listaLibros;
        }


        public List<LibroDto> InsertarLibros(NpgsqlConnection conexionGenerada)
        {
            bool cerrarMenu = false;
            int opcion;

            try
            {
                do
                {
                    intM.MostrarMenuInsert();
                    Console.WriteLine("Introduce una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            // Inserción de un solo libro
                            Console.Write("Ingrese el título del nuevo libro: ");
                            string titulo = Console.ReadLine();

                            Console.Write("Ingrese el autor del nuevo libro: ");
                            string autor = Console.ReadLine();

                            Console.Write("Ingrese el ISBN del nuevo libro: ");
                            string isbn = Console.ReadLine();

                            Console.Write("Ingrese la edición del nuevo libro: ");
                            int edicion = Convert.ToInt32(Console.ReadLine());

                            try
                            {
                                string query = $"INSERT INTO gbp_almacen.gbp_alm_cat_libros (titulo, autor, isbn, edicion) VALUES ('{titulo}', '{autor}', '{isbn}', {edicion})";

                                using (var comandoSQL = new NpgsqlCommand(query, conexionGenerada))
                                {
                                    int filasAfectadas = comandoSQL.ExecuteNonQuery();

                                    if (filasAfectadas > 0)
                                    {
                                        Console.WriteLine("Nuevo libro agregado exitosamente.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No se pudo agregar el nuevo libro.");
                                    }
                                }
                            }
                            catch (NpgsqlException e)
                            {
                                Console.WriteLine("[ERROR] Error al agregar un nuevo libro: " + e);
                            }

                            break;
                        case 2:
                            Console.Write("¿Cuántas inserciones desea realizar?: ");
                            int numInserciones = Convert.ToInt32(Console.ReadLine());

                            for (int i = 0; i < numInserciones; i++)
                            {
                                Console.WriteLine("Inserción #" + (i + 1));

                                Console.Write("Ingrese el título del nuevo libro: ");
                                string tituloInsert = Console.ReadLine();

                                Console.Write("Ingrese el autor del nuevo libro: ");
                                string autorInsert = Console.ReadLine();

                                Console.Write("Ingrese el ISBN del nuevo libro: ");
                                string isbnInsert = Console.ReadLine();

                                Console.Write("Ingrese la edición del nuevo libro: ");
                                int edicionInsert = Convert.ToInt32(Console.ReadLine());

                                listaLibros.Add(new LibroDto(0, tituloInsert, autorInsert, isbnInsert, edicionInsert));
                            }

                            try
                            {
                                using (var comandoSQL = conexionGenerada.CreateCommand())
                                {
                                    foreach (LibroDto libro in listaLibros)
                                    {
                                        string query = $"INSERT INTO gbp_almacen.gbp_alm_cat_libros (titulo, autor, isbn, edicion) VALUES ('{libro.Titulo}', '{libro.Autor}', '{libro.Isbn}', {libro.Edicion})";
                                        comandoSQL.CommandText = query;
                                        comandoSQL.ExecuteNonQuery();
                                    }

                                    Console.WriteLine("Inserciones realizadas exitosamente.");
                                }
                            }
                            catch (NpgsqlException e)
                            {
                                Console.WriteLine("[ERROR] Error al agregar nuevos libros: " + e);
                            }

                            break;
                        case 3:
                            cerrarMenu = true;
                            break;
                        default:
                            Console.WriteLine("\n**[ERROR] Opción elegida no disponible **");
                            break;
                    }

                } while (!cerrarMenu);

            }
            catch (FormatException e)
            {
                Console.WriteLine("\n**[ERROR] Entrada inválida: por favor ingrese un número entero **");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n**[ERROR] Ocurrió una excepción no esperada: " + e.Message + " **");
            }

            return listaLibros;
        }

        public List<LibroDto> ModificarLibros(NpgsqlConnection conexionGenerada)
        {
            try
            {
                // Crear un comando para ejecutar una consulta SQL
                using (var comandoSQL = new NpgsqlCommand("SELECT id_libro, titulo FROM gbp_almacen.gbp_alm_cat_libros", conexionGenerada))
                {
                    // Ejecutar la consulta para obtener los libros disponibles
                    using (var lector = comandoSQL.ExecuteReader())
                    {
                        // Mostrar los detalles de los libros
                        while (lector.Read())
                        {
                            int idLibro = lector.GetInt32(0);
                            string titulo = lector.GetString(1);
                            Console.WriteLine("ID Libro: " + idLibro + ", Título: " + titulo);
                        }
                    }
                }

                // Solicitar al usuario el ID del libro que desea modificar
                Console.Write("Seleccione el ID del libro que desea modificar: ");
                int idLibroSeleccionado = Convert.ToInt32(Console.ReadLine());

                // Mostrar los campos disponibles para modificar
                Console.WriteLine("Campos disponibles para modificar (seleccione primero los campos y luego pulse 5 para confirmar): ");
                Console.WriteLine("1. Título");
                Console.WriteLine("2. Autor");
                Console.WriteLine("3. ISBN");
                Console.WriteLine("4. Edición");
                Console.WriteLine("5. Confirmar Selección");

                // Lista para almacenar los campos a modificar
                List<string> camposAModificar = new List<string>();
                bool seguirModificando = true;

                // Permitir al usuario seleccionar los campos a modificar
                while (seguirModificando)
                {
                    Console.Write("Introduzca el campo: ");
                    int opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            camposAModificar.Add("titulo");
                            break;
                        case 2:
                            camposAModificar.Add("autor");
                            break;
                        case 3:
                            camposAModificar.Add("isbn");
                            break;
                        case 4:
                            camposAModificar.Add("edicion");
                            break;
                        case 5:
                            seguirModificando = false;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }

                // Modificar los campos seleccionados
                foreach (string campoAModificar in camposAModificar)
                {
                    Console.Write("Ingrese el nuevo valor para el campo " + campoAModificar + ": ");
                    string nuevoValor = Console.ReadLine();

                    // Preparar la consulta de actualización para campo "edicion"
                    string query = "UPDATE gbp_almacen.gbp_alm_cat_libros SET " + campoAModificar + " = @nuevoValor WHERE id_libro = @idLibro";
                    using (var preparedStatement = new NpgsqlCommand(query, conexionGenerada))
                    {
                        if (campoAModificar == "edicion" && !int.TryParse(nuevoValor, out int edicion))
                        {
                            Console.WriteLine("El valor para edición debe ser un número entero.");
                            continue;
                        }

                        preparedStatement.Parameters.AddWithValue("@nuevoValor", nuevoValor);
                        preparedStatement.Parameters.AddWithValue("@idLibro", idLibroSeleccionado);

                        try
                        {
                            int filasAfectadas = preparedStatement.ExecuteNonQuery();

                            // Mostrar el resultado de la actualización
                            if (filasAfectadas > 0)
                            {
                                Console.WriteLine("Campo " + campoAModificar + " modificado exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("No se pudo modificar el campo " + campoAModificar + ".");
                            }
                        }
                        catch (NpgsqlException ex)
                        {
                            Console.WriteLine("Error al modificar el libro: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió una excepción no esperada: " + ex.Message);
            }

            return listaLibros;
        }

        public List<LibroDto> EliminarLibros(NpgsqlConnection conexionGenerada)
        {
            try
            {
                // Crear un comando para ejecutar una consulta SQL
                using (var comandoSQL = new NpgsqlCommand("SELECT id_libro, titulo FROM gbp_almacen.gbp_alm_cat_libros", conexionGenerada))
                {
                    // Ejecutar la consulta para obtener los libros disponibles
                    using (var lector = comandoSQL.ExecuteReader())
                    {
                        // Mostrar los detalles de los libros
                        while (lector.Read())
                        {
                            int idLibro = lector.GetInt32(0);
                            string titulo = lector.GetString(1);
                            Console.WriteLine("ID Libro: " + idLibro + ", Título: " + titulo);
                        }
                    }
                }

                // Solicitar al usuario el ID del libro que desea eliminar
                Console.Write("Seleccione el ID del libro que desea eliminar: ");
                int idLibroEliminar = Convert.ToInt32(Console.ReadLine());

                // Verificar si se encontró el libro a eliminar
                bool libroEncontrado = false;
                string tituloLibroEliminar = null;

                // Crear un comando para obtener el título del libro a eliminar
                using (var comandoTitulo = new NpgsqlCommand("SELECT titulo FROM gbp_almacen.gbp_alm_cat_libros WHERE id_libro = @idLibro", conexionGenerada))
                {
                    comandoTitulo.Parameters.AddWithValue("@idLibro", idLibroEliminar);
                    using (var lectorTitulo = comandoTitulo.ExecuteReader())
                    {
                        if (lectorTitulo.Read())
                        {
                            tituloLibroEliminar = lectorTitulo.GetString(0);
                            libroEncontrado = true;
                        }
                    }
                }

                if (libroEncontrado)
                {
                    // Solicitar confirmación al usuario
                    Console.Write("Para confirmar la eliminación, escriba el nombre completo del libro a borrar ("
                                  + tituloLibroEliminar + "): ");
                    string confirmacion = Console.ReadLine();

                    // Verificar la confirmación del usuario
                    if (confirmacion.Equals(tituloLibroEliminar, StringComparison.OrdinalIgnoreCase))
                    {
                        // Preparar la consulta de eliminación
                        string query = "DELETE FROM gbp_almacen.gbp_alm_cat_libros WHERE id_libro = @idLibro";
                        using (var preparedStatement = new NpgsqlCommand(query, conexionGenerada))
                        {
                            preparedStatement.Parameters.AddWithValue("@idLibro", idLibroEliminar);

                            // Ejecutar la consulta de eliminación
                            int filasAfectadas = preparedStatement.ExecuteNonQuery();

                            // Mostrar el resultado de la eliminación
                            if (filasAfectadas > 0)
                            {
                                Console.WriteLine("Libro eliminado exitosamente.");
                            }
                            else
                            {
                                Console.WriteLine("No se pudo eliminar el libro.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("La confirmación no coincide. No se ha eliminado el libro.");
                    }
                }
                else
                {
                    Console.WriteLine("No se encontró un libro con el ID proporcionado.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocurrió una excepción no esperada: " + ex.Message);
            }

            return listaLibros;
        }
    }
}
