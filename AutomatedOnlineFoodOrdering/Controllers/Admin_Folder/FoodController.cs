using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedOnlineFoodOrdering.Models;
using System.Data.Entity;

namespace AutomatedOnlineFoodOrdering.Controllers.Admin_Folder
{
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult FoodIndex()
        {
            using (DBModels dbModel = new DBModels())
            {

                return View(dbModel.FOODs.OrderByDescending(x => x.FoodId).ToList());

            }
        }

        // GET: Admin/Details/5
        public ActionResult FoodDetails(int? id)
        {
            using (DBModels dbModel = new DBModels())
            {

                return View(dbModel.FOODs.Where(x => x.FoodId== id).FirstOrDefault());

            }
            
        }

        // GET: Admin/Create
        public ActionResult AddFood()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult AddFood(FOOD food)
        {
            try
            {
                // TODO: Add insert logic here

                using (DBModels dbModel = new DBModels())
                {

                    dbModel.FOODs.Add(food);
                    dbModel.SaveChanges();

                }

                return RedirectToAction("FoodIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Edit/5
        public ActionResult EditFood(int? id)
        {
            using (DBModels dbModel = new DBModels())
            {

                return View(dbModel.FOODs.Where(x => x.FoodId == id).FirstOrDefault());

            }
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult EditFood(int? id, FOOD food)
        {
            try
            {
                // TODO: Add update logic here
                using (DBModels dbModel = new DBModels())
                {
                    
                    dbModel.Entry(food).State = EntityState.Modified;
                    dbModel.SaveChanges();

                }
                return RedirectToAction("FoodIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Food/Delete/5
        public ActionResult DeleteFood(int? id)
        {
            using (DBModels dbModel = new DBModels())
            {
                return View(dbModel.FOODs.Where(x => x.FoodId == id).FirstOrDefault());
            }
        }

        // POST: Food/Delete/5
        [HttpPost]
        public ActionResult DeleteFood(int? id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DBModels dbModel = new DBModels())
                {

                    FOOD food = dbModel.FOODs.Where(x => x.FoodId == id).FirstOrDefault();
                    dbModel.FOODs.Remove(food);
                    dbModel.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
