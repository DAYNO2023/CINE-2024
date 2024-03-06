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
    public class tbRolesController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();
        // GET: tbRoles
        public ActionResult Index()
        {
            return View(db.tbRoles.ToList());
        }

        // GET: tbRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRoles tbRoles = db.tbRoles.Find(id);
            if (tbRoles == null)
            {
                return HttpNotFound();
            }
            return View(tbRoles);
        }

        [HttpGet]
        public ActionResult BuscarPantallasPorRol(string roleDescripcion)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(roleDescripcion))
                {
                    var pantallasRolesList = db.tbPantalla_Roles
                        .Include(pr => pr.tbRoles)
                        .Include(pr => pr.tbPantallas)
                        .Where(pr => pr.tbRoles.Role_Descripcion.Contains(roleDescripcion))
                        .ToList();

                    var pantallasFiltradas = pantallasRolesList
                        .Select(pr => new
                        {
                            Role_Id = pr.tbRoles.Role_Id,
                            Role_Descripcion = pr.tbRoles.Role_Descripcion,
                            Pant_Id = pr.tbPantallas.Pant_Id,
                            Pant_Descripcion = pr.tbPantallas.Pant_Descripcion,
                })
                        .Distinct()
                        .ToList();

                    return Json(new { success = true, pantallasFiltradas }, JsonRequestBehavior.AllowGet);
                }

                return Json(new { success = false, message = "La descripción de rol está vacía o nula." }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error en la búsqueda: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: tbRoles/Create
        public ActionResult Create()
        {
            ViewBag.PantallasList = db.tbPantallas.ToList();
            ViewBag.PantallasRolesList = db.tbPantalla_Roles.Include(pr => pr.tbRoles).Include(pr => pr.tbPantallas).ToList();
            return View();
        }

        // POST: tbRoles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Role_Id,Role_Descripcion,Role_Creacion,Role_Fecha_Creacion,Role_Modifica,Role_Fecha_Modifica,Role_Estado")] tbRoles tbRoles)
        {
            if (ModelState.IsValid)
            {
                db.tbRoles.Add(tbRoles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PantallasList = db.tbPantallas.ToList();
            ViewBag.PantallasRolesList = db.tbPantalla_Roles.Include(pr => pr.tbRoles).Include(pr => pr.tbPantallas).ToList();
            return View(tbRoles);
        }
        [HttpPost]
        public ActionResult AgregarPantallaRol(string Role_Descripcion, string Pant_Descripcion)
        {
            try
            {
                var existingRole = db.tbRoles.FirstOrDefault(r => r.Role_Descripcion == Role_Descripcion);

                int roleId;

                if (existingRole == null)
                {
                    var nuevoRol = new tbRoles
                    {
                        Role_Descripcion = Role_Descripcion,
                    };

                    db.tbRoles.Add(nuevoRol);
                    db.SaveChanges();

                    roleId = nuevoRol.Role_Id;
                }
                else
                {
                    roleId = existingRole.Role_Id;
                }
                var pantalla = db.tbPantallas.FirstOrDefault(p => p.Pant_Descripcion == Pant_Descripcion);

                if (pantalla != null)
                {
                    var nuevaRelacion = new tbPantalla_Roles
                    {
                        Role_Id = roleId, 
                        Pant_Id = pantalla.Pant_Id,
                    };

                    db.tbPantalla_Roles.Add(nuevaRelacion);
                    db.SaveChanges();

                    var pantallasRolesList = db.tbPantalla_Roles
                        .Include(pr => pr.tbRoles)
                        .Include(pr => pr.tbPantallas)
                        .ToList();
                    ViewBag.PantallasRolesList = pantallasRolesList;
                    return Json(new { success = true, message = "Relación y rol agregados correctamente." });
                }
                else
                {
                    return Json(new { success = false, message = "La pantalla especificada no existe." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al agregar la relación y el rol." });
            }
        }



        // GET: tbRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRoles tbRoles = db.tbRoles.Find(id);
            if (tbRoles == null)
            {
                return HttpNotFound();
            }
            ViewBag.PantallasList = db.tbPantallas.ToList();
            ViewBag.PantallasRolesList = db.tbPantalla_Roles.Include(pr => pr.tbRoles).Include(pr => pr.tbPantallas).ToList();
            return View(tbRoles);
        }

        // POST: tbRoles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Role_Id,Role_Descripcion,Role_Creacion,Role_Fecha_Creacion,Role_Modifica,Role_Fecha_Modifica,Role_Estado")] tbRoles tbRoles)
        {
            if (ModelState.IsValid)
            {

                int id = Convert.ToInt32(Session["idtipo"]);
                var rolesexistenete = db.tbRoles.Find(id);

                if (rolesexistenete != null)
                {
                    db.Entry(rolesexistenete).Reload();
                    rolesexistenete.Role_Descripcion = tbRoles.Role_Descripcion;


                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.PantallasList = db.tbPantallas.ToList();
            ViewBag.PantallasRolesList = db.tbPantalla_Roles.Include(pr => pr.tbRoles).Include(pr => pr.tbPantallas).ToList();
            return View(tbRoles);
        }

        // GET: tbRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbRoles tbRoles = db.tbRoles.Find(id);
            if (tbRoles == null)
            {
                return HttpNotFound();
            }
            return View(tbRoles);
        }

        // POST: tbRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbRoles tbRoles = db.tbRoles.Find(id);
            db.tbRoles.Remove(tbRoles);
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

        [HttpPost]
        public ActionResult EliminarPantallaRol(int id)
        {
            db.Sp_tbPantalla_Roles_Eliminar(id);
            db.SaveChanges();
            return Redirect("Index");
        }



    }
}
