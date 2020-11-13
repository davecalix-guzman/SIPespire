using System;
using System.Web.UI;

namespace SI_PESPIRE_WEB.Modulos.Dashboard
{
    public partial class wfmDashboard : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) SiteMaster.SetTituloPagina("Dashboard");
        }
    }
}