﻿using System;
using System.Web.UI;

namespace SI_PESPIRE_WEB.Modulos.Mantenimientos
{
    public partial class wfmMunicipios : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) SiteMaster.SetTituloPagina("Municipios");
        }
    }
}