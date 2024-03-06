using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
            ModelState.Remove("Gene_Usuario_Creacion");
            ModelState.Remove("Gene_Fecha_Creacion");
            ModelState.Remove("Gene_Usuario_Modificacion");
            ModelState.Remove("Gene_Fecha_Modificacion");
          

            if (ModelState.IsValid)
            {
                try
                {
                    db.tbGeneros.Add(tbGeneros);
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
            int id = Convert.ToInt32(Session["idtipo"]);
            var generoexistenete = db.tbGeneros.Find(id);

            if (ModelState.IsValid)
            {
                if (generoexistenete != null)
                {
                    try
                    {
                       
                        db.Entry(generoexistenete).Reload();
                        generoexistenete.Gene_Descripcion = tbGeneros.Gene_Descripcion;
                        generoexistenete.Prom_Id = tbGeneros.Prom_Id;

                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                     
                        var entry = ex.Entries.Single();
                        var clientValues = (tbGeneros)entry.Entity;
                        var databaseEntry = entry.GetDatabaseValues();

                        if (databaseEntry == null)
                        {
                            ModelState.AddModelError(string.Empty, "La entidad ha sido eliminada por otro usuario.");
                        }
                        else
                        {
                            
                            var databaseValues = (tbGeneros)databaseEntry.ToObject();
                            clientValues.Gene_Fecha_Modificacion = databaseValues.Gene_Fecha_Modificacion;

                            ModelState.AddModelError(string.Empty, "La entidad ha sido modificada por otro usuario. Se han cargado los cambios más recientes.");
                        }
                    }
                }
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
