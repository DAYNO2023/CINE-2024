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
    public class tbUsuariosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbUsuarios
        public ActionResult Index()
        {
            ViewBag.Paro_Id = new SelectList(db.tbPantalla_Roles, "Role_Id", "Role_Id");
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre");
            var tbUsuarios = db.tbUsuarios.Include(t => t.tbRoles).Include(t => t.tbEmpleados);
            return View(tbUsuarios.ToList());
        }

        // GET: tbUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            if (tbUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuarios);
        }

        // GET: tbUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.Role_Id = new SelectList(db.tbRoles, "Role_Id", "Role_Id");
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre");
            return View();
        }

        // POST: tbUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usua_Id,Usua_Nombre,Usua_Contraseña,Empl_Id,Role_Id,Usua_Creacion,Usua_Fecha_Creacion,Usua_Modifica,Usua_Fecha_Modifica,Usua_Estado")] tbUsuarios tbUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.tbUsuarios.Add(tbUsuarios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Paro_Id = new SelectList(db.tbPantalla_Roles, "Role_Id", "Role_Id", tbUsuarios.Role_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbUsuarios.Empl_Id);
            return View(tbUsuarios);
        }

        // GET: tbUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            if (tbUsuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.Paro_Id = new SelectList(db.tbPantalla_Roles, "Role_Id", "Role_Id", tbUsuarios.Role_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbUsuarios.Empl_Id);
            return View(tbUsuarios);
        }

        // POST: tbUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usua_Id,Usua_Nombre,Usua_Contraseña,Empl_Id,Role_Id,Usua_Creacion,Usua_Fecha_Creacion,Usua_Modifica,Usua_Fecha_Modifica,Usua_Estado")] tbUsuarios tbUsuarios)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Paro_Id = new SelectList(db.tbPantalla_Roles, "Role_Id", "Role_Id", tbUsuarios.Role_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbUsuarios.Empl_Id);
            return View(tbUsuarios);
        }

        // GET: tbUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            if (tbUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(tbUsuarios);
        }

        // POST: tbUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbUsuarios tbUsuarios = db.tbUsuarios.Find(id);
            db.tbUsuarios.Remove(tbUsuarios);
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
