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
    public class tbEntradasController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbEntradas
        public ActionResult Index()
        {
            ViewBag.Sala_Id = new SelectList(db.tbSalas, "Sala_Id", "Sala_Descripcion");
            var tbEntradas = db.tbEntradas.Include(t => t.tbSalas);
            return View(tbEntradas.ToList());
        }

        // GET: tbEntradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEntradas tbEntradas = db.tbEntradas.Find(id);
            if (tbEntradas == null)
            {
                return HttpNotFound();
            }
            return View(tbEntradas);
        }

        // GET: tbEntradas/Create
        public ActionResult Create()
        {
            ViewBag.Sala_Id = new SelectList(db.tbSalas, "Sala_Id", "Sala_Descripcion");
            return View();
        }

        // POST: tbEntradas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Entra_Id,Entra_Cantidad,Sala_Id,Entra_Usuario_Creacion,Entra_Fecha_Creacion,Entra_Usuario_Modificacion,Entra_Fecha_Modificacion")] tbEntradas tbEntradas)
        {
            if (ModelState.IsValid)
            {
                db.tbEntradas.Add(tbEntradas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Sala_Id = new SelectList(db.tbSalas, "Sala_Id", "Sala_Descripcion", tbEntradas.Sala_Id);
            return View(tbEntradas);
        }

        // GET: tbEntradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEntradas tbEntradas = db.tbEntradas.Find(id);
            if (tbEntradas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Sala_Id = new SelectList(db.tbSalas, "Sala_Id", "Sala_Descripcion", tbEntradas.Sala_Id);
            return View(tbEntradas);
        }

        // POST: tbEntradas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Entra_Id,Entra_Cantidad,Sala_Id,Entra_Usuario_Creacion,Entra_Fecha_Creacion,Entra_Usuario_Modificacion,Entra_Fecha_Modificacion")] tbEntradas tbEntradas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEntradas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Sala_Id = new SelectList(db.tbSalas, "Sala_Id", "Sala_Descripcion", tbEntradas.Sala_Id);
            return View(tbEntradas);
        }

        // GET: tbEntradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEntradas tbEntradas = db.tbEntradas.Find(id);
            if (tbEntradas == null)
            {
                return HttpNotFound();
            }
            return View(tbEntradas);
        }

        // POST: tbEntradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbEntradas tbEntradas = db.tbEntradas.Find(id);
            db.tbEntradas.Remove(tbEntradas);
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
