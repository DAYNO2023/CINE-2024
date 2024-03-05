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
    public class tbRolesController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbRoles
        public ActionResult Index()
        {
            return View(db.tbRoles.ToList());
        }

        // GET: tbRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRoles tbRoles = db.tbRoles.Find(id);
            if (tbRoles == null)
            {
                return HttpNotFound();
            }
            return View(tbRoles);
        }

        // GET: tbRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbRoles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Role_Id,Role_Descripcion,Role_Creacion,Role_Fecha_Creacion,Role_Modifica,Role_Fecha_Modifica,Role_Estado")] tbRoles tbRoles)
        {
            if (ModelState.IsValid)
            {
                db.tbRoles.Add(tbRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbRoles);
        }

        // GET: tbRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRoles tbRoles = db.tbRoles.Find(id);
            if (tbRoles == null)
            {
                return HttpNotFound();
            }
            return View(tbRoles);
        }

        // POST: tbRoles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Role_Id,Role_Descripcion,Role_Creacion,Role_Fecha_Creacion,Role_Modifica,Role_Fecha_Modifica,Role_Estado")] tbRoles tbRoles)
        {
            if (ModelState.IsValid)
            {

                int id = Convert.ToInt32(Session["idtipo"]);
                var rolesexistenete = db.tbRoles.Find(id);

                if (rolesexistenete != null)
                {
                    db.Entry(rolesexistenete).Reload();
                    rolesexistenete.Role_Descripcion = tbRoles.Role_Descripcion;


                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(tbRoles);
        }

        // GET: tbRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRoles tbRoles = db.tbRoles.Find(id);
            if (tbRoles == null)
            {
                return HttpNotFound();
            }
            return View(tbRoles);
        }

        // POST: tbRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbRoles tbRoles = db.tbRoles.Find(id);
            db.tbRoles.Remove(tbRoles);
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
