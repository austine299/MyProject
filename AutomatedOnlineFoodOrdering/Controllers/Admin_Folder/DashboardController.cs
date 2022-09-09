using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedOnlineFoodOrdering.Controllers.Admin_Folder
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult DashboardIndex()
        {
            return View();
        }
    }
}