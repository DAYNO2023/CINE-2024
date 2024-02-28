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
            if (ModelState.IsValid)
            {
                db.tbButacas_Salas.Add(tbButacas_Salas);
                db.SaveChanges();
                return RedirectToAction("Index");
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
            if (ModelState.IsValid)
            {
                db.Entry(tbButacas_Salas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
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
            tbButacas_Salas tbButacas_Salas = db.tbButacas_Salas.Find(id);
            db.tbButacas_Salas.Remove(tbButacas_Salas);
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
