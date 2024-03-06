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
    public class tbMunicipiosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbMunicipios
        public ActionResult Index()
        {
            ViewBag.Depa_Codigo = new SelectList(db.tbDepartamentos, "Depa_Codigo", "Depa_Descripcion");
            var tbMunicipio = db.tbMunicipio.Include(t => t.tbDepartamentos);
            return View(tbMunicipio.ToList());
        }

        // GET: tbMunicipios/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipio tbMunicipio = db.tbMunicipio.Find(id);
            if (tbMunicipio == null)
            {
                return HttpNotFound();
            }
            return View(tbMunicipio);
        }

        // GET: tbMunicipios/Create
        public ActionResult Create()
        {
            ViewBag.Depa_Codigo = new SelectList(db.tbDepartamentos, "Depa_Codigo", "Depa_Descripcion");
            return View();
        }

        // POST: tbMunicipios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Muni_Codigo,Muni_Descripcion,Depa_Codigo,Muni_Usuario_Creacion,Muni_Fecha_Creacion,Muni_Usuario_Modificacion,Muni_Fecha_Modificacion")] tbMunicipio tbMunicipio)
        {
            ModelState.Remove("Muni_Usuario_Creacion");
            ModelState.Remove("Muni_Fecha_Creacion");
            ModelState.Remove("Muni_Usuario_Modificacion");
            ModelState.Remove("Muni_Fecha_Modificacion");

            if (ModelState.IsValid)
            {
                try
                {
                    db.tbMunicipio.Add(tbMunicipio);
                    db.SaveChanges();
                    TempData["Exito"] = "se agrego Correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error el registro no se guardo correctamente: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Depa_Codigo = new SelectList(db.tbDepartamentos, "Depa_Codigo", "Depa_Descripcion", tbMunicipio.Depa_Codigo);
            return View(tbMunicipio);
        }

        // GET: tbMunicipios/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipio tbMunicipio = db.tbMunicipio.Find(id);
            if (tbMunicipio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Depa_Codigo = new SelectList(db.tbDepartamentos, "Depa_Codigo", "Depa_Descripcion", tbMunicipio.Depa_Codigo);
            return View(tbMunicipio);
        }

        // POST: tbMunicipios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Muni_Codigo,Muni_Descripcion,Depa_Codigo,Muni_Usuario_Creacion,Muni_Fecha_Creacion,Muni_Usuario_Modificacion,Muni_Fecha_Modificacion")] tbMunicipio tbMunicipio)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    int id = Convert.ToInt32(Session["idtipo"]);
                    var municipiosexistenete = db.tbMunicipio.Find(id);

                    if (municipiosexistenete != null)
                    {
                        db.Entry(municipiosexistenete).Reload();
                        municipiosexistenete.Muni_Descripcion = tbMunicipio.Muni_Descripcion;
                        municipiosexistenete.Depa_Codigo = tbMunicipio.Depa_Codigo;
                        TempData["Exito"] = "se Edito Correctamente";
                        db.SaveChanges();
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
            ViewBag.Depa_Codigo = new SelectList(db.tbDepartamentos, "Depa_Codigo", "Depa_Descripcion", tbMunicipio.Depa_Codigo);
            return View(tbMunicipio);
        }

        // GET: tbMunicipios/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbMunicipio tbMunicipio = db.tbMunicipio.Find(id);
            if (tbMunicipio == null)
            {
                return HttpNotFound();
            }
            return View(tbMunicipio);
        }

        // POST: tbMunicipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                tbMunicipio tbMunicipio = db.tbMunicipio.Find(id);
                db.tbMunicipio.Remove(tbMunicipio);
                db.SaveChanges();
                TempData["Exito"] = "se Elimino Correctamente";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
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
