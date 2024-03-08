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
    [ValidarSesioncliente]
    public class tbClientesController : Controller
    {
        
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbClientes
        public ActionResult Index()
        {
            var tbClientes = db.tbClientes.Include(t => t.tbEstado_Civil).Include(t => t.tbMunicipio);
            return View(tbClientes.ToList());
        }

        // GET: tbClientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbClientes tbClientes = db.tbClientes.Find(id);
            if (tbClientes == null)
            {
                return HttpNotFound();
            }
            return View(tbClientes);
        }
        public ActionResult ObtenerClientePorDNI(string dni)
        {
            // Verificar si el DNI es válido
            if (string.IsNullOrWhiteSpace(dni))
            {
                return HttpNotFound();
            }

            // Buscar el cliente por el DNI proporcionado
            var cliente = db.tbClientes.FirstOrDefault(c => c.Clie_Identidad == dni);

            // Verificar si se encontró el cliente
            if (cliente == null)
            {
                // Si no se encontró el cliente, devolver un mensaje de error
                return Json(new { nombre = "Cliente no encontrado" }, JsonRequestBehavior.AllowGet);
            }

            // Si se encontró el cliente, devolver su nombre como JSON
            return Json(new { nombre = cliente.Clie_Nombre }, JsonRequestBehavior.AllowGet);
        }


        // GET: tbClientes/Create
        public ActionResult Create()
        {
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion");
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion");
            return View();
        }

        // POST: tbClientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Clie_Id,Clie_Nombre,Clie_Apellido,Clie_Identidad,Clie_Sexo,Clie_Telefono,Esta_Id,Clie_FecNacimiento,Muni_Id,Clie_Usua_Creacion,Clie_Fecha_Creacion,Clie_Usua_Modifica,Clie_Fecha_Modifica,Clie_Estado")] tbClientes tbClientes)
        {
            ModelState.Remove("Clie_Usua_Creacion");
            ModelState.Remove("Clie_Fecha_Creacion");
            ModelState.Remove("Clie_Usua_Modifica");
            ModelState.Remove("Clie_Fecha_Modifica");
            ModelState.Remove("Clie_Estado");

            if (ModelState.IsValid)
            {
                try
                {
                    db.tbClientes.Add(tbClientes);
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

            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion", tbClientes.Esta_Id);
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbClientes.Muni_Id);
            return View(tbClientes);
        }

        // GET: tbClientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbClientes tbClientes = db.tbClientes.Find(id);
            if (tbClientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion", tbClientes.Esta_Id);
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbClientes.Muni_Id);
            return View(tbClientes);
        }

        // POST: tbClientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Clie_Id,Clie_Nombre,Clie_Apellido,Clie_Identidad,Clie_Sexo,Clie_Telefono,Esta_Id,Clie_FecNacimiento,Muni_Id,Clie_Usua_Creacion,Clie_Fecha_Creacion,Clie_Usua_Modifica,Clie_Fecha_Modifica,Clie_Estado")] tbClientes tbClientes)
        {
            ModelState.Remove("Clie_Usua_Creacion");
            ModelState.Remove("Clie_Fecha_Creacion");
            ModelState.Remove("Clie_Usua_Modifica");
            ModelState.Remove("Clie_Fecha_Modifica");
            ModelState.Remove("Clie_Estado");


            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["idtipo"]);
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbClientes_Editar(id, tbClientes.Clie_Nombre, tbClientes.Clie_Apellido, tbClientes.Clie_Identidad, tbClientes.Clie_Sexo, tbClientes.Clie_Telefono, tbClientes.Esta_Id, tbClientes.Clie_FecNacimiento, tbClientes.Muni_Id, usuario, DateTime.Now, true);

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
            ViewBag.Esta_Id = new SelectList(db.tbEstado_Civil, "Esta_Id", "Esta_Descripcion", tbClientes.Esta_Id);
            ViewBag.Muni_Id = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbClientes.Muni_Id);
            return View(tbClientes);
        }

        // GET: tbClientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbClientes tbClientes = db.tbClientes.Find(id);
            if (tbClientes == null)
            {
                return HttpNotFound();
            }
            return View(tbClientes);
        }

        // POST: tbClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // Operación de base de datos
                // db.Sp_tbClientes_Eliminar(id);
                // db.SaveChanges();

                // Mensaje de éxito
                TempData["Exito"] = "Se realizó la operación correctamente";
                return RedirectToAction("Index");
            }
            catch (FormatException ex)
            {
                // Excepción específica de formato
                TempData["Error"] = "Error: Este campo no se editó correctamente debido a un formato incorrecto. Detalles del error: " + ex.Message;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Otra excepción general
                TempData["Error"] = "Error: Ocurrió un error al realizar la operación. Detalles del error: " + ex.Message;
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
