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
    public class tbPantallasController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbPantallas
        public ActionResult Index()
        {
            return View(db.tbPantallas.ToList());
        }

        // GET: tbPantallas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPantallas tbPantallas = db.tbPantallas.Find(id);
            if (tbPantallas == null)
            {
                return HttpNotFound();
            }
            return View(tbPantallas);
        }

        // GET: tbPantallas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbPantallas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Pant_Id,Pant_Descripcion,Pant_Identificador,Pant_Creacion,Pant_Fecha_Creacion,Pant_Modifica,Pant_Fecha_Modifica,Pant_Estado")] tbPantallas tbPantallas)
        {
            if (ModelState.IsValid)
            {
                db.tbPantallas.Add(tbPantallas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbPantallas);
        }

        // GET: tbPantallas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPantallas tbPantallas = db.tbPantallas.Find(id);
            if (tbPantallas == null)
            {
                return HttpNotFound();
            }
            return View(tbPantallas);
        }

        // POST: tbPantallas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Pant_Id,Pant_Descripcion,Pant_Identificador,Pant_Creacion,Pant_Fecha_Creacion,Pant_Modifica,Pant_Fecha_Modifica,Pant_Estado")] tbPantallas tbPantallas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPantallas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbPantallas);
        }

        // GET: tbPantallas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPantallas tbPantallas = db.tbPantallas.Find(id);
            if (tbPantallas == null)
            {
                return HttpNotFound();
            }
            return View(tbPantallas);
        }

        // POST: tbPantallas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPantallas tbPantallas = db.tbPantallas.Find(id);
            db.tbPantallas.Remove(tbPantallas);
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
