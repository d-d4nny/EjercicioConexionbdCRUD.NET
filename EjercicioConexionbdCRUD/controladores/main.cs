using System;
using EjercicioConexionbdCRUD.servicios;
using Npgsql;

namespace Controladores
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            // Instanciar implementaciones de las interfaces para usar en la aplicación
            IntzMenus menu = new ImplMenus();
            IntzConexion cpi = new ImplConexion();
            IntzCRUD crud = new ImplCRUD();

            bool cerrarMenu = false;
            int opcion;

            try
            {
                // Establecer la conexión con la base de datos
                NpgsqlConnection conexion = cpi.GeneraConexion();

                do
                {
                    // Mostrar el menú principal
                    menu.MostrarMenuMain();

                    Console.WriteLine("Introduce una opcion: ");
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            // Llamar al método para insertar libros
                            crud.InsertarLibros(conexion);
                            break;
                        case 2:
                            // Llamar al método para seleccionar libros
                            crud.SeleccionaLibros(conexion);
                            break;
                        case 3:
                            // Llamar al método para modificar libros
                            crud.ModificarLibros(conexion);
                            break;
                        case 4:
                            // Llamar al método para eliminar libros
                            crud.EliminarLibros(conexion);
                            break;
                        case 5:
                            // Cerrar el menú
                            cerrarMenu = true;
                            break;
                        default:
                            Console.WriteLine("\n**[ERROR] Opción elegida no disponible **");
                            break;
                    }

                } while (!cerrarMenu);
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR-Main] Se ha producido un error al ejecutar la aplicación: " + e);
            }
        }
    }
}