using System;
using System.Web.UI;

namespace SI_PESPIRE_WEB.Modulos.Seguridad
{
    public partial class wfmConfiguraciones : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) SiteMaster.SetTituloPagina(@"Configuraciones de sistema");
        }
    }
}