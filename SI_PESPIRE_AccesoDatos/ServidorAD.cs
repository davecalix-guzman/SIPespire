using System.Configuration;

namespace SI_PESPIRE_AccesoDatos
{
    public class ServidorAD
    {
        public static string CadenaConexion = ConfigurationManager.ConnectionStrings["SI_PESPIRESQL"].ConnectionString;
    }
}