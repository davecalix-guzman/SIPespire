using System;
using SI_PESPIRE_AccesoDatos;
using System.Collections.Generic;
using SI_PESPIRE_Entidades;

namespace SI_PESPIRE_LogicaNegocio
{
    public class RolModuloAccionesLN
    {
        public static List<MenuNavegacion> ObtenerAccionesPorRol(int rolId, bool menu = false)
        {
            var listadoRoles = RolModuloAccionesAD.ObtenerAccionesPorRolId(rolId, menu);
            var listadoMenu = new List<MenuNavegacion>();
            foreach (var rol in listadoRoles)
            {
                var menuNavegacion = new MenuNavegacion
                {
                    ModuloAccionId = rol.FKAccionId,
                    ModuloId = rol.FKModuloId,
                    ModuloAccionNombre = rol.Acciones.Nombre,
                    ModuloPadre = rol.Acciones.Padre,
                    EsMenu = rol.Acciones.Menu,
                    Enlace = rol.Acciones.Enlace
                };
                listadoMenu.Add(menuNavegacion);
            }

            return listadoMenu;
        }

        public static List<RolModuloAcciones> ObtenerAccionesActivas(int rolSeleccionado)
        {
            try
            {
                return RolModuloAccionesAD.ObtenerAccionesActivas(rolSeleccionado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }   
        }

        public static RolModuloAcciones Insertar(RolModuloAcciones rolModuloAcciones)
        {
            try
            {
                return RolModuloAccionesAD.InsertarAcciones(rolModuloAcciones);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static bool Eliminar(int rolId)
        {
            try
            {
                return RolModuloAccionesAD.EliminarAccionesParaRol(rolId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}