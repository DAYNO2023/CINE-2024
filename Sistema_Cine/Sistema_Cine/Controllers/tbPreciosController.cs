using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Cine.Models;
using Sistema_Cine.ValidarSession;

namespace Sistema_Cine.Controllers
{
    [ValidarSesion]
    [ValidarSesionprecio]
    public class tbPreciosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbPrecios
        public ActionResult Index()
        {
            return View(db.tbPrecios.ToList());
        }

        // GET: tbPrecios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPrecios tbPrecios = db.tbPrecios.Find(id);
            if (tbPrecios == null)
            {
                return HttpNotFound();
            }
            return View(tbPrecios);
        }

        // GET: tbPrecios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbPrecios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prec_Id,Prec_Descripcion,Prec_Usuario_Creacion,Prec_Fecha_Creacion,Prec_Usuario_Modificacion,Prec_Fecha_Modificacion")] tbPrecios tbPrecios)
        {

            ModelState.Remove("Prec_Usuario_Creacion");
            ModelState.Remove("Prec_Fecha_Creacion");
            ModelState.Remove("Prec_Usuario_Modificacion");
            ModelState.Remove("Prec_Fecha_Modificacion");


            if (ModelState.IsValid)
            {
                try
                {
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbPrecios_Insertar(tbPrecios.Prec_Descripcion, usuario, DateTime.Now, true);
                    // db.tbPrecios.Add(tbPrecios);
                    db.SaveChanges();
                    TempData["Exito"] = "Se agregó correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    TempData["Error"] = "Error: El registro no se guardó correctamente debido a un formato incorrecto. Detalles del error: " + ex.Message;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Error: Ocurrió un error al guardar el registro. Detalles del error: " + ex.Message;
                    return RedirectToAction("Index");
                }

            }

            return View(tbPrecios);
        }

        // GET: tbPrecios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPrecios tbPrecios = db.tbPrecios.Find(id);
            if (tbPrecios == null)
            {
                return HttpNotFound();
            }
            return View(tbPrecios);
        }

        // POST: tbPrecios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Prec_Id,Prec_Descripcion,Prec_Usuario_Creacion,Prec_Fecha_Creacion,Prec_Usuario_Modificacion,Prec_Fecha_Modificacion")] tbPrecios tbPrecios)
        {
            ModelState.Remove("Prec_Usuario_Creacion");
            ModelState.Remove("Prec_Fecha_Creacion");
            ModelState.Remove("Prec_Usuario_Modificacion");
            ModelState.Remove("Prec_Fecha_Modificacion");
            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["idtipo"]);
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbPrecios_Editar(id, tbPrecios.Prec_Descripcion, usuario, DateTime.Now, true);
                    TempData["Exito"] = "se Edito Correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error este campo no se edito correctamente: " + ex.Message; ;
                    return RedirectToAction("Index");
                }
            }
            return View(tbPrecios);
        }

        // GET: tbPrecios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPrecios tbPrecios = db.tbPrecios.Find(id);
            if (tbPrecios == null)
            {
                return HttpNotFound();
            }
            return View(tbPrecios);
        }

        // POST: tbPrecios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                //db.Sp_tbPrecios_Eliminar(id);
                tbPrecios tbprecios = db.tbPrecios.Find(id);
                db.tbPrecios.Remove(tbprecios);
                db.SaveChanges();
                TempData["Exito"] = "se Elimino Correctamente";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Error el campo no fue eliminado: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
