using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedOnlineFoodOrdering.Models;
using PagedList;
using System.Net;


namespace AutomatedOnlineFoodOrdering.Controllers.Store_Folder
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Home()
        {
           
            return View();
        }

        public PartialViewResult ViewCategory()
        {
            using (DBModels dbModel = new DBModels())
            {

                var CategoryList = dbModel.CATEGORIES.OrderBy(x => x.Name).ToList();
                return PartialView(CategoryList);
            }
        }

        public ActionResult StoreIndex(int? page, int? category)
        {
            using (DBModels dbModel = new DBModels())
            {
                var pageNumber = page ?? 1;
                var pageSize = 10;
                if (category != null)
                {
                    ViewBag.category = category;
                    return View(dbModel.FOODs.OrderByDescending(x => x.FoodId)
                        .Where(x => x.CategoryId == category)
                        .ToPagedList(pageNumber, pageSize));
                }
                else
                {
                    return View(dbModel.FOODs.OrderByDescending(x => x.FoodId).ToPagedList(pageNumber, pageSize));
                }
                return View(dbModel.FOODs.OrderByDescending(x=>x.FoodId).ToPagedList(pageNumber, pageSize));

            }
        }


        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
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

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
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
