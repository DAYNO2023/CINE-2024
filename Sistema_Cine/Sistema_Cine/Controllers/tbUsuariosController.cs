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
            ViewBag.Paro_Id = new SelectList(db.tbPantalla_Roles, "Paro_Id", "Paro_Id");
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre");
            var tbUsuarios = db.tbUsuarios.Include(t => t.tbPantalla_Roles).Include(t => t.tbEmpleados);
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
            ViewBag.Paro_Id = new SelectList(db.tbPantalla_Roles, "Paro_Id", "Paro_Id");
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre");
            return View();
        }

        // POST: tbUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Usua_Id,Usua_Nombre,Usua_Contraseña,Empl_Id,Paro_Id,Usua_Creacion,Usua_Fecha_Creacion,Usua_Modifica,Usua_Fecha_Modifica,Usua_Estado")] tbUsuarios tbUsuarios)
        {
            ModelState.Remove("Usua_Creacion");
            ModelState.Remove("Usua_Fecha_Creacion");
            ModelState.Remove("Usua_Modifica");
            ModelState.Remove("Usua_Fecha_Modifica");


            if (ModelState.IsValid)
            {
                try
                {
                    db.Sp_tbUsuarios_Insertar(tbUsuarios.Usua_Nombre, tbUsuarios.Usua_Contraseña, tbUsuarios.Empl_Id, tbUsuarios.Paro_Id, tbUsuarios.Usua_Creacion, DateTime.Now, tbUsuarios.Usua_Estado);
                    //db.tbUsuarios.Add(tbUsuarios);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error converting id to int: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Paro_Id = new SelectList(db.tbPantalla_Roles, "Paro_Id", "Paro_Id", tbUsuarios.Paro_Id);
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
            ViewBag.Paro_Id = new SelectList(db.tbPantalla_Roles, "Paro_Id", "Paro_Id", tbUsuarios.Paro_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbUsuarios.Empl_Id);
            return View(tbUsuarios);
        }

        // POST: tbUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Usua_Id,Usua_Nombre,Usua_Contraseña,Empl_Id,Paro_Id,Usua_Creacion,Usua_Fecha_Creacion,Usua_Modifica,Usua_Fecha_Modifica,Usua_Estado")] tbUsuarios tbUsuarios)
        {
            ModelState.Remove("Usua_Creacion");
            ModelState.Remove("Usua_Fecha_Creacion");
            ModelState.Remove("Usua_Modifica");
            ModelState.Remove("Usua_Fecha_Modifica");
            ModelState.Remove("Usua_Estado");
            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["idtipo"]);
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbUsuarios_Editar(id, tbUsuarios.Usua_Nombre, tbUsuarios.Usua_Contraseña, tbUsuarios.Empl_Id, tbUsuarios.Paro_Id, usuario, DateTime.Now, true);

                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error converting id to int: " + ex.Message;
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Paro_Id = new SelectList(db.tbPantalla_Roles, "Paro_Id", "Paro_Id", tbUsuarios.Paro_Id);
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
            //db.Sp_tbUsuarios_Eliminar(id);
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
