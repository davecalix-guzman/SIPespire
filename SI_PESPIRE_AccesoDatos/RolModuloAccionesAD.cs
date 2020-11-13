using SI_PESPIRE_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SI_PESPIRE_AccesoDatos
{
    public class RolModuloAccionesAD
    {
        public static List<RolModuloAcciones> ObtenerAccionesPorRolId(int rolId, bool menu)
        {
            using (var dbContext = new SI_PESPIREEntities())
            {
                try
                {
                    var listadoRolModuloAcciones = dbContext.RolModuloAcciones.Include("Acciones")
                        .Where(x => x.FKRolId == rolId && x.Acciones.Padre == 0 && x.Acciones.Menu == menu).OrderBy(x => x.Acciones.Nombre);
                    return listadoRolModuloAcciones.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public static List<RolModuloAcciones> ObtenerAccionesActivas(int rolSeleccionado)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var rolModuloAccionesActivas = dbContext.RolModuloAcciones.Where(x => x.FKRolId == rolSeleccionado);
                    return rolModuloAccionesActivas.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static RolModuloAcciones InsertarAcciones(RolModuloAcciones rolModuloAcciones)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    dbContext.RolModuloAcciones.Add(rolModuloAcciones);
                    dbContext.SaveChanges();
                    return rolModuloAcciones;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool EliminarAccionesParaRol(int rolId)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var ListaParametros = new List<SqlParameter> { new SqlParameter("@rolId", rolId) };
                    var parametros = ListaParametros.ToArray();
                    return dbContext.Database.ExecuteSqlCommand("DELETE FROM [SI_PESPIRE].[dbo].[ROLMODULOACCIONES] WHERE FKROLID = @rolId", parametros) > 0;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}