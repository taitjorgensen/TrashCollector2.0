using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TrashCollector2.Models;

namespace TrashCollector2.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        // GET: Employees
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Employees user = db.Employees.Where(e => e.UserName == User.Identity.Name).SingleOrDefault();
            var today = DateTime.Today.DayOfWeek.ToString();
            var customersByDay = db.Customers.Where(c => (c.PickUpDay == today) || (c.ExtraPickUp == DateTime.Today)).ToList();
            var custNotOnServiceBreak = customersByDay.Where(d => !((d.StartSuspendService <= DateTime.Today) && (d.EndSuspendService > DateTime.Today))).ToList();
            var customersInZip = custNotOnServiceBreak.Where(z => z.ZipCode == user.ZipCode);
            ViewBag.PickUps = new SelectList(customersInZip);
            return View(customersInZip);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,UserName,ZipCode")] Employees employees)
        {
            if (ModelState.IsValid)
            {                
                db.Employees.Add(employees);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,UserName")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employees);
        }
        public ActionResult PickUps()
        {
            var today = DateTime.Today.DayOfWeek.ToString();           
            ApplicationDbContext db = new ApplicationDbContext();
            var customersByDay = db.Customers.Where(c => c.PickUpDay == today);
            ViewBag.Days = new SelectList(days);
            ViewBag.PickUps = new SelectList(customersByDay);
            return View(customersByDay);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Button_Click(int customerId, bool complete = false)
        {
            var customerToCharge = db.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
            if (customerToCharge.BalanceDue == null)
            {
                customerToCharge.BalanceDue = 0;
            }
            double pickUpPrice = 15;    
            customerToCharge.BalanceDue += pickUpPrice;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
