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
        DBModels dbModel = new DBModels();
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

<<<<<<< HEAD
        
=======
>>>>>>> 16a0548b5aa6aeeea224c7b671a922a67b2d2f07
        public ActionResult StoreIndex(int? page, int? category)
        {
            using (DBModels dbModel = new DBModels())
            {
                var pageNumber = page ?? 1;
<<<<<<< HEAD
                var pageSize = 9;
=======
                var pageSize = 10;
>>>>>>> 16a0548b5aa6aeeea224c7b671a922a67b2d2f07
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
<<<<<<< HEAD
                
=======
                return View(dbModel.FOODs.OrderByDescending(x=>x.FoodId).ToPagedList(pageNumber, pageSize));
>>>>>>> 16a0548b5aa6aeeea224c7b671a922a67b2d2f07

            }
        }


        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        } 
        public ActionResult AddToCart(int foodId)
        {
            if (Session["cart"] == null)
            {
                List<CART> cart = new List<CART>();
                var food = dbModel.FOODs.Find(foodId);
                cart.Add(new CART()
                {
                    FOOD = food,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<CART> cart = ( List<CART>) Session["cart"];
                var food = dbModel.FOODs.Find(foodId);
                cart.Add(new CART()
                {
                    FOOD = food,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }
            
            return Redirect("StoreIndex");
        } 

        // GET: Store/Create
       
    }
}
