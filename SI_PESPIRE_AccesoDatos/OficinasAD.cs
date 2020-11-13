using SI_PESPIRE_Entidades;
using System;
using System.Linq;

namespace SI_PESPIRE_AccesoDatos
{
    public class OficinasAD
    {
        public static Oficinas ObtenerOficinaPorId(int oficinaId)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var oficina = dbContext.Oficinas.FirstOrDefault(x => x.OficinaId == oficinaId);
                    return oficina;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}