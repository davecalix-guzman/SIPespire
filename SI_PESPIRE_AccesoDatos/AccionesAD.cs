using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SI_PESPIRE_Entidades;

namespace SI_PESPIRE_AccesoDatos
{
    public class AccionesAD
    {
        public static List<Acciones> ObtenerAccionesPorModuloId(int moduloId)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var listadoAcciones = dbContext.Acciones.Where(x => x.FKModuloId == moduloId);
                    return listadoAcciones.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static List<Acciones> ObtenerAccionesPorPadre(int moduloId, int accionId)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var accionesPorPadre =
                        dbContext.Acciones.Where(x => x.FKModuloId == moduloId && x.Padre == accionId);
                    return accionesPorPadre.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static List<Acciones> ObtenerAcciones(bool accionesActivas)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var listadoAcciones = dbContext.Acciones.Include("Modulos").Where(x => x.Estado == accionesActivas);
                    return listadoAcciones.ToList();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Acciones ObtenerAccionPorNombrePorPadre(string nombreAccion, int padre)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var accionEncontrada =
                        dbContext.Acciones.FirstOrDefault(x => x.Nombre == nombreAccion && x.Padre == padre);
                    return accionEncontrada;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Acciones ObtenerAccionId(int nuevaAccionId)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var accionEncontrada = dbContext.Acciones.FirstOrDefault(x => x.AccionId == nuevaAccionId);
                    return accionEncontrada;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Acciones InsertarNuevaAccion(Acciones nuevaAccion)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    dbContext.Acciones.Add(nuevaAccion);
                    dbContext.SaveChanges();
                    return nuevaAccion;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Acciones ActualizarAccion(Acciones accionActualizar)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    dbContext.Entry(accionActualizar).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return accionActualizar;
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
