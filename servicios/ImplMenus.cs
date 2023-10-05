using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioConexionbdCRUD.servicios
{
    public class ImplMenus : IntzMenus
    {
        public void MostrarMenuMain()
        {
            Console.WriteLine("     1 Crear elementos     ");
            Console.WriteLine("  2 Seleccionar elementos  ");
            Console.WriteLine("   3 Modificar elementos   ");
            Console.WriteLine("    4 Eliminar elementos   ");
            Console.WriteLine("          5 Salir          ");
        }

        public void MostrarMenuSelect()
        {
            Console.WriteLine("      1 Seleccionar un registro      ");
            Console.WriteLine("  2 Seleccionar todos los registros  ");
            Console.WriteLine("              3 Volver        	     ");
        }

        public void MostrarMenuInsert()
        {
            Console.WriteLine("     1 Insertar un registro    ");
            Console.WriteLine("  2 Insertar varios registros  ");
            Console.WriteLine("            3 Volver           ");
        }
    }
}
