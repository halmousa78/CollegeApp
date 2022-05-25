using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeApp.Data;
using CollegeApp.Models;

namespace CollegeApp.Controllers
{
    public class DepartmentTypesController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: DepartmentTypes
        public ActionResult Index()
        {
            return View(db.DepartmentTypes.ToList());
        }

        // GET: DepartmentTypes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentType departmentType = db.DepartmentTypes.Find(id);
            if (departmentType == null)
            {
                return HttpNotFound();
            }
            return View(departmentType);
        }

        // GET: DepartmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentTypeId,DepartmentTypeName")] DepartmentType departmentType)
        {
            if (ModelState.IsValid)
            {
                db.DepartmentTypes.Add(departmentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departmentType);
        }

        // GET: DepartmentTypes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentType departmentType = db.DepartmentTypes.Find(id);
            if (departmentType == null)
            {
                return HttpNotFound();
            }
            return View(departmentType);
        }

        // POST: DepartmentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentTypeId,DepartmentTypeName")] DepartmentType departmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departmentType);
        }

        // GET: DepartmentTypes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentType departmentType = db.DepartmentTypes.Find(id);
            if (departmentType == null)
            {
                return HttpNotFound();
            }
            return View(departmentType);
        }

        // POST: DepartmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DepartmentType departmentType = db.DepartmentTypes.Find(id);
            db.DepartmentTypes.Remove(departmentType);
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
