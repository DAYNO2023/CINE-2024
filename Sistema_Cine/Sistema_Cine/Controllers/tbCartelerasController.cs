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
    [ValidarSesioncartelera]
    public class tbCartelerasController : Controller
    {
       
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbCarteleras
        public ActionResult Index()
        {
            var tbCarteleras = db.tbCarteleras.Include(t => t.tbEntradas).Include(t => t.tbGeneros).Include(t => t.tbPromociones);
            return View(tbCarteleras.ToList());
        }

        // GET: tbCarteleras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCarteleras tbCarteleras = db.tbCarteleras.Find(id);
            if (tbCarteleras == null)
            {
                return HttpNotFound();
            }
            return View(tbCarteleras);
        }

        // GET: tbCarteleras/Create
        public ActionResult Create()
        {
            ViewBag.Entra_Id = new SelectList(db.tbEntradas, "Entra_Id", "Entra_Id");
            ViewBag.Gene_Id = new SelectList(db.tbGeneros, "Gene_Id", "Gene_Descripcion");
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion");
            return View();
        }

        // POST: tbCarteleras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cart_Id,Cart_Descripcion,Gene_Id,Prom_Id,Entra_Id,Cart_Fecha_Estreno,Cart_Usuario_Creacion,Cart_Fecha_Creacion,Cart_Usuario_Modificacion,Cart_Fecha_Modificacion")] tbCarteleras tbCarteleras)
        {
            ModelState.Remove("Cart_Usuario_Creacion");
            ModelState.Remove("Cart_Fecha_Creacion");
            ModelState.Remove("Cart_Usuario_Modificacion");
            ModelState.Remove("Carg_Fecha_Creacion");

            if (ModelState.IsValid)
            {
                try
                {
                    db.tbCarteleras.Add(tbCarteleras);
                    db.SaveChanges();
                    TempData["Exito"] = "Se agregó correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    TempData["Error"] = "Error: El registro no se guardó correctamente debido a un formato incorrecto. Detalles del error: " + ex.Message;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Error: Ocurrió un error al guardar el registro. Detalles del error: " + ex.Message;
                    return RedirectToAction("Index");
                }

            }

            ViewBag.Entra_Id = new SelectList(db.tbEntradas, "Entra_Id", "Entra_Id", tbCarteleras.Entra_Id);
            ViewBag.Gene_Id = new SelectList(db.tbGeneros, "Gene_Id", "Gene_Descripcion", tbCarteleras.Gene_Id);
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbCarteleras.Prom_Id);
            return View(tbCarteleras);
        }

        // GET: tbCarteleras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCarteleras tbCarteleras = db.tbCarteleras.Find(id);
            if (tbCarteleras == null)
            {
                return HttpNotFound();
            }
            ViewBag.Entra_Id = new SelectList(db.tbEntradas, "Entra_Id", "Entra_Id", tbCarteleras.Entra_Id);
            ViewBag.Gene_Id = new SelectList(db.tbGeneros, "Gene_Id", "Gene_Descripcion", tbCarteleras.Gene_Id);
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbCarteleras.Prom_Id);
            return View(tbCarteleras);
        }

        // POST: tbCarteleras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cart_Id,Cart_Descripcion,Gene_Id,Prom_Id,Entra_Id,Cart_Fecha_Estreno,Cart_Usuario_Creacion,Cart_Fecha_Creacion,Cart_Usuario_Modificacion,Cart_Fecha_Modificacion")] tbCarteleras tbCarteleras)
        {
            ModelState.Remove("Cart_Usuario_Creacion");
            ModelState.Remove("Cart_Fecha_Creacion");
            ModelState.Remove("Cart_Usuario_Modificacion");
            ModelState.Remove("Cart_Fecha_Modificacion");
            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["idtipo"]);
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbCarteleras_Editar(id, tbCarteleras.Cart_Descripcion, tbCarteleras.Gene_Id, tbCarteleras.Prom_Id, tbCarteleras.Entra_Id, tbCarteleras.Cart_Fecha_Estreno, usuario, DateTime.Now, true);

                    TempData["Exito"] = "Se editó correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    TempData["Error"] = "Error: Este campo no se editó correctamente debido a un formato incorrecto. Detalles del error: " + ex.Message;
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "Error: Ocurrió un error al editar el campo. Detalles del error: " + ex.Message;
                    return RedirectToAction("Index");
                }

            }
            ViewBag.Entra_Id = new SelectList(db.tbEntradas, "Entra_Id", "Entra_Id", tbCarteleras.Entra_Id);
            ViewBag.Gene_Id = new SelectList(db.tbGeneros, "Gene_Id", "Gene_Descripcion", tbCarteleras.Gene_Id);
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbCarteleras.Prom_Id);
            return View(tbCarteleras);
        }

        // GET: tbCarteleras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCarteleras tbCarteleras = db.tbCarteleras.Find(id);
            if (tbCarteleras == null)
            {
                return HttpNotFound();
            }
            return View(tbCarteleras);
        }

        // POST: tbCarteleras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbCarteleras tbCarteleras = db.tbCarteleras.Find(id);
                if (tbCarteleras != null)
                {
                    db.tbCarteleras.Remove(tbCarteleras);
                    db.SaveChanges();
                    TempData["Exito"] = "Se eliminó correctamente";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = "Error: No se encontró el registro a eliminar.";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Error: No se pudo eliminar el campo. Detalles del error: " + ex.Message;
                return RedirectToAction("Index");
            }

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
