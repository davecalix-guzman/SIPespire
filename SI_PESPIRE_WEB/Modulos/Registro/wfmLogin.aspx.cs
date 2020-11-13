using Gv.Seguridad;
using SI_PESPIRE_Entidades;
using SI_PESPIRE_LogicaNegocio;
using System;
using System.Drawing;
using System.Web.UI;

namespace SI_PESPIRE_WEB.Modulos.Registro
{
    public partial class wfmLogin : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNombreUsuario.Focus();
            Session.Remove("vsRolId");
            Session.Remove("vsUsuarioId");
            Session.Remove("vsUsuarioNombre");
            Session.Remove("vsUsuarioNombreCompleto");
            Session.Remove("vsRolNombre");
            Session.Remove("vsOficinaNombre");
            Session.Remove("vsMenuGenerado");
        }

        protected void btnEntrar_OnClick(object sender, EventArgs e)
        {
            ValidarUsuario();
        }

        private void ValidarUsuario()
        {
            try
            {
                Usuarios usuario = null;
                var nombreUsuario = txtNombreUsuario.Text.Trim();
                var contrasena = txtContrasenia.Text.Trim();
                var contraseñaEncriptada = GVC.EncriptarEnUnaVia(contrasena);
                var resultado = UsuariosLN.ValidarUsuario(nombreUsuario, contraseñaEncriptada.Trim(), ref usuario);

                switch (resultado)
                {
                    case -1:
                        lblMensaje.Visible = true;
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = @"El usuario ingresado no existe.";
                        break;
                    case 0:
                        lblMensaje.Visible = true;
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = @"La contraseña ingresada es incorrecta.";
                        break;
                    case 1:
                        {
                            var oficina = OficinasLN.ObtenerOficinaPorId(usuario.FKOficinaId);
                            var nombreOficina = oficina != null ? oficina.Nombre : string.Empty;

                            if (usuario != null)
                            {
                                Session["vsRolId"] = usuario.FKRolId;
                                Session["vsUsuarioId"] = usuario.UsuarioId;
                                Session["vsUsuarioNombre"] = usuario.NombreUsuario;
                                Session["vsUsuarioNombreCompleto"] = usuario.NombreCompleto;
                                Session["vsRolNombre"] = usuario.Roles1.Nombre;
                            }
                            if (oficina != null)
                            {
                                Session["vsOficinaNombre"] = nombreOficina;
                            }  
                            Response.Redirect("~/");                          
                            break;
                        }

                    case 2:
                        lblMensaje.Visible = true;
                        lblMensaje.ForeColor = Color.Red;
                        lblMensaje.Text = @"La cuenta no está activa.";
                        break;
                    case 3:
                        pnlLogin.Visible = false;
                        pnlResetearContrasenia.Visible = true;
                        Session["vsUsuario"] = usuario;
                        txtContrasenia.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                SiteMaster.MostrarMensaje(SiteMaster.TipoMensaje.Excepcion,
                    @"Error al tratar de establecer la conexión al servidor. Comuníquelo al administrador del sistema.");
            }
        }
    }
}