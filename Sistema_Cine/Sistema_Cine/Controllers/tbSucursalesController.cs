﻿using System;
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
    public class tbSucursalesController : Controller
    {
        private dbSsitemascinesEntities5 db = new dbSsitemascinesEntities5();

        // GET: tbSucursales
        public ActionResult Index()
        {
            ViewBag.Cart_Id = new SelectList(db.tbCarteleras, "Cart_Id", "Cart_Descripcion");
            ViewBag.Entra_Id = new SelectList(db.tbEntradas, "Entra_Id", "Entra_Id");
            var tbSucursales = db.tbSucursales.Include(t => t.tbCarteleras).Include(t => t.tbEntradas).Include(t => t.tbMunicipio);
            return View(tbSucursales.ToList());
        }

        // GET: tbSucursales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSucursales tbSucursales = db.tbSucursales.Find(id);
            if (tbSucursales == null)
            {
                return HttpNotFound();
            }
            return View(tbSucursales);
        }

        // GET: tbSucursales/Create
        public ActionResult Create()
        {
            ViewBag.Cart_Id = new SelectList(db.tbCarteleras, "Cart_Id", "Cart_Descripcion");
            ViewBag.Entra_Id = new SelectList(db.tbEntradas, "Entra_Id", "Entra_Id");
            ViewBag.Muni_Codigo = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion");
            return View();
        }

        // POST: tbSucursales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sucu_Id,Sucu_Descripcion,Sucu_Direccion,Muni_Codigo,Cart_Id,Entra_Id,Sucu_Usuario_Creacion,Sucu_Fecha_Creacion,Sucu_Usuario_Modificacion,Sucu_Fecha_Modificacion")] tbSucursales tbSucursales)
        {
            ModelState.Remove("Sucu_Usuario_Creacion");
            ModelState.Remove("Sucu_Fecha_Creacion");
            ModelState.Remove("Sucu_Usuario_Modificacion");
            ModelState.Remove("Sucu_Fecha_Modificacion");


            if (ModelState.IsValid)
            {
                try
                {

                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbSucursales_Insertar(tbSucursales.Sucu_Descripcion, tbSucursales.Sucu_Direccion, tbSucursales.Muni_Codigo, usuario, DateTime.Now, true);
                    //db.tbSucursales.Add(tbSucursales);
                    db.SaveChanges();
                    TempData["Exito"] = "se agrego Correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error no se agrego el nuvo registro: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Cart_Id = new SelectList(db.tbCarteleras, "Cart_Id", "Cart_Descripcion", tbSucursales.Cart_Id);
            ViewBag.Entra_Id = new SelectList(db.tbEntradas, "Entra_Id", "Entra_Id", tbSucursales.Entra_Id);
            ViewBag.Muni_Codigo = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbSucursales.Muni_Codigo);
            return View(tbSucursales);
        }

        // GET: tbSucursales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSucursales tbSucursales = db.tbSucursales.Find(id);
            if (tbSucursales == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cart_Id = new SelectList(db.tbCarteleras, "Cart_Id", "Cart_Descripcion", tbSucursales.Cart_Id);
            ViewBag.Entra_Id = new SelectList(db.tbEntradas, "Entra_Id", "Entra_Id", tbSucursales.Entra_Id);
            ViewBag.Muni_Codigo = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbSucursales.Muni_Codigo);
            return View(tbSucursales);
        }

        // POST: tbSucursales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sucu_Id,Sucu_Descripcion,Sucu_Direccion,Muni_Codigo,Cart_Id,Entra_Id,Sucu_Usuario_Creacion,Sucu_Fecha_Creacion,Sucu_Usuario_Modificacion,Sucu_Fecha_Modificacion")] tbSucursales tbSucursales)
        {
            ModelState.Remove("Sucu_Usuario_Creacion");
            ModelState.Remove("Sucu_Fecha_Creacion");
            ModelState.Remove("Sucu_Usuario_Modificacion");
            ModelState.Remove("Sucu_Fecha_Modificacion");

            if (ModelState.IsValid)
            {
                try
                {
                    int id = Convert.ToInt32(Session["idtipo"]);
                    int usuario = Convert.ToInt32(Session["idusaio"]);
                    db.Sp_tbSucursales_Editar(id, tbSucursales.Sucu_Descripcion, tbSucursales.Sucu_Direccion, tbSucursales.Muni_Codigo, usuario, DateTime.Now, true);
                    TempData["Exito"] = "se Edito Correctamente";
                    return RedirectToAction("Index");
                }
                catch (FormatException ex)
                {
                    // Handle the exception (e.g., log it, show an error message)
                    TempData["Error"] = "Error el campo no se edito correctamente: " + ex.Message;
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Cart_Id = new SelectList(db.tbCarteleras, "Cart_Id", "Cart_Descripcion", tbSucursales.Cart_Id);
            ViewBag.Entra_Id = new SelectList(db.tbEntradas, "Entra_Id", "Entra_Id", tbSucursales.Entra_Id);
            ViewBag.Muni_Codigo = new SelectList(db.tbMunicipio, "Muni_Codigo", "Muni_Descripcion", tbSucursales.Muni_Codigo);
            return View(tbSucursales);
        }

        // GET: tbSucursales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbSucursales tbSucursales = db.tbSucursales.Find(id);
            if (tbSucursales == null)
            {
                return HttpNotFound();
            }
            return View(tbSucursales);
        }

        // POST: tbSucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbSucursales tbSucursales = db.tbSucursales.Find(id);
                db.tbSucursales.Remove(tbSucursales);
                //db.Sp_tbSucursales_Eliminar(id);
                db.SaveChanges();
                TempData["Exito"] = "se Elimino Correctamente"; ;
                return RedirectToAction("Index");
            }
            catch (FormatException ex)
            {
                // Handle the exception (e.g., log it, show an error message)
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
