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
        public DBModels dbModel = new DBModels();
        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var category = dbModel.CATEGORIES.ToList();
            foreach(var item in category)
            {
                list.Add(new SelectListItem { Value = item.CategoryId.ToString(), Text = item.Name });
            }

            return list;

        }
        // GET: Food
        public ActionResult FoodIndex(string search)
        {
            using (DBModels dbModel = new DBModels())
            {

                ViewBag.CategoryList = GetCategory();
                return View(dbModel.FOODs.OrderByDescending(x => x.FoodId)
                        .Where(x => x.FoodName.StartsWith(search) || search == null).ToList());

            }
        }

        // GET: Admin/Details/5
        public ActionResult FoodDetails(int? id)
        {
            using (DBModels dbModel = new DBModels())
            {

                ViewBag.CategoryList = GetCategory();
                return View(dbModel.FOODs.Where(x => x.FoodId== id).FirstOrDefault());

            }
            
        }

        // GET: Admin/Create
        public ActionResult AddFood()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult AddFood(FOOD food, HttpPostedFileBase file)
        {
            try 
            {
                // TODO: Add insert logic here

                using (DBModels dbModel = new DBModels())
                {
                    string pic = null;
                    if(file != null)
                    {
                        pic = System.IO.Path.GetFileName(file.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/FoodImg/"), pic);

                        file.SaveAs(path);

                    }
                    food.ImageUrl = pic;
                    food.createDate = DateTime.Now;
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

                ViewBag.CategoryList = GetCategory();
                return View(dbModel.FOODs.Where(x => x.FoodId == id).FirstOrDefault());

            }
        }

        // POST: Food/Edit/5
        [HttpPost]
        public ActionResult EditFood(int? id, FOOD food, HttpPostedFileBase file)
        {
            try
            {
                // TODO: Add update logic here
                using (DBModels dbModel = new DBModels())
                {
                    string pic = null;
                    if (file != null)
                    {
                        pic = System.IO.Path.GetFileName(file.FileName);
                        string path = System.IO.Path.Combine(Server.MapPath("~/FoodImg/"), pic);

                        file.SaveAs(path);

                    }
                    food.ImageUrl = file !=null ? pic : food.ImageUrl;
                    food.createDate = DateTime.Now;
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
                ViewBag.CategoryList = GetCategory();
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
                return RedirectToAction("FoodIndex");
            }
            catch
            {
                return View();
            }
        }
    }
}
