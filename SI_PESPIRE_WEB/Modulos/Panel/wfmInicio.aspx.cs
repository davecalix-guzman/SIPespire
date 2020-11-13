using SI_PESPIRE_WEB.LibreriaWEB;
using System;

namespace SI_PESPIRE_WEB.Modulos.Panel
{
    public partial class wfmInicio : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            ValidarAccesos();
            if (!Page.IsPostBack) SiteMaster.SetTituloPagina("Inicio");
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
            if (Session["vsUsuarioId"] == null) Response.Redirect("~/Registro/Login");
        }
    }
}