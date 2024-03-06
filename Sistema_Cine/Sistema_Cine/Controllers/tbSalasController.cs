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
    public class tbSalasController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbSalas
        public ActionResult Index()
        {
            ViewBag.Buta_Id = new SelectList(db.tbButacas_Salas, "Buta_Id", "Buta_Descripcion");
            var tbSalas = db.tbSalas.Include(t => t.tbButacas_Salas);
            return View(tbSalas.ToList());
        }

        // GET: tbSalas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSalas tbSalas = db.tbSalas.Find(id);
            if (tbSalas == null)
            {
                return HttpNotFound();
            }
            return View(tbSalas);
        }

        // GET: tbSalas/Create
        public ActionResult Create()
        {
            ViewBag.Buta_Id = new SelectList(db.tbButacas_Salas, "Buta_Id", "Buta_Descripcion");
            return View();
        }

        // POST: tbSalas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sala_Id,Sala_Descripcion,Buta_Id,Cate_Usuario_Creacion,Cate_Fecha_Creacion,Cate_Usuario_Modificacion,Cate_Fecha_Modificacion")] tbSalas tbSalas)
        {
            ModelState.Remove("Cate_Usuario_Creacion");
            ModelState.Remove("Cate_Fecha_Creacion");
            ModelState.Remove("Cate_Usuario_Modificacion");
            ModelState.Remove("Cate_Fecha_Modificacion");

            if (ModelState.IsValid)
            {
                try
                {
                    db.Sp_tbSalas_Insertar(tbSalas.Sala_Descripcion, tbSalas.Buta_Id, tbSalas.Cate_Usuario_Creacion, DateTime.Now, tbSalas.Cate_Estado);
                    //db.tbSalas.Add(tbSalas);
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

            ViewBag.Buta_Id = new SelectList(db.tbButacas_Salas, "Buta_Id", "Buta_Descripcion", tbSalas.Buta_Id);
            return View(tbSalas);
        }

        // GET: tbSalas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSalas tbSalas = db.tbSalas.Find(id);
            if (tbSalas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Buta_Id = new SelectList(db.tbButacas_Salas, "Buta_Id", "Buta_Descripcion", tbSalas.Buta_Id);
            return View(tbSalas);
        }

        // POST: tbSalas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sala_Id,Sala_Descripcion,Buta_Id,Cate_Usuario_Creacion,Cate_Fecha_Creacion,Cate_Usuario_Modificacion,Cate_Fecha_Modificacion")] tbSalas tbSalas)
        {
            ModelState.Remove("Cate_Usuario_Creacion");
            ModelState.Remove("Cate_Fecha_Creacion");
            ModelState.Remove("Cate_Usuario_Modificacion");
            ModelState.Remove("Cate_Fecha_Modificacion");
            if (ModelState.IsValid)
            {

                try {
                    int id = Convert.ToInt32(Session["idtipo"]);
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbSalas_Editar(id, tbSalas.Sala_Descripcion, tbSalas.Buta_Id, usuario, DateTime.Now, true);
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error converting id to int: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Buta_Id = new SelectList(db.tbButacas_Salas, "Buta_Id", "Buta_Descripcion", tbSalas.Buta_Id);
            return View(tbSalas);
        }

        // GET: tbSalas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSalas tbSalas = db.tbSalas.Find(id);
            if (tbSalas == null)
            {
                return HttpNotFound();
            }
            return View(tbSalas);
        }

        // POST: tbSalas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbSalas tbSalas = db.tbSalas.Find(id);
            db.tbSalas.Remove(tbSalas);
            //db.Sp_tbSalas_Eliminar(id);
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
