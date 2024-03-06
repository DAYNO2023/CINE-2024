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
            if (ModelState.IsValid)
            {
                db.tbPromociones.Add(tbPromociones);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["idtipo"]);
                var promosionesexistenete = db.tbPromociones.Find(id);

                if (promosionesexistenete != null)
                {
                    db.Entry(promosionesexistenete).Reload();
                    promosionesexistenete.Prom_Descuento = tbPromociones.Prom_Descuento;
                    promosionesexistenete.Prom_Descripcion = tbPromociones.Prom_Descripcion;
                    promosionesexistenete.Prec_Id = tbPromociones.Prec_Id;

                    db.SaveChanges();
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
            tbPromociones tbPromociones = db.tbPromociones.Find(id);
            db.tbPromociones.Remove(tbPromociones);
            db.SaveChanges();
            return RedirectToAction("Index");
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
