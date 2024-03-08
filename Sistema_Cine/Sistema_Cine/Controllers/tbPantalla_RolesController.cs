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
    public class tbPantalla_RolesController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbPantalla_Roles
        //public ActionResult GetPantallasByRol(int roleId)
        //{
        //    var pantallasAsociadas = db.tbPantalla_Roles
        //        .Where(pr => pr.Role_Id == roleId)
        //        .Select(pr => pr.tbPantallas)
        //        .ToList();

        //    return PartialView("_PantallasAsociadas", pantallasAsociadas);
        //}
        
        public ActionResult Index()
        {
            ViewBag.Pant_Id = new SelectList(db.tbPantallas, "Pant_Id", "Pant_Descripcion");
            ViewBag.Role_Id = new SelectList(db.tbRoles, "Role_Id", "Role_Descripcion");
            var tbPantalla_Roles = db.tbPantalla_Roles.Include(t => t.tbPantallas).Include(t => t.tbRoles);
            return View(tbPantalla_Roles.ToList());
        }

        // GET: tbPantalla_Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPantalla_Roles tbPantalla_Roles = db.tbPantalla_Roles.Find(id);
            if (tbPantalla_Roles == null)
            {
                return HttpNotFound();
            }
            return View(tbPantalla_Roles);
        }

        // GET: tbPantalla_Roles/Create
        public ActionResult Create()
        {
            ViewBag.Pant_Id = new SelectList(db.tbPantallas, "Pant_Id", "Pant_Descripcion");
            ViewBag.Role_Id = new SelectList(db.tbRoles, "Role_Id", "Role_Descripcion");
            return View();
        }

        // POST: tbPantalla_Roles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Paro_Id,Role_Id,Pant_Id,Pant_Creacion,Pant_Fecha_Creacion,Pant_Modifica,Pant_Fecha_Modifica,Pant_Estado")] tbPantalla_Roles tbPantalla_Roles)
        {
            if (ModelState.IsValid)
            {
                db.tbPantalla_Roles.Add(tbPantalla_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pant_Id = new SelectList(db.tbPantallas, "Pant_Id", "Pant_Descripcion", tbPantalla_Roles.Pant_Id);
            ViewBag.Role_Id = new SelectList(db.tbRoles, "Role_Id", "Role_Descripcion", tbPantalla_Roles.Role_Id);
            return View(tbPantalla_Roles);
        }

        // GET: tbPantalla_Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPantalla_Roles tbPantalla_Roles = db.tbPantalla_Roles.Find(id);
            if (tbPantalla_Roles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pant_Id = new SelectList(db.tbPantallas, "Pant_Id", "Pant_Descripcion", tbPantalla_Roles.Pant_Id);
            ViewBag.Role_Id = new SelectList(db.tbRoles, "Role_Id", "Role_Descripcion", tbPantalla_Roles.Role_Id);
            return View(tbPantalla_Roles);
        }

        // POST: tbPantalla_Roles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Paro_Id,Role_Id,Pant_Id,Pant_Creacion,Pant_Fecha_Creacion,Pant_Modifica,Pant_Fecha_Modifica,Pant_Estado")] tbPantalla_Roles tbPantalla_Roles)
        {
            if (ModelState.IsValid)
            {

                int id = Convert.ToInt32(Session["idtipo"]);
                var paroexistenete = db.tbPantalla_Roles.Find(id);

                if (paroexistenete != null)
                {
                    db.Entry(paroexistenete).Reload();
                    paroexistenete.Role_Id = tbPantalla_Roles.Role_Id;
                    paroexistenete.Pant_Id = tbPantalla_Roles.Pant_Id;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            ViewBag.Pant_Id = new SelectList(db.tbPantallas, "Pant_Id", "Pant_Descripcion", tbPantalla_Roles.Pant_Id);
            ViewBag.Role_Id = new SelectList(db.tbRoles, "Role_Id", "Role_Descripcion", tbPantalla_Roles.Role_Id);
            return View(tbPantalla_Roles);
        }

        // GET: tbPantalla_Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPantalla_Roles tbPantalla_Roles = db.tbPantalla_Roles.Find(id);
            if (tbPantalla_Roles == null)
            {
                return HttpNotFound();
            }
            return View(tbPantalla_Roles);
        }

        // POST: tbPantalla_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPantalla_Roles tbPantalla_Roles = db.tbPantalla_Roles.Find(id);
            db.tbPantalla_Roles.Remove(tbPantalla_Roles);
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
