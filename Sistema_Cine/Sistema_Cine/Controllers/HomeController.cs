using Sistema_Cine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Cine.Controllers
{
    public class HomeController : Controller

    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtUser, string txtContra)
        {

            var usuario = db.SP_tbUsuarios_InicioSesion(txtUser, txtContra).ToList();

            if (usuario.Count > 0)

            {
                foreach (var iteam in usuario)
                {
                    Session["idusaio"] = iteam.Usua_Id;
                    Session["NombreUsuario"] = iteam.Usua_Nombre;
                }
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("ErrorLogin", "El Usuario o contraseña son incorrectos");
                return View();
            }
        //return View();
    }
        public JsonResult obtenerID(int tipoID)
        {
            var tipo = db.tbTipo_Pagos.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Tipo_Descripcion }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult obtenerIDgen(int tipoID)
        {
            var tipo = db.tbGeneros.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Gene_Descripcion, promo = tipo.Prom_Id }, JsonRequestBehavior.AllowGet);

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