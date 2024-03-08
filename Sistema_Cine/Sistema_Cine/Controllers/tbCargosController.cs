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
    [ValidarSesioncargo]
    public class tbCargosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbCargos
        public ActionResult Index()
        {
            return View(db.tbCargos.ToList());
        }

        // GET: tbCargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargos tbCargos = db.tbCargos.Find(id);
            if (tbCargos == null)
            {
                return HttpNotFound();
            }
            return View(tbCargos);
        }

        // GET: tbCargos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbCargos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Carg_Id,Carg_Descripcion,Carg_Usuario_Creacion,Carg_Fecha_Creacion,Carg_Usuario_Modificacion,Carg_Fecha_Modificacion")] tbCargos tbCargos)
        {
            ModelState.Remove("Carg_Fecha_Creacion");
            ModelState.Remove("Carg_Fecha_Creacion");
            ModelState.Remove("Carg_Usuario_Creacion");
            ModelState.Remove("Carg_Fecha_Creacion");



            if (ModelState.IsValid)
            {
                try
                {
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbCargos_Insertar(tbCargos.Carg_Descripcion, usuario, DateTime.Now, true);
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

            return View(tbCargos);
        }

        // GET: tbCargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargos tbCargos = db.tbCargos.Find(id);
            if (tbCargos == null)
            {
                return HttpNotFound();
            }
            return View(tbCargos);
        }

        // POST: tbCargos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Carg_Id,Carg_Descripcion,Carg_Usuario_Creacion,Carg_Fecha_Creacion,Carg_Usuario_Modificacion,Carg_Fecha_Modificacion")] tbCargos tbCargos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["idtipo"]);
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbCargos_Editar(id, tbCargos.Carg_Descripcion, usuario, DateTime.Now, true);

                    // Guardar los cambios en la base de datos
                    db.SaveChanges();
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
            return View(tbCargos);
        }

        // GET: tbCargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbCargos tbCargos = db.tbCargos.Find(id);
            if (tbCargos == null)
            {
                return HttpNotFound();
            }
            return View(tbCargos);
        }

        // POST: tbCargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbCargos tbCargos = db.tbCargos.Find(id);
                if (tbCargos != null)
                {
                    db.tbCargos.Remove(tbCargos);
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
