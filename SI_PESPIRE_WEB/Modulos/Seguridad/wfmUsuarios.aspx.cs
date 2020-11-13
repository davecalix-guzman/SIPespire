using System;
using System.Web.UI;

namespace SI_PESPIRE_WEB.Modulos.Seguridad
{
    public partial class wfmUsuarios : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) SiteMaster.SetTituloPagina(@"Usuarios del sistema");
        }
    }
}