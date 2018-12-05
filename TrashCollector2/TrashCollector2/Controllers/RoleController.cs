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
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (User.Identity.IsAuthenticated)
            {

                if (isAdminUser())
                {
                    return RedirectToAction("Index", "Users");
                }              
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            var Roles = db.Roles.ToList();
            return View(Roles);
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