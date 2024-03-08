using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Cine.ValidarSession
{
    public class ValidarSesiontipopagocs : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var action = filterContext.RouteData.Values["Action"].ToString();
            var controller = filterContext.RouteData.Values["controller"].ToString();
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            if (!(controller == "Home" && action == "Login"))
            {
                var pantalla = HttpContext.Current.Session["Pantallas"] as List<string>;
                var admin = HttpContext.Current.Session["Admin"] as List<string>;

                if (pantalla != null && pantalla.Contains("Tipo_Pago") || admin != null && admin.Contains("si"))
                {

                }
                else
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}