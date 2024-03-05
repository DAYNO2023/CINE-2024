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
                if (Session["NombreUsuario"] != null)
                {
                    ViewBag.NombreUsuario = Session["NombreUsuario"].ToString();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CerrarSesion()
        {
            // Eliminar todos los datos de la sesión
            Session.Clear();
            Session.Abandon();

            // Redirigir al usuario a la página de inicio de sesión
            return RedirectToAction("Index", "Home");
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

        public JsonResult obtenerIDbuta(int tipoID)
        {
            var tipo = db.tbButacas_Salas.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Buta_Descripcion }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult obtenerIDCarg(int tipoID)
        {
            var tipo = db.tbCargos.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Carg_Descripcion }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult obtenerIDdepa(string tipoID)
        {
            var tipo = db.tbDepartamentos.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Depa_Descripcion }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult obtenerIDEntra(int tipoID)
        {
            var tipo = db.tbEntradas.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Entra_Cantidad , salas = tipo.Sala_Id }, JsonRequestBehavior.AllowGet);

        }


        public JsonResult obtenerIDMuni(string tipoID)
        {
            var tipo = db.tbMunicipio.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Muni_Descripcion, salas = tipo.Depa_Codigo }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult obtenerIDParo(int tipoID)
        {
            var tipo = db.tbPantalla_Roles.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Pant_Id, roles = tipo.Role_Id }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult obtenerIDPrec(int tipoID)
        {
            var tipo = db.tbPrecios.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Prec_Descripcion }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult obtenerIDProm(int tipoID)
        {
            var tipo = db.tbPromociones.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Prom_Descripcion,descu = tipo.Prom_Descuento,prec = tipo.Prec_Id }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult obtenerIDroles(int tipoID)
        {
            var tipo = db.tbRoles.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Role_Descripcion }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult obtenerIDsalas(int tipoID)
        {
            var tipo = db.tbSalas.Find(tipoID);
            Session["idtipo"] = tipoID;


            return Json(new { success = true, description = tipo.Sala_Descripcion,buta = tipo.Buta_Id }, JsonRequestBehavior.AllowGet);

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