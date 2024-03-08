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
    [ValidarSessionFacturas_emcabezados]
    public class tbFacturas_EncabezadosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbFacturas_Encabezados
        public ActionResult Index()
        {

            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Nombre");
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre");
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion");
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion");
            var tbFacturas_Encabezados = db.tbFacturas_Encabezados.Include(t => t.tbClientes).Include(t => t.tbEmpleados).Include(t => t.tbPromociones).Include(t => t.tbTipo_Pagos);
            return View(tbFacturas_Encabezados.ToList());
        }

        // GET: tbFacturas_Encabezados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFacturas_Encabezados tbFacturas_Encabezados = db.tbFacturas_Encabezados.Find(id);
            if (tbFacturas_Encabezados == null)
            {
                return HttpNotFound();
            }
            return View(tbFacturas_Encabezados);
        }

        // GET: tbFacturas_Encabezados/Create
        public ActionResult Create()
        {
            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Nombre");
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre");
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion");
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion");
            return View();
        }

        // POST: tbFacturas_Encabezados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fact_Id,Fact_Fecha,Clie_Id,Empl_Id,Tipo_Id,Fact_Usua_Creacion,Fact_Fecha_Creacion,Fact_Usua_Modifica,Fact_Fecha_Modifica,Fact_Estado,Prom_Id")] tbFacturas_Encabezados tbFacturas_Encabezados)
        {
            if (ModelState.IsValid)
            {
                int usuario = Convert.ToInt32(Session["idusaio"]);
                var idparam = new System.Data.Entity.Core.Objects.ObjectParameter("Fact_Id", typeof(int));
                db.Sp_tbtbFacturas_Encabezados_insertar(tbFacturas_Encabezados.Fact_Fecha, tbFacturas_Encabezados.Clie_Id, tbFacturas_Encabezados.Empl_Id, tbFacturas_Encabezados.Tipo_Id, usuario, DateTime.Now, true, tbFacturas_Encabezados.Prom_Id, idparam);
                int idfact = (int)idparam.Value;
                Session["idFact"] = idfact;


                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Nombre", tbFacturas_Encabezados.Clie_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbFacturas_Encabezados.Empl_Id);
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbFacturas_Encabezados.Prom_Id);
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion", tbFacturas_Encabezados.Tipo_Id);
            return View(tbFacturas_Encabezados);
        }

        // GET: tbFacturas_Encabezados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFacturas_Encabezados tbFacturas_Encabezados = db.tbFacturas_Encabezados.Find(id);
            if (tbFacturas_Encabezados == null)
            {
                return HttpNotFound();
            }
            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Nombre", tbFacturas_Encabezados.Clie_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbFacturas_Encabezados.Empl_Id);
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbFacturas_Encabezados.Prom_Id);
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion", tbFacturas_Encabezados.Tipo_Id);
            return View(tbFacturas_Encabezados);
        }

        // POST: tbFacturas_Encabezados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fact_Id,Fact_Fecha,Clie_Id,Empl_Id,Tipo_Id,Fact_Usua_Creacion,Fact_Fecha_Creacion,Fact_Usua_Modifica,Fact_Fecha_Modifica,Fact_Estado,Prom_Id")] tbFacturas_Encabezados tbFacturas_Encabezados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbFacturas_Encabezados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Nombre", tbFacturas_Encabezados.Clie_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbFacturas_Encabezados.Empl_Id);
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbFacturas_Encabezados.Prom_Id);
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion", tbFacturas_Encabezados.Tipo_Id);
            return View(tbFacturas_Encabezados);
        }

        // GET: tbFacturas_Encabezados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbFacturas_Encabezados tbFacturas_Encabezados = db.tbFacturas_Encabezados.Find(id);
            if (tbFacturas_Encabezados == null)
            {
                return HttpNotFound();
            }
            return View(tbFacturas_Encabezados);
        }

        // POST: tbFacturas_Encabezados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbFacturas_Encabezados tbFacturas_Encabezados = db.tbFacturas_Encabezados.Find(id);
            db.tbFacturas_Encabezados.Remove(tbFacturas_Encabezados);
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
