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
    public class tbPreciosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbPrecios
        public ActionResult Index()
        {
            return View(db.tbPrecios.ToList());
        }

        // GET: tbPrecios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPrecios tbPrecios = db.tbPrecios.Find(id);
            if (tbPrecios == null)
            {
                return HttpNotFound();
            }
            return View(tbPrecios);
        }

        // GET: tbPrecios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbPrecios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Prec_Id,Prec_Descripcion,Prec_Usuario_Creacion,Prec_Fecha_Creacion,Prec_Usuario_Modificacion,Prec_Fecha_Modificacion")] tbPrecios tbPrecios)
        {
            




            if (ModelState.IsValid)
            {
                db.tbPrecios.Add(tbPrecios);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbPrecios);
        }

        // GET: tbPrecios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPrecios tbPrecios = db.tbPrecios.Find(id);
            if (tbPrecios == null)
            {
                return HttpNotFound();
            }
            return View(tbPrecios);
        }

        // POST: tbPrecios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Prec_Id,Prec_Descripcion,Prec_Usuario_Creacion,Prec_Fecha_Creacion,Prec_Usuario_Modificacion,Prec_Fecha_Modificacion")] tbPrecios tbPrecios)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(Session["idtipo"]);
                var preciosexistenete = db.tbPrecios.Find(id);

                if (preciosexistenete != null)
                {
                    db.Entry(preciosexistenete).Reload();
                    preciosexistenete.Prec_Descripcion = tbPrecios.Prec_Descripcion;
                    

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(tbPrecios);
        }

        // GET: tbPrecios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPrecios tbPrecios = db.tbPrecios.Find(id);
            if (tbPrecios == null)
            {
                return HttpNotFound();
            }
            return View(tbPrecios);
        }

        // POST: tbPrecios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPrecios tbPrecios = db.tbPrecios.Find(id);
            db.tbPrecios.Remove(tbPrecios);
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
