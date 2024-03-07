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
    public class tbFacturas_EncabezadosController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbFacturas_Encabezados
        public ActionResult Index()
        {
            var tbFacturas_Encabezados = db.tbFacturas_Encabezados.Include(t => t.tbClientes).Include(t => t.tbEmpleados).Include(t => t.tbTipo_Pagos).Include(t => t.tbPromociones).ToList();
            //ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Nombre");
            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Identidad");
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre");
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion");
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion");
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

        [HttpGet]
        public ActionResult ObtenerNombreCliente(int dni)
        {
            // Verificar si el DNI es válido
           

            // Buscar el cliente por el DNI proporcionado
            var cliente = db.tbClientes.FirstOrDefault(c => c.Clie_Id == dni);

            // Verificar si se encontró el cliente
            if (cliente != null)
            {
                // Devolver el nombre del cliente como un objeto JSON
                return Json(new { nombre = cliente.Clie_Nombre }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                // Si no se encontró el cliente, devolver un mensaje de error
                return HttpNotFound();
            }
        }



        public ActionResult ObtenerDetallesFactura(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var detallesFactura = db.tbFacturas_Detalles.Where(d => d.Fact_Id == id).ToList();

            if (detallesFactura == null)
            {
                return HttpNotFound();
            }

            return View(detallesFactura);
        }

        public ActionResult GuardarDetalleFactura1(int ticket, string cartelera, string factura, int cantidad)
        {
            // Aquí puedes hacer lo que necesites con los valores de ticket, cartelera, factura y cantidad
            // Por ejemplo, puedes guardar estos valores en la base de datos
            int usuario = Convert.ToInt32(Session["idusuario"]); // Ajusta según cómo obtienes el ID del usuario
            tbFacturas_Detalles detalle = new tbFacturas_Detalles
            {
                Fade_ticket = ticket,
                Cart_Id = int.Parse(cartelera), // Asumiendo que Cart_Id es de tipo int
                Fact_Id = int.Parse(factura), // Asumiendo que Fact_Id es de tipo int
                Fade_Usua_Creacion = usuario, // Puedes obtener el usuario actual de alguna manera
                Fade_Fecha_Creacion = DateTime.Now,
                Fade_Estado = true // Cambia esto según tus necesidades
            };

            // Agregar el detalle a la base de datos
            db.tbFacturas_Detalles.Add(detalle);
            db.SaveChanges();

            // Puedes retornar alguna respuesta JSON si lo necesitas
            return Json(new { success = true });
        }







        public ActionResult GuardarDetalleFactura(int ticket, string cartelera, string factura, int cantidad)
        {
            // Aquí puedes hacer lo que necesites con los valores de ticket, cartelera, factura y cantidad
            // Por ejemplo, puedes guardar estos valores en la base de datos
            int usuario = Convert.ToInt32(Session["idusaio"]);
            tbFacturas_Detalles detalle = new tbFacturas_Detalles
            {
                Fade_ticket = ticket,
                Cart_Id = int.Parse(cartelera), // Asumiendo que Cart_Id es de tipo int
                Fact_Id = int.Parse(factura), // Asumiendo que Fact_Id es de tipo int
                Fade_Usua_Creacion = usuario, // Puedes obtener el usuario actual de alguna manera
                Fade_Fecha_Creacion = DateTime.Now,
                Fade_Estado = true // Cambia esto según tus necesidades
            };

            // Agregar el detalle a la base de datos
            db.tbFacturas_Detalles.Add(detalle);
            db.SaveChanges();

            // Puedes retornar alguna respuesta JSON si lo necesitas
            return Json(new { success = true });
        }


        // GET: tbFacturas_Encabezados/Create
        public ActionResult Create()
        {
            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Identidad");
            //ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Identidad");
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre");
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion");
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion");
            ViewBag.facturacionencabezadoList = db.tbFacturas_Encabezados.Include(t => t.tbPromociones).Include(t => t.tbClientes).Include(t => t.tbEmpleados).Include(t => t.tbTipo_Pagos).ToList();
            ViewBag.FacturaDetalleList = db.tbFacturas_Detalles.Include(t => t.tbCarteleras).Include(t => t.tbFacturas_Encabezados).ToList();
            return View();
        }

        // POST: tbFacturas_Encabezados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Fact_Id,Fact_Fecha,Clie_Id,Empl_Id,Tipo_Id,Fact_Usua_Creacion,Fact_Fecha_Creacion,Fact_Usua_Modifica,Fact_Fecha_Modifica,Fact_Estado")] tbFacturas_Encabezados tbFacturas_Encabezados)
        {
            if (ModelState.IsValid)
            {
                db.tbFacturas_Encabezados.Add(tbFacturas_Encabezados);
                db.SaveChanges();
                return RedirectToAction("Create");
            }

            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Identidad", tbFacturas_Encabezados.Clie_Id);
            //ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Identidad", tbFacturas_Encabezados.Clie_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbFacturas_Encabezados.Empl_Id);
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion", tbFacturas_Encabezados.Tipo_Id);
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbFacturas_Encabezados.Prom_Id);
          
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
            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Identidad", tbFacturas_Encabezados.Clie_Id);
            //ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Identidad", tbFacturas_Encabezados.Clie_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbFacturas_Encabezados.Empl_Id);
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion", tbFacturas_Encabezados.Tipo_Id);

            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbFacturas_Encabezados.Prom_Id);
            return View(tbFacturas_Encabezados);
        }

        // POST: tbFacturas_Encabezados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Fact_Id,Fact_Fecha,Clie_Id,Empl_Id,Tipo_Id,Fact_Usua_Creacion,Fact_Fecha_Creacion,Fact_Usua_Modifica,Fact_Fecha_Modifica,Fact_Estado")] tbFacturas_Encabezados tbFacturas_Encabezados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbFacturas_Encabezados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Clie_Id = new SelectList(db.tbClientes, "Clie_Id", "Clie_Identidad", tbFacturas_Encabezados.Clie_Id);
            ViewBag.Empl_Id = new SelectList(db.tbEmpleados, "Empl_Id", "Empl_Nombre", tbFacturas_Encabezados.Empl_Id);
            ViewBag.Tipo_Id = new SelectList(db.tbTipo_Pagos, "Tipo_Id", "Tipo_Descripcion", tbFacturas_Encabezados.Tipo_Id);
            ViewBag.Prom_Id = new SelectList(db.tbPromociones, "Prom_Id", "Prom_Descripcion", tbFacturas_Encabezados.Prom_Id);
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
