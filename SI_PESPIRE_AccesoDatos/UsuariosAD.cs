using SI_PESPIRE_Entidades;
using System;
using System.Linq;

namespace SI_PESPIRE_AccesoDatos
{
    public class UsuariosAD
    {
        public static Usuarios ObtenerUsuariosPorNombres(string nombreUsuario)
        {
            try
            {
                using (var dbContext = new SI_PESPIREEntities())
                {
                    //dbContext.Configuration.LazyLoadingEnabled = false;                    
                    var objetoUsuario = dbContext.Usuarios.Include("Roles1").Include("Oficinas")
                        .FirstOrDefault(x => x.NombreUsuario == nombreUsuario);
                    return objetoUsuario ?? null;
                }
            }
            catch (Exception ex)
            {
                var ee = ex.Message;
                throw;
            }
        }
    }
}