using System.Configuration;

namespace Datos
{
    public class Configuracion
    {
        static string cConexion = ConfigurationManager.ConnectionStrings["nominaImasD"].ConnectionString;
        public static string CadenaConexion { get { return cConexion; } }
    }
}
 