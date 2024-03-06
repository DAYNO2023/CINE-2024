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
    public class tbEmpleadosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbEmpleados
        public ActionResult Index()
        {
            var tbEmpleados = db.tbEmpleados.Include(t => t.tbCargos).Include(t => t.tbEstado_Civil).Include(t => t.tbMunicipio);
            return View(tbEmpleados.ToList());
        }

        // GET: tbEmpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleados);
        }

        // GET: tbEmpleados/Create
        public ActionResult Create()
        {
            ViewBag.Carg_Id = new SelectList(db.tbCargos, "Carg_Id", "Carg_Descripcion");
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion");
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion");
            return View();
        }

        // POST: tbEmpleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Empl_Id,Empl_Nombre,Empl_Apellido,Empl_Identidad,Empl_Sexo,Empl_Telefono,Esta_Id,Empl_FecNacimiento,Muni_Id,Carg_Id,Empl_Usua_Creacion,Empl_Fecha_Creacion,Empl_Usua_Modifica,Empl_Fecha_Modifica,Empl_Estado")] tbEmpleados tbEmpleados)
        {
            ModelState.Remove("Empl_Usua_Creacion");
            ModelState.Remove("Empl_Fecha_Creacion");
            ModelState.Remove("Empl_Usua_Modifica");
            ModelState.Remove("Empl_Fecha_Modifica");
            ModelState.Remove("Empl_Estado");

            if (ModelState.IsValid)
            {
                try
                {
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbEmpleados_Insertar(tbEmpleados.Empl_Nombre, tbEmpleados.Empl_Apellido, tbEmpleados.Empl_Identidad, tbEmpleados.Empl_Sexo, tbEmpleados.Empl_Telefono, tbEmpleados.Esta_Id, tbEmpleados.Empl_FecNacimiento, tbEmpleados.Muni_Id, tbEmpleados.Carg_Id, usuario, DateTime.Now, true);
                    //db.tbEmpleados.Add(tbEmpleados);
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

            ViewBag.Carg_Id = new SelectList(db.tbCargos, "Carg_Id", "Carg_Descripcion", tbEmpleados.Carg_Id);
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion", tbEmpleados.Esta_Id);
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbEmpleados.Muni_Id);
            return View(tbEmpleados);
        }

        // GET: tbEmpleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Carg_Id = new SelectList(db.tbCargos, "Carg_Id", "Carg_Descripcion", tbEmpleados.Carg_Id);
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion", tbEmpleados.Esta_Id);
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbEmpleados.Muni_Id);
            return View(tbEmpleados);
        }

        // POST: tbEmpleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Empl_Id,Empl_Nombre,Empl_Apellido,Empl_Identidad,Empl_Sexo,Empl_Telefono,Esta_Id,Empl_FecNacimiento,Muni_Id,Carg_Id,Empl_Usua_Creacion,Empl_Fecha_Creacion,Empl_Usua_Modifica,Empl_Fecha_Modifica,Empl_Estado")] tbEmpleados tbEmpleados)
        {
            ModelState.Remove("Empl_Usua_Creacion");
            ModelState.Remove("Empl_Fecha_Creacion");
            ModelState.Remove("Empl_Usua_Modifica");
            ModelState.Remove("Empl_Fecha_Modifica");
            ModelState.Remove("Empl_Estado");
            if (ModelState.IsValid)
            {

                try
                {

                    int id = Convert.ToInt32(Session["idtipo"]);
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbEmpleados_Editar(id, tbEmpleados.Empl_Nombre, tbEmpleados.Empl_Apellido, tbEmpleados.Empl_Identidad, tbEmpleados.Empl_Sexo, tbEmpleados.Empl_Telefono, tbEmpleados.Esta_Id, tbEmpleados.Empl_FecNacimiento, tbEmpleados.Muni_Id, tbEmpleados.Carg_Id, usuario, DateTime.Now, true);



                    TempData["Exito"] = "se Edito Correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error este campo no se edito correctamente: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Carg_Id = new SelectList(db.tbCargos, "Carg_Id", "Carg_Descripcion", tbEmpleados.Carg_Id);
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion", tbEmpleados.Esta_Id);
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbEmpleados.Muni_Id);
            return View(tbEmpleados);
        }

        // GET: tbEmpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
            if (tbEmpleados == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleados);
        }

        // POST: tbEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                //tbEmpleados tbEmpleados = db.tbEmpleados.Find(id);
                //db.tbEmpleados.Remove(tbEmpleados);
                db.Sp_tbEmpleados_Eliminar(id);
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
