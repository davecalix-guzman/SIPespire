using SI_PESPIRE_WEB.LibreriaWEB;
using System;

namespace SI_PESPIRE_WEB.Modulos.Registro
{
    public partial class wfmPerfil : BasePage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!Page.IsPostBack) SiteMaster.SetTituloPagina("Perfil de usuario");
        }
    }
}