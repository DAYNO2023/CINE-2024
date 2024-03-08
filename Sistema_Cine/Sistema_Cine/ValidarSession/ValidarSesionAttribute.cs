using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Cine.ValidarSession
{
    public class ValidarSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var action = filterContext.RouteData.Values["action"].ToString();
            var controller = filterContext.RouteData.Values["controller"].ToString();
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            if (!(controller == "Home" && action == "Login"))
            {
                if (HttpContext.Current.Session["NombreUsuario"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}