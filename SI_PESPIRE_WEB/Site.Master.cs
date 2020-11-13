using Microsoft.Ajax.Utilities;
using SI_PESPIRE_LogicaNegocio;
using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace SI_PESPIRE_WEB
{
    public partial class SiteMaster : MasterPage
    {
        /// <summary>
        /// Enumeración de los tipos de mensajes mostrados al usuario en los popups
        /// </summary>
        public enum TipoMensaje
        {
            Excepcion = -1,
            Informacion = 0,
            Exito = 1,
            Atencion = 2,
            Interrogacion = 3
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GenerarMenuDinamico();
        }

        /// <summary>
        /// Método que inserta el título del formulario en la aplicación web
        /// </summary>
        /// <param name="encabezado"></param>
        public static void SetTituloPagina(string encabezado)
        {
            var myPage = (Page)HttpContext.Current.Handler;
            var myMaster = (SiteMaster)myPage?.Master;
            if (myMaster == null) return;
            myMaster.lblTituloPagina.Text = encabezado;
        }

        /// <summary>
        /// Método que muestra los mensajes popup para dar información al usuario que realiza una transacción en el sistema.
        /// </summary>
        /// <param name="tipoMensaje"></param>
        /// <param name="mensaje"></param>
        /// <param name="footer"></param>
        public static void MostrarMensaje(TipoMensaje tipoMensaje, string mensaje, string footer = "")
        {
            switch (HttpContext.Current.Handler)
            {
                case Page myPage:
                    {
                        var myMaster = (SiteMaster)myPage.Master;
                        if (myMaster == null) return;
                        myMaster.lblMsj.Text = mensaje;
                        if (!string.IsNullOrEmpty(footer))
                        {
                            myMaster.popupMSJ.ShowFooter = true;
                            myMaster.popupMSJ.FooterText = footer;
                        }
                        else
                            myMaster.popupMSJ.FooterText = "";

                        switch (tipoMensaje)
                        {
                            case TipoMensaje.Excepcion:
                                myMaster.popupMSJ.HeaderText = "Error";
                                myMaster.imgIcono.ImageUrl = "~/Recursos/error.png";
                                myMaster.btnCancelar.Visible = false;
                                myMaster.btnContinuar.Visible = false;

                                break;
                            case TipoMensaje.Informacion:
                                myMaster.popupMSJ.HeaderText = @"Información";
                                myMaster.imgIcono.ImageUrl = "~/Recursos/informacion.png";
                                myMaster.btnCancelar.Visible = false;
                                myMaster.btnContinuar.Visible = false;

                                break;
                            case TipoMensaje.Exito:
                                myMaster.popupMSJ.HeaderText = @"Completado";
                                myMaster.imgIcono.ImageUrl = "~/Recursos/completado.png";
                                myMaster.btnCancelar.Visible = false;
                                myMaster.btnContinuar.Visible = false;

                                break;
                            case TipoMensaje.Atencion:
                                myMaster.popupMSJ.HeaderText = @"Atención";
                                myMaster.imgIcono.ImageUrl = "~/Recursos/atencion.png";
                                myMaster.btnCancelar.Visible = false;
                                myMaster.btnContinuar.Visible = false;
                                break;
                            case TipoMensaje.Interrogacion:
                                myMaster.popupMSJ.HeaderText = @"Confirmación";
                                myMaster.imgIcono.ImageUrl = "~/Recursos/Decision.png";
                                myMaster.btnCancelar.Visible = true;
                                myMaster.btnContinuar.Visible = true;
                                break;
                        }
                        myMaster.popupMSJ.ShowOnPageLoad = true;
                        break;
                    }
            }
        }

        /// <summary>
        /// Método estático que arma la URL que se presenta en el navegador
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string prepararUrl(string url)
        {
            var ultimoCaracter = url.Substring(url.Length - 1);
            return ultimoCaracter == "/" ? url.Substring(0, url.Length - 1) : url;
        }

        /// <summary>
        /// Método que genera el menú mostrado en pantalla desde la Base de Datos
        /// </summary>
        private void GenerarMenuDinamico()
        {
            try
            {
                var strHtml = new StringBuilder();
                if (Session["vsMenuGenerado"] != null)
                {
                    strHtml.Append(Session["vsMenuGenerado"]);
                }
                else
                {
                    var rolId = Convert.ToInt32(Session["vsRolId"]);
                    var modulosPorRolId = ModulosLN.ObtenerModulosPorRolId(rolId);
                    var accionesPorRol = RolModuloAccionesLN.ObtenerAccionesPorRol(rolId, true);
                    var urlBase = prepararUrl(Request.ApplicationPath);

                    strHtml.Append(string.Format(
                        $@"<li class='active'><a href='{urlBase}/'><i class='fa fa-desktop'></i><span>Inicio</span></a></li>"));

                    if (modulosPorRolId != null)
                    {
                        foreach (var modulo in modulosPorRolId)
                        {
                            var objetoPrimerNivel = accionesPorRol.Where(x =>
                                x.ModuloId == modulo.ModuloId && x.ModuloPadre == 0 && x.EsMenu);
                            if (objetoPrimerNivel != null)
                            {
                                strHtml.Append(string.Format(
                                    $"<li class='cd-dropdown'><a href='#' class='dropdown-toggle' data-toggle='dropdown'><i class='{modulo.ClaseCss}'></i><span>{modulo.Nombre}</span></a><ul class='dropdown-menu'>"));
                                foreach (var objetoSegundoNivel in objetoPrimerNivel)
                                {
                                    strHtml.Append(string.Format($"<li><a href='{urlBase}/{objetoSegundoNivel.Enlace}'>{objetoSegundoNivel.ModuloAccionNombre}</a></li>"));
                                }
                                strHtml.Append("</ul></li>");
                            }
                        }
                    }
                }
                menuPrincipal.InnerHtml = strHtml.ToString();
                Session["vsMenuGenerado"] = menuPrincipal.InnerHtml;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnCancelar_OnClick(object sender, EventArgs e)
        {
            popupMSJ.ShowOnPageLoad = false;
        }

        protected void btnContinuar_OnClick(object sender, EventArgs e)
        {
            var valorId = Convert.ToInt32(Session["vsRegistroIdEliminar"]);
            var entidadEliminar = Session["vsRegistroEliminar"];
            if (!EliminarRegistro(entidadEliminar, valorId) || Request.UrlReferrer == null) return;
            var formularioRecargar = Request.AppRelativeCurrentExecutionFilePath;
            if (formularioRecargar != null) Response.Redirect(formularioRecargar);
        }

        /// <summary>
        /// Método genérico de tipo booleano que recibe un tipo de entidad y un valorId de entidad con lo que realiza la eliminación de cualquier entidad de la Base de Datos
        /// </summary>
        /// <param name="entidadEliminar"></param>
        /// <param name="valorId"></param>
        /// <returns></returns>
        private bool EliminarRegistro(object entidadEliminar, int valorId)
        {
            try
            {
                var objeto = entidadEliminar.IfNotNull(x => x.GetType());
                var resultadoRegistroEliminar = false;

                if (objeto.BaseType != null)
                {
                    var nombreEntidad = objeto.BaseType.Name;
                    var nombreCampoId = GenericosLN.ObtenerCampoId(nombreEntidad);
                    var nombreTablaBd = GenericosLN.ObtenerNombreTablaBd(nombreEntidad);


                    if (!string.IsNullOrWhiteSpace(nombreCampoId))
                    {
                        resultadoRegistroEliminar = GenericosLN.EliminarEntidad(nombreTablaBd, nombreCampoId, valorId);

                        switch (resultadoRegistroEliminar)
                        {
                            case false:
                                MostrarMensaje(TipoMensaje.Excepcion,
                                    "Hubo un problema, el registro no pudo ser eliminado de la Base de Datos.",
                                    $"Gestión de {nombreEntidad}");
                                break;
                            case true:
                                MostrarMensaje(TipoMensaje.Exito,
                                    "Enhorabuena, el resgistro fue eliminado exitosamente.",
                                    $"Gestión de {nombreEntidad}");
                                break;
                        }
                    }
                }

                return resultadoRegistroEliminar;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}