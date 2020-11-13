using System;
using System.Web.UI;

namespace SI_PESPIRE_WEB.Modulos.GestionVentas
{
    public partial class wfmFacturar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) SiteMaster.SetTituloPagina("Facturar producto");
        }
    }
}