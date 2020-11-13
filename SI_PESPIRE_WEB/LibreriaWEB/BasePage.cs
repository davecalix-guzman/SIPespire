using System;
using System.Web.UI;

namespace SI_PESPIRE_WEB.LibreriaWEB
{
    public class BasePage : Page
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            Response.AddHeader("Refresh", Convert.ToString(Session.Timeout * 60 + 5));
            switch (Session["vsUsuarioId"])
            {
                case null:
                    Response.Redirect("~/Registro/Login");
                    break;
            }
        }
    }
}