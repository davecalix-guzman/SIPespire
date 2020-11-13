using SI_PESPIRE_Entidades;
using System;
using System.Collections.Generic;
using SI_PESPIRE_AccesoDatos;

namespace SI_PESPIRE_LogicaNegocio
{
    public class AccionesLN
    {
        public static List<Acciones> ObtenerAccionesPorModuloId(int moduloModuloId)
        {
            try
            {
                return AccionesAD.ObtenerAccionesPorModuloId(moduloModuloId);
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
                return AccionesAD.ObtenerAccionesPorPadre(moduloId, accionId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static List<Acciones> ObtenerAcciones()
        {
            try
            {
                return AccionesAD.ObtenerAcciones(true);
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
                return AccionesAD.ObtenerAccionPorNombrePorPadre(nombreAccion, padre);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static int RegistrarNuevaAccion(Acciones nuevaAccion)
        {
            try
            {
                var accionTemporal = ObtenerAccionPorId(nuevaAccion.AccionId);
                return accionTemporal != null ? 0 : (AccionesAD.InsertarNuevaAccion(nuevaAccion) != null ? 1 : -1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static Acciones ObtenerAccionPorId(int nuevaAccionId)
        {
            try
            {
                return AccionesAD.ObtenerAccionId(nuevaAccionId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static int ActualizarAccion(Acciones accionActualizar)
        {
            try
            {
                accionActualizar = AccionesAD.ActualizarAccion(accionActualizar);
                return accionActualizar != null ? 1 : -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
