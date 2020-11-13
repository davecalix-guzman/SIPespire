using SI_PESPIRE_AccesoDatos;
using SI_PESPIRE_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SI_PESPIRE_LogicaNegocio
{
    public class ModulosLN
    {
        public static List<Modulos> ObtenerModulos(bool estado, int menu)
        {
            try
            {
                return ModulosAD.ObtenerModulos(estado, menu);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static List<Modulos> ObtenerModulos()
        {
            try
            {
                return ModulosAD.ObtenerModulos();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static List<Modulos> ObtenerModulosPorRolId(int rolId)
        {
            try
            {
                var modulosDt = ModulosAD.ObtenerModulosPorRolId(rolId);
                var modulos = modulosDt.AsEnumerable().Select(x => new Modulos
                {
                    Nombre = x.Field<string>("Nombre"),
                    ModuloId = x.Field<int>("ModuloId"),
                    ClaseCss = x.Field<string>("ClaseCss")
                });
                return modulos.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}