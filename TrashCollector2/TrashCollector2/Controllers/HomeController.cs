using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrashCollector2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (User.IsInRole("Customer".Trim()))
            {
                return RedirectToAction("Index", "Customers");
            }
            else if (User.IsInRole("Employee".Trim()))
            {
                return RedirectToAction("Index", "Employees");
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Tait's Trash Collection is here to serve you.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "TTC contact page.";

            return View();
        }
    }
}