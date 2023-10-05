using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioConexionbdCRUD.servicios
{
    public interface IntzConexion
    {
        // Método para generar la conexión con la base de datos
        NpgsqlConnection GeneraConexion();
    }
}
