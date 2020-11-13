using Microsoft.AspNet.FriendlyUrls;
using System.Web.Routing;

namespace SI_PESPIRE_WEB
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.Ignore("{resource}.axd/{*pathInfo}");
            routes.Ignore("{resource}.ashx/{*pathInfo}");

            routes.MapPageRoute("", "", "~/Modulos/panel/wfmInicio.aspx");
            routes.MapPageRoute("", "{modulo}", "~/Modulos/{modulo}/wfmInicio.aspx");
            routes.MapPageRoute("", "{modulo}/{accion}", "~/Modulos/{modulo}/wfm{accion}.aspx");
            routes.MapPageRoute("", "{modulo}/{accion}/{id}", "~/Modulos/{modulo}/wfm{accion}.aspx");
            routes.MapPageRoute("", "{modulo}/view/{vista}", "~/Modulos/{modulo}/{vista}/wfmInicio.aspx");
            routes.MapPageRoute("", "{modulo}/view/{vista}/{accion}", "~/Modulos/{modulo}/{vista}/wfm{accion}.aspx");
            routes.MapPageRoute("", "{modulo}/view/{vista}/{accion}/{id}", "~/Modulos/{modulo}/{vista}/wfm{accion}.aspx");
        }
    }
}
