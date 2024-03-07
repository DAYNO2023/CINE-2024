using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Cine.Models;

namespace Sistema_Cine.Controllers
{
    public class tbPromocionesController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbPromociones
        public ActionResult Index()
        {
            ViewBag.Prec_Id = new SelectList(db.tbPrecios, "Prec_Id", "Prec_Id");
            var tbPromociones = db.tbPromociones.Include(t => t.tbPrecios);
            return View(tbPromociones.ToList());
        }

        // GET: tbPromociones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPromociones tbPromociones = db.tbPromociones.Find(id);
            if (tbPromociones == null)
            {
                return HttpNotFound();
            }
            return View(tbPromociones);
        }

        public ActionResult ObtenerPrecioPorDescripcion(int descripcionId)
        {
            // Buscar el precio por el ID de la promoción
            var precio = db.tbPrecios.FirstOrDefault(p => p.Prec_Id == descripcionId);

            if (precio == null)
            {
                return HttpNotFound();
            }

            // Devolver el precio encontrado como JSON
            return Json(new { precio = precio.Prec_Descripcion }, JsonRequestBehavior.AllowGet);
        }



        // GET: tbPromociones/Create
        public ActionResult Create()
        {
            ViewBag.Prec_Id = new SelectList(db.tbPrecios, "Prec_Id", "Prec_Id");
            return View();
        }

        // POST: tbPromociones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prom_Id,Prom_Descuento,Prom_Descripcion,Prec_Id,Prom_Usuario_Creacion,Prom_Fecha_Creacion,Prom_Usuario_Modificacion,Prom_Fecha_Modificacion")] tbPromociones tbPromociones)
        {
            ModelState.Remove("Prom_Usuario_Creacion");
            ModelState.Remove("Prom_Fecha_Creacion");
            ModelState.Remove("Prom_Usuario_Modificacion");
            ModelState.Remove("Prom_Fecha_Modificacion");


            if (ModelState.IsValid)
            {
                try
                {
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbPromociones_Insertar(tbPromociones.Prom_Descuento, tbPromociones.Prom_Descripcion, tbPromociones.Prec_Id, usuario, DateTime.Now, true);
                    //db.tbPromociones.Add(tbPromociones);
                    db.SaveChanges();
                    TempData["Exito"] = "se agrego Correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error el registro no se guardo correctamente: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Prec_Id = new SelectList(db.tbPrecios, "Prec_Id", "Prec_Id", tbPromociones.Prec_Id);
            return View(tbPromociones);
        }

        // GET: tbPromociones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPromociones tbPromociones = db.tbPromociones.Find(id);
            if (tbPromociones == null)
            {
                return HttpNotFound();
            }
            ViewBag.Prec_Id = new SelectList(db.tbPrecios, "Prec_Id", "Prec_Id", tbPromociones.Prec_Id);
            return View(tbPromociones);
        }

        // POST: tbPromociones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Prom_Id,Prom_Descuento,Prom_Descripcion,Prec_Id,Prom_Usuario_Creacion,Prom_Fecha_Creacion,Prom_Usuario_Modificacion,Prom_Fecha_Modificacion")] tbPromociones tbPromociones)
        {
            ModelState.Remove("Prom_Usuario_Creacion");
            ModelState.Remove("Prom_Fecha_Creacion");
            ModelState.Remove("Prom_Usuario_Modificacion");
            ModelState.Remove("Prom_Fecha_Modificacion");

            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["idtipo"]);
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbPromociones_Editar(id, tbPromociones.Prom_Descuento, tbPromociones.Prom_Descripcion, tbPromociones.Prec_Id, usuario, DateTime.Now, true);
                    TempData["Exito"] = "se Edito Correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error este campo no se edito correctamente: " + ex.Message;
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Prec_Id = new SelectList(db.tbPrecios, "Prec_Id", "Prec_Id", tbPromociones.Prec_Id);
            return View(tbPromociones);
        }

        // GET: tbPromociones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPromociones tbPromociones = db.tbPromociones.Find(id);
            if (tbPromociones == null)
            {
                return HttpNotFound();
            }
            return View(tbPromociones);
        }

        // POST: tbPromociones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbPromociones tbPromociones = db.tbPromociones.Find(id);
                db.tbPromociones.Remove(tbPromociones);
                //db.Sp_tbPromociones_Eliminar(id);
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
