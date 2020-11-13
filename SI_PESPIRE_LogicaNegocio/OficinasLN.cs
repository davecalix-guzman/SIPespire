using System;
using SI_PESPIRE_AccesoDatos;
using SI_PESPIRE_Entidades;

namespace SI_PESPIRE_LogicaNegocio
{
    public class OficinasLN
    {
        public static Oficinas ObtenerOficinaPorId(int oficinaId)
        {
            try
            {
                return OficinasAD.ObtenerOficinaPorId(oficinaId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}