using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedOnlineFoodOrdering.Models;
using System.Data.Entity;

namespace AutomatedOnlineFoodOrdering.Controllers.Admin_Folder
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult CategoryIndex(string search)
        {
            using (DBModels dbModel = new DBModels())
            {

                return View(dbModel.CATEGORIES.Where(x => x.Name.StartsWith(search) || search == null).ToList());

            }
        }

        // GET: Category/Details/5
        public ActionResult CategoryDetails(int? id)
        {
            using (DBModels dbModel = new DBModels())
            {

                return View(dbModel.CATEGORIES.Where(x => x.CategoryId == id).FirstOrDefault());

            }
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

                return RedirectToAction("CategoryIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult EditCategory(int? id)
        {
            using (DBModels dbModel = new DBModels())
            {

                return View(dbModel.CATEGORIES.Where(x => x.CategoryId == id).FirstOrDefault());

            }
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult EditCategory(int? id, CATEGORy category)
        {
            try
            {
                // TODO: Add update logic here
                using (DBModels dbModel = new DBModels())
                {

                    dbModel.Entry(category).State = EntityState.Modified;
                    dbModel.SaveChanges();

                }
                return RedirectToAction("CategoryIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult DeleteCategory(int? id)
        {
            using (DBModels dbModel = new DBModels())
            {
                return View(dbModel.CATEGORIES.Where(x => x.CategoryId == id).FirstOrDefault());
            }
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult DeleteCategory(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                using (DBModels dbModel = new DBModels())
                {

                    CATEGORy category = dbModel.CATEGORIES.Where(x => x.CategoryId == id).FirstOrDefault();
                    dbModel.CATEGORIES.Remove(category);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("CategoryIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
