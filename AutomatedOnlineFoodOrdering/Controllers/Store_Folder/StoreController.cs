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

        
        public ActionResult StoreIndex(int? page, int? category)
        {
            using (DBModels dbModel = new DBModels())
            {
                var pageNumber = page ?? 1;
                var pageSize = 9;
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
