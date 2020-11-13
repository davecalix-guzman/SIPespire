using System;
using System.Web.UI;

namespace SI_PESPIRE_WEB.Modulos.Reportes
{
    public partial class wfmReporteInventario : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) SiteMaster.SetTituloPagina("Reporte de inventarios");
        }
    }
}