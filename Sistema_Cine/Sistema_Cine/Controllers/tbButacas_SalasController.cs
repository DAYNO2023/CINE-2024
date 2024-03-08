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
    [ValidarSesionButacas]
    public class tbButacas_SalasController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbButacas_Salas
        public ActionResult Index()
        {
            return View(db.tbButacas_Salas.ToList());
        }

        // GET: tbButacas_Salas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbButacas_Salas tbButacas_Salas = db.tbButacas_Salas.Find(id);
            if (tbButacas_Salas == null)
            {
                return HttpNotFound();
            }
            return View(tbButacas_Salas);
        }

        // GET: tbButacas_Salas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbButacas_Salas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Buta_Id,Buta_Descripcion,Buta_Usuario_Creacion,Buta_Fecha_Creacion,Buta_Usuario_Modificacion,Buta_Fecha_Modificacion")] tbButacas_Salas tbButacas_Salas)
        {
            ModelState.Remove("Buta_Usuario_Creacion");
            ModelState.Remove("Buta_Fecha_Creacion");
            ModelState.Remove("Buta_Usuario_Modificacion");
            ModelState.Remove("Buta_Fecha_Modificacion");
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (Session["idusaio"] != null)
                        {
                            int usuario = Convert.ToInt32(Session["idusaio"]);
                            db.Sp_tbButacas_Salas_Insertar(tbButacas_Salas.Buta_Descripcion, usuario, DateTime.Now, true);
                            db.SaveChanges();
                            TempData["Exito"] = "se agregó correctamente";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["Error"] = "Error: La sesión del usuario es nula.";
                            return RedirectToAction("Index");
                        }
                    }
                    catch (FormatException ex)
                    {
                        // Handle the exception (e.g., log it, show an error message)
                        TempData["Error"] = "Error: El registro no se guardó correctamente. Detalles del error: " + ex.Message;
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["Error"] = "Error: ModelState no es válido.";
                    return RedirectToAction("Index");
                }
            }

            return View(tbButacas_Salas);
        }

        // GET: tbButacas_Salas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbButacas_Salas tbButacas_Salas = db.tbButacas_Salas.Find(id);
            if (tbButacas_Salas == null)
            {
                return HttpNotFound();
            }
            return View(tbButacas_Salas);
        }

        // POST: tbButacas_Salas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Buta_Id,Buta_Descripcion,Buta_Usuario_Creacion,Buta_Fecha_Creacion,Buta_Usuario_Modificacion,Buta_Fecha_Modificacion")] tbButacas_Salas tbButacas_Salas)
        {
            ModelState.Remove("Buta_Usuario_Creacion");
            ModelState.Remove("Buta_Fecha_Creacion");
            ModelState.Remove("Buta_Usuario_Modificacion");
            ModelState.Remove("Buta_Fecha_Modificacion");

            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (Session["idusaio"] != null && Session["idtipo"] != null)
                        {
                            int id = Convert.ToInt32(Session["idtipo"]);
                            int usuario = Convert.ToInt32(Session["idusaio"]);
                            db.Sp_tbButacas_Salas_Editar(id, tbButacas_Salas.Buta_Descripcion, usuario, DateTime.Now, true);

                            TempData["Exito"] = "Se editó correctamente";
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            TempData["Error"] = "Error: La sesión del usuario o el tipo de ID son nulos.";
                            return RedirectToAction("Index");
                        }
                    }
                    catch (FormatException ex)
                    {
                        TempData["Error"] = "Error: El registro no se editó correctamente debido a un formato incorrecto. Detalles del error: " + ex.Message;
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    TempData["Error"] = "Error: ModelState no es válido.";
                    return RedirectToAction("Index");
                }
            }
            return View(tbButacas_Salas);
        }

        // GET: tbButacas_Salas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbButacas_Salas tbButacas_Salas = db.tbButacas_Salas.Find(id);
            if (tbButacas_Salas == null)
            {
                return HttpNotFound();
            }
            return View(tbButacas_Salas);
        }

        // POST: tbButacas_Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbButacas_Salas tbButacas_Salas = db.tbButacas_Salas.Find(id);
                if (tbButacas_Salas != null)
                {
                    db.tbButacas_Salas.Remove(tbButacas_Salas);
                    db.SaveChanges();
                    TempData["Exito"] = "El campo se eliminó correctamente";
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
                TempData["Error"] = "Error: No se pudo eliminar el campo de la Butaca. Detalles del error: " + ex.Message;
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
