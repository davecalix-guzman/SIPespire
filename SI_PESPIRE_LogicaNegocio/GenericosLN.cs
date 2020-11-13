using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SI_PESPIRE_AccesoDatos;

namespace SI_PESPIRE_LogicaNegocio
{
    public class GenericosLN
    {
        public static string ObtenerCampoId(string nombreEntidad)
        {
            try
            {
                return GenericosAD.ObtenerCampoId(nombreEntidad);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static bool EliminarEntidad(string nombreTablaBd, string nombreCampoId, int valorId)
        {
            try
            {
               return GenericosAD.EliminarEntidad(nombreTablaBd, nombreCampoId, valorId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string ObtenerNombreTablaBd(string nombreEntidad)
        {
            try
            {
                return GenericosAD.ObtenerNombreTablaBd(nombreEntidad);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
