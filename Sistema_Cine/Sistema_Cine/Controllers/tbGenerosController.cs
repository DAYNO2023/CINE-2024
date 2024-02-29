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
    public class tbGenerosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbGeneros
        public ActionResult Index()
        {
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion");
            var tbGeneros = db.tbGeneros.Include(t => t.tbPromociones);
            return View(tbGeneros.ToList());
        }

        // GET: tbGeneros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGeneros tbGeneros = db.tbGeneros.Find(id);
            if (tbGeneros == null)
            {
                return HttpNotFound();
            }
            return View(tbGeneros);
        }

        // GET: tbGeneros/Create
        public ActionResult Create()
        {
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion");
            return View();
        }

        // POST: tbGeneros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Gene_Id,Gene_Descripcion,Prom_Id,Gene_Usuario_Creacion,Gene_Fecha_Creacion,Gene_Usuario_Modificacion,Gene_Fecha_Modificacion")] tbGeneros tbGeneros)
        {
            if (ModelState.IsValid)
            {
                db.tbGeneros.Add(tbGeneros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbGeneros.Prom_Id);
            return View(tbGeneros);
        }

        // GET: tbGeneros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGeneros tbGeneros = db.tbGeneros.Find(id);
            if (tbGeneros == null)
            {
                return HttpNotFound();
            }
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbGeneros.Prom_Id);
            return View(tbGeneros);
        }

        // POST: tbGeneros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Gene_Id,Gene_Descripcion,Prom_Id,Gene_Usuario_Creacion,Gene_Fecha_Creacion,Gene_Usuario_Modificacion,Gene_Fecha_Modificacion")] tbGeneros tbGeneros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbGeneros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbGeneros.Prom_Id);
            return View(tbGeneros);
        }

        // GET: tbGeneros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbGeneros tbGeneros = db.tbGeneros.Find(id);
            if (tbGeneros == null)
            {
                return HttpNotFound();
            }
            return View(tbGeneros);
        }

        // POST: tbGeneros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbGeneros tbGeneros = db.tbGeneros.Find(id);
            db.tbGeneros.Remove(tbGeneros);
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
