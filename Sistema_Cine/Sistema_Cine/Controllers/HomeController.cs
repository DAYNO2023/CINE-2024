using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Cine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]


        public ActionResult Login(string txtUser,string txtContra)
        {

            //var usuario = procedimientoalmcenado(txtUser, txtContra).tolist();

            //if(Usuari.count > 0)

            //    {
            //        foreach (var iteam in usuario)
            //        {
            //            Session["idusaio"] = iteam.usu_id;
            //            Session["NombreUsuario"] = iteam.DOc_Nombre;
            //        }
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("ErrorLogin", "El Usuario o contraseña son incorrectos");
            //        return view
            return View();
        }
         
    





    public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}