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
    [ValidarSesiondepartamento]
    public class tbDepartamentosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbDepartamentos
        public ActionResult Index()
        {
            return View(db.tbDepartamentos.ToList());
        }

        // GET: tbDepartamentos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // GET: tbDepartamentos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbDepartamentos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Depa_Codigo,Depa_Descripcion,Depa_Usuario_Creacion,Depa_Fecha_Creacion,Depa_Usuario_Modificacion,Depa_Fecha_Modificacion")] tbDepartamentos tbDepartamentos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.tbDepartamentos.Add(tbDepartamentos);
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

            return View(tbDepartamentos);
        }

        // GET: tbDepartamentos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // POST: tbDepartamentos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Depa_Codigo,Depa_Descripcion,Depa_Usuario_Creacion,Depa_Fecha_Creacion,Depa_Usuario_Modificacion,Depa_Fecha_Modificacion")] tbDepartamentos tbDepartamentos)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["idtipo"]);

                    // Buscar el registro existente en la base de datos
                    var departementoExistente = db.tbDepartamentos.Find(id);

                    if (departementoExistente != null)
                    {
                        // Actualizar las propiedades del registro existente con los valores del modelo recibido
                        departementoExistente.Depa_Descripcion = tbDepartamentos.Depa_Descripcion;

                        // Cambiar el estado de la entidad a modificada
                        db.Entry(departementoExistente).State = EntityState.Modified;

                        // Guardar los cambios en la base de datos
                        db.SaveChanges();
                        TempData["Exito"] = "se Edito Correctamente";
                        return RedirectToAction("Index");
                    }
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error este campo no se edito correctamente: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }
            return View(tbDepartamentos);
        }

        // GET: tbDepartamentos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
            if (tbDepartamentos == null)
            {
                return HttpNotFound();
            }
            return View(tbDepartamentos);
        }

        // POST: tbDepartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                tbDepartamentos tbDepartamentos = db.tbDepartamentos.Find(id);
                db.tbDepartamentos.Remove(tbDepartamentos);

                db.SaveChanges();
                TempData["Exito"] = "se Elimino Correctamente";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Error el campo no fue eliminado: " + ex.Message;
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
