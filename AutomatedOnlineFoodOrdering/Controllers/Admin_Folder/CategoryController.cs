using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedOnlineFoodOrdering.Models;

namespace AutomatedOnlineFoodOrdering.Controllers.Admin_Folder
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryIndex()
        {
            using (DBModels dbModel = new DBModels())
            {

                return View(dbModel.CATEGORIES.ToList());

            }
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult AddCategory()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult AddCategory(CATEGORy category)
        {
            try
            {
                // TODO: Add insert logic here

                using (DBModels dbModel = new DBModels())
                {

                    dbModel.CATEGORIES.Add(category);
                    dbModel.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
