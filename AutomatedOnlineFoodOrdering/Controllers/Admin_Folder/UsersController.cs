using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedOnlineFoodOrdering.Models;

namespace AutomatedOnlineFoodOrdering.Controllers.Admin_Folder
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult UsersIndex()
        {
            using (DBModels dbModel = new DBModels())
            {

                return View(dbModel.USERS.ToList());

            }
        }


        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Users/Delete/5
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
