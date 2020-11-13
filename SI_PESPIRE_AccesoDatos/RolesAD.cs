using SI_PESPIRE_Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SI_PESPIRE_AccesoDatos
{
    public class RolesAD
    {
        public static List<Roles> ObtenerRolesActivos()
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var rolesActivos = dbContext.Roles;
                    return rolesActivos.ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Roles ObtenerRolPorId(int rolSeleccionado)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var rol = dbContext.Roles.Include("Usuarios1").Include("RolModuloAcciones").FirstOrDefault(x => x.RolId == rolSeleccionado);
                    return rol;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Roles ObtenerRolPorNombre(string nombreRol)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var rol = dbContext.Roles.FirstOrDefault(x => x.Nombre == nombreRol);
                    return rol;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Roles InsertarNuevoRol(Roles nuevoRol)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    dbContext.Roles.Add(nuevoRol);
                    dbContext.SaveChanges();
                    return nuevoRol;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Roles ActualizarRol(Roles rolActualizar)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    dbContext.Entry(rolActualizar).State = EntityState.Modified;
                    dbContext.SaveChanges();
                    return rolActualizar;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static bool EliminarRegistroRol(Roles rolSeleccionado)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    var seEliminoRegistro = false;
                    var rolEliminar = dbContext.Roles.FirstOrDefault(x => x.RolId == rolSeleccionado.RolId);
                    if (rolEliminar != null)
                    {
                        dbContext.Roles.Remove(rolEliminar);
                        seEliminoRegistro = dbContext.SaveChanges() > 0;
                    }
                    return seEliminoRegistro;
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
