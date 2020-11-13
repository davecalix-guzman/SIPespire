using SI_PESPIRE_AccesoDatos;
using SI_PESPIRE_Entidades;
using System;
using System.Collections.Generic;

namespace SI_PESPIRE_LogicaNegocio
{
    public class RolesLN
    {
        public static List<Roles> ObtenerRolesActivos()
        {
            try
            {
                return RolesAD.ObtenerRolesActivos();
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
                return RolesAD.ObtenerRolPorId(rolSeleccionado);
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
                return RolesAD.ObtenerRolPorNombre(nombreRol);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static int RegistrarNuevoRol(Roles nuevoRol)
        {
            try
            {
                var rolTemporal = ObtenerRolPorId(nuevoRol.RolId);
                return rolTemporal != null ? 0 : (RolesAD.InsertarNuevoRol(nuevoRol) != null ? 1 : -1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static int ActualizarRol(Roles rolActualizar)
        {
            try
            {
                rolActualizar = RolesAD.ActualizarRol(rolActualizar);
                return rolActualizar != null ? 1 : -1;
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
                return RolesAD.EliminarRegistroRol(rolSeleccionado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
