using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector2.Models;

namespace TrashCollector2.Controllers
{
    public class UsersController : Controller
    {
        [Authorize]
        // GET: Users
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;
                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Yes";
                }
                else if (User.IsInRole("Customer"))
                {
                    RedirectToAction("Index", "Customers");
                }
                else if (User.IsInRole("Employee"))
                {
                    RedirectToAction("Index", "Employees");
                }                
                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged In";
            }
            return View();
        }

        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext db = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}