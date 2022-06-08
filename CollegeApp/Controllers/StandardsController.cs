﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeApp.Data;
using CollegeApp.Models;
using CollegeApp.Models.plan;

namespace CollegeApp.Controllers
{
    [Permission]
    [ViewPermissionFilter(ViewId = 1)]
    public class StandardsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Standards
        public ActionResult Index()
        {
            return View(db.Standards.ToList());
        }

        // GET: Standards/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // GET: Standards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Standards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StandardId,StandardName,StandardDescription")] Standard standard)
        {
            if (ModelState.IsValid)
            {
                db.Standards.Add(standard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(standard);
        }

        // GET: Standards/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // POST: Standards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StandardId,StandardName,StandardDescription")] Standard standard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(standard);
        }

        // GET: Standards/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // POST: Standards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            Standard standard = db.Standards.Find(id);
            db.Standards.Remove(standard);
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
