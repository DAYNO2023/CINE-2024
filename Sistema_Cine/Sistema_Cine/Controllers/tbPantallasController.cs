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
                try
                {
                    db.tbPantallas.Add(tbPantallas);
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
            ModelState.Remove("Pant_Creacion");
            ModelState.Remove("Pant_Fecha_Creacion");
            ModelState.Remove("Pant_Modifica");
            ModelState.Remove("Pant_Fecha_Modifica");
            ModelState.Remove("Pant_Estado");
            if (ModelState.IsValid)
            {
                try 
                { 
                int id = Convert.ToInt32(Session["idtipo"]);
                int usuario = Convert.ToInt32(Session["idusaio"]);
                db.Sp_tbPantallas_Editar(id, tbPantallas.Pant_Descripcion, tbPantallas.Pant_Identificador, usuario, DateTime.Now, true);

               
                   


                    
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error converting id to int: " + ex.Message;
                    return RedirectToAction("Index");
                }
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
            //tbPantallas tbPantallas = db.tbPantallas.Find(id);
            //db.tbPantallas.Remove(tbPantallas);
            db.Sp_tbPantallas_Eliminar(id);
            
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
