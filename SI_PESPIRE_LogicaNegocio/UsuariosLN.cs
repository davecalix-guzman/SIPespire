using SI_PESPIRE_AccesoDatos;
using SI_PESPIRE_Entidades;
using System;

namespace SI_PESPIRE_LogicaNegocio
{
    public class UsuariosLN
    {
        public static int ValidarUsuario(string nombreUsuario, string contrasenaEncriptada, ref Usuarios objetoUsuario)
        {
            try
            {
                var usuario = UsuariosAD.ObtenerUsuariosPorNombres(nombreUsuario);
                if (usuario != null)
                {
                    objetoUsuario = usuario;
                    return usuario.Contrasena != contrasenaEncriptada ? 0 :
                        !usuario.Estado ? 2 :
                        objetoUsuario.Reseteo ? 3 : 1;
                }

                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}