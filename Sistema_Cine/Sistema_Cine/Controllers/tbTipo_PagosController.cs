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
    public class tbTipo_PagosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbTipo_Pagos
        public ActionResult Index()
        {
            return View(db.tbTipo_Pagos.ToList());
        }

        // GET: tbTipo_Pagos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipo_Pagos tbTipo_Pagos = db.tbTipo_Pagos.Find(id);
            if (tbTipo_Pagos == null)
            {
                return HttpNotFound();
            }
            return View(tbTipo_Pagos);
        }

        // GET: tbTipo_Pagos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbTipo_Pagos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Tipo_Id,Tipo_Descripcion,Cate_Usuario_Creacion,Cate_Fecha_Creacion,Cate_Usuario_Modificacion,Cate_Fecha_Modificacion")] tbTipo_Pagos tbTipo_Pagos)
        {
            if (ModelState.IsValid)
            {
                
                db.tbTipo_Pagos.Add(tbTipo_Pagos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbTipo_Pagos);
        }

        // GET: tbTipo_Pagos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipo_Pagos tbTipo_Pagos = db.tbTipo_Pagos.Find(id);
            if (tbTipo_Pagos == null)
            {
                return HttpNotFound();
            }
            return View(tbTipo_Pagos);
        }



        // POST: tbTipo_Pagos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Tipo_Id,Tipo_Descripcion,Cate_Usuario_Creacion,Cate_Fecha_Creacion,Cate_Usuario_Modificacion,Cate_Fecha_Modificacion")] tbTipo_Pagos tbTipo_Pagos)
        {
            ModelState.Remove("Cate_Usuario_Modificacion");
            ModelState.Remove("Cate_Fecha_Modificacion");
            ModelState.Remove("Cate_Usuario_Creacion");
            ModelState.Remove("Cate_Fecha_Creacion");

            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["idtipo"]);
                    db.Sp_tbTipo_Pagos_Editar(id, tbTipo_Pagos.Tipo_Descripcion, Convert.ToString(Session["idusaio"]), DateTime.Now);

                    //if (descicon == 1)
                    //{
                    //    db.SaveChanges();
                    //    TempData["Exito"] = "Se modificó con éxito";
                    //    return RedirectToAction("Index");
                    //}
                    //else if (descicon == 0)
                    //{
                    //    TempData["Error"] = "Ya existe un registro";
                    //    return RedirectToAction("Index");
                    //}

                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error converting id to int: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }

            return View(tbTipo_Pagos);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Editcampos([Bind(Include = "Tipo_Id,Tipo_Descripcion,Cate_Usuario_Creacion,Cate_Fecha_Creacion,Cate_Usuario_Modificacion,Cate_Fecha_Modificacion")] tbTipo_Pagos tbTipo_Pagos)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(tbTipo_Pagos).State = EntityState.Modified;

        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tbTipo_Pagos);
        //}

        // GET: tbTipo_Pagos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTipo_Pagos tbTipo_Pagos = db.tbTipo_Pagos.Find(id);
            if (tbTipo_Pagos == null)
            {
                return HttpNotFound();
            }
            return View(tbTipo_Pagos);
        }

        // POST: tbTipo_Pagos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbTipo_Pagos tbTipo_Pagos = db.tbTipo_Pagos.Find(id);
            db.tbTipo_Pagos.Remove(tbTipo_Pagos);
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
