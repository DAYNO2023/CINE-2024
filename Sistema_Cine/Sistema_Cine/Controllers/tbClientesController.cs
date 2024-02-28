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
    public class tbClientesController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbClientes
        public ActionResult Index()
        {
            var tbClientes = db.tbClientes.Include(t => t.tbEstado_Civil).Include(t => t.tbMunicipio);
            return View(tbClientes.ToList());
        }

        // GET: tbClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbClientes tbClientes = db.tbClientes.Find(id);
            if (tbClientes == null)
            {
                return HttpNotFound();
            }
            return View(tbClientes);
        }

        // GET: tbClientes/Create
        public ActionResult Create()
        {
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion");
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion");
            return View();
        }

        // POST: tbClientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clie_Id,Clie_Nombre,Clie_Apellido,Clie_Identidad,Clie_Sexo,Clie_Telefono,Esta_Id,Clie_FecNacimiento,Muni_Id,Clie_Usua_Creacion,Clie_Fecha_Creacion,Clie_Usua_Modifica,Clie_Fecha_Modifica,Clie_Estado")] tbClientes tbClientes)
        {
            if (ModelState.IsValid)
            {
                db.tbClientes.Add(tbClientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion", tbClientes.Esta_Id);
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbClientes.Muni_Id);
            return View(tbClientes);
        }

        // GET: tbClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbClientes tbClientes = db.tbClientes.Find(id);
            if (tbClientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion", tbClientes.Esta_Id);
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbClientes.Muni_Id);
            return View(tbClientes);
        }

        // POST: tbClientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clie_Id,Clie_Nombre,Clie_Apellido,Clie_Identidad,Clie_Sexo,Clie_Telefono,Esta_Id,Clie_FecNacimiento,Muni_Id,Clie_Usua_Creacion,Clie_Fecha_Creacion,Clie_Usua_Modifica,Clie_Fecha_Modifica,Clie_Estado")] tbClientes tbClientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbClientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion", tbClientes.Esta_Id);
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbClientes.Muni_Id);
            return View(tbClientes);
        }

        // GET: tbClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbClientes tbClientes = db.tbClientes.Find(id);
            if (tbClientes == null)
            {
                return HttpNotFound();
            }
            return View(tbClientes);
        }

        // POST: tbClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbClientes tbClientes = db.tbClientes.Find(id);
            db.tbClientes.Remove(tbClientes);
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
