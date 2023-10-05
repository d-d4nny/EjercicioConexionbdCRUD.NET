using System;

namespace EjercicioConexionbdCRUD.servicios // Define un espacio de nombres EjercicioConexionbdCRUD.servicios
{
    public class ImplMenus : IntzMenus // Define una clase pública llamada ImplMenus que implementa la interfaz IntzMenus
    {
        /// <summary>
        /// Muestra el menú principal con opciones para crear, seleccionar, modificar, eliminar o salir.
        /// </summary>
        public void MostrarMenuMain()
        {
            Console.WriteLine("     1 Crear elementos     "); // Muestra la opción 1: Crear elementos
            Console.WriteLine("  2 Seleccionar elementos  "); // Muestra la opción 2: Seleccionar elementos
            Console.WriteLine("   3 Modificar elementos   "); // Muestra la opción 3: Modificar elementos
            Console.WriteLine("    4 Eliminar elementos   "); // Muestra la opción 4: Eliminar elementos
            Console.WriteLine("          5 Salir          "); // Muestra la opción 5: Salir
        }

        /// <summary>
        /// Muestra el menú para seleccionar opciones relacionadas con registros.
        /// </summary>
        public void MostrarMenuSelect()
        {
            Console.WriteLine("      1 Seleccionar un registro      "); // Muestra la opción 1: Seleccionar un registro
            Console.WriteLine("  2 Seleccionar todos los registros  "); // Muestra la opción 2: Seleccionar todos los registros
            Console.WriteLine("              3 Volver        	     "); // Muestra la opción 3: Volver
        }

        /// <summary>
        /// Muestra el menú para insertar registros, ya sea uno o varios.
        /// </summary>
        public void MostrarMenuInsert()
        {
            Console.WriteLine("     1 Insertar un registro    "); // Muestra la opción 1: Insertar un registro
            Console.WriteLine("  2 Insertar varios registros  "); // Muestra la opción 2: Insertar varios registros
            Console.WriteLine("            3 Volver           "); // Muestra la opción 3: Volver
        }
    }
}