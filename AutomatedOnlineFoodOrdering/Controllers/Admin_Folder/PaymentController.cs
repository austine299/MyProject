using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutomatedOnlineFoodOrdering.Models;

namespace AutomatedOnlineFoodOrdering.Controllers.Admin_Folder
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult PaymentIndex()
        {
            using (DBModels dbModel = new DBModels())
            {

                return View(dbModel.PAYMENTs.ToList());

            }
        }

        // GET: Payment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       
    }
}
