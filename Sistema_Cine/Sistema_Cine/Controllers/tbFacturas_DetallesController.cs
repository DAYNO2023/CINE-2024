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
    public class tbFacturas_DetallesController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbFacturas_Detalles
        public ActionResult Index()
        {
            var tbFacturas_Detalles = db.tbFacturas_Detalles.Include(t => t.tbCarteleras).Include(t => t.tbFacturas_Encabezados);
            return View(tbFacturas_Detalles.ToList());
        }

        // GET: tbFacturas_Detalles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFacturas_Detalles tbFacturas_Detalles = db.tbFacturas_Detalles.Find(id);
            if (tbFacturas_Detalles == null)
            {
                return HttpNotFound();
            }
            return View(tbFacturas_Detalles);
        }

        // GET: tbFacturas_Detalles/Create
        public ActionResult Create()
        {
            ViewBag.Cart_Id = new SelectList(db.tbCarteleras, "Cart_Id", "Cart_Descripcion");
            ViewBag.Fact_Id = new SelectList(db.tbFacturas_Encabezados, "Fact_Id", "Fact_Id");
            ViewBag.facturacionencabezadoList = db.tbFacturas_Encabezados.Include(t => t.tbPromociones).Include(t => t.tbClientes).Include(t => t.tbEmpleados).Include(t => t.tbTipo_Pagos).ToList();
            return View();
        }

        // POST: tbFacturas_Detalles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fade_Id,Fact_Id,Cart_Id,Fade_ticket,Fade_Usua_Creacion,Fade_Fecha_Creacion,Fade_Usua_Modifica,Fade_Fecha_Modificacion,Fade_Estado")] tbFacturas_Detalles tbFacturas_Detalles)
        {
            if (ModelState.IsValid)
            {
                db.tbFacturas_Detalles.Add(tbFacturas_Detalles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cart_Id = new SelectList(db.tbCarteleras, "Cart_Id", "Cart_Descripcion", tbFacturas_Detalles.Cart_Id);
            ViewBag.Fact_Id = new SelectList(db.tbFacturas_Encabezados, "Fact_Id", "Fact_Id", tbFacturas_Detalles.Fact_Id);
            return View(tbFacturas_Detalles);
        }

        // GET: tbFacturas_Detalles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFacturas_Detalles tbFacturas_Detalles = db.tbFacturas_Detalles.Find(id);
            if (tbFacturas_Detalles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cart_Id = new SelectList(db.tbCarteleras, "Cart_Id", "Cart_Descripcion", tbFacturas_Detalles.Cart_Id);
            ViewBag.Fact_Id = new SelectList(db.tbFacturas_Encabezados, "Fact_Id", "Fact_Id", tbFacturas_Detalles.Fact_Id);
            return View(tbFacturas_Detalles);
        }

        // POST: tbFacturas_Detalles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fade_Id,Fact_Id,Cart_Id,Fade_ticket,Fade_Usua_Creacion,Fade_Fecha_Creacion,Fade_Usua_Modifica,Fade_Fecha_Modificacion,Fade_Estado")] tbFacturas_Detalles tbFacturas_Detalles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbFacturas_Detalles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cart_Id = new SelectList(db.tbCarteleras, "Cart_Id", "Cart_Descripcion", tbFacturas_Detalles.Cart_Id);
            ViewBag.Fact_Id = new SelectList(db.tbFacturas_Encabezados, "Fact_Id", "Fact_Id", tbFacturas_Detalles.Fact_Id);
            return View(tbFacturas_Detalles);
        }

        // GET: tbFacturas_Detalles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFacturas_Detalles tbFacturas_Detalles = db.tbFacturas_Detalles.Find(id);
            if (tbFacturas_Detalles == null)
            {
                return HttpNotFound();
            }
            return View(tbFacturas_Detalles);
        }

        // POST: tbFacturas_Detalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbFacturas_Detalles tbFacturas_Detalles = db.tbFacturas_Detalles.Find(id);
            db.tbFacturas_Detalles.Remove(tbFacturas_Detalles);
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
