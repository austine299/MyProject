using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutomatedOnlineFoodOrdering.Models;

namespace AutomatedOnlineFoodOrdering.Controllers
{
    public class ViewCategoryController : Controller
    {
        private DBModels db = new DBModels();

        // GET: ViewCategory
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialViewCategory()
        {
            using (DBModels dbModel = new DBModels())
            {

                var CategoryList = dbModel.CATEGORIES.OrderBy(x => x.Name).ToList();
                return PartialView(CategoryList);
            }
        }

        //// GET: ViewCategory/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CATEGORy cATEGORy = db.CATEGORIES.Find(id);
        //    if (cATEGORy == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cATEGORy);
        //}

        //// GET: ViewCategory/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ViewCategory/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CategoryId,Name,ImageUrl,IsActive,CreateDate")] CATEGORy cATEGORy)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CATEGORIES.Add(cATEGORy);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(cATEGORy);
        //}

        //// GET: ViewCategory/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CATEGORy cATEGORy = db.CATEGORIES.Find(id);
        //    if (cATEGORy == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cATEGORy);
        //}

        //// POST: ViewCategory/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CategoryId,Name,ImageUrl,IsActive,CreateDate")] CATEGORy cATEGORy)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cATEGORy).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(cATEGORy);
        //}

        //// GET: ViewCategory/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CATEGORy cATEGORy = db.CATEGORIES.Find(id);
        //    if (cATEGORy == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cATEGORy);
        //}

        //// POST: ViewCategory/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CATEGORy cATEGORy = db.CATEGORIES.Find(id);
        //    db.CATEGORIES.Remove(cATEGORy);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
