using SI_PESPIRE_WEB.LibreriaWEB;
using System;
using System.Web.UI;

namespace SI_PESPIRE_WEB
{
    public partial class _Default : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ValidarAccesos();
            if (!Page.IsPostBack)
            {
                SiteMaster.SetTituloPagina("Inicio");
            }
            lblDiaNumero.Text = DateTime.Now.ToString("dd");
            lblDiaLetras.Text = DateTime.Now.ToString("dddd").ToUpper();
            lblFecha.Text = DateTime.Now.ToString("MMMM, yyyy").ToUpper();
            lblUsuario.Text = Session["vsUsuarioNombre"].ToString().ToUpper();
            lblNombreUsuario.Text = Session["vsUsuarioNombreCompleto"].ToString().ToUpper();
            lblRol.Text = Session["vsRolNombre"].ToString().ToUpper();
            lblOficina.Text = Session["vsOficinaNombre"].ToString().ToUpper();
        }

        private void ValidarAccesos()
        {
            var usuarioId = Session["vsUsuarioId"];
            if (usuarioId  == null)
            {
                Response.Redirect("~/Registro/Login");
            }
        }
    }
}