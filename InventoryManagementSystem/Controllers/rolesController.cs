using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem;

namespace InventoryManagementSystem.Controllers
{

    //[Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly Inventory_ManagementEntities db = new Inventory_ManagementEntities();

        // GET: roles
        public ActionResult Index()
        {
            if (Session["role"] == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else if (Session["role"].ToString() == "admin")
            {
                return View(db.roles.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Auth");
               // return RedirectToAction("Main", "Auth");

            }
            //System.Diagnostics.Debug.WriteLine($"Current user role: {Session["role"]}");
            //return View(db.roles.ToList());
        }

        // GET: roles/Details/5
        public ActionResult Details(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            role role = db.roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: roles/Create
        public ActionResult Create()
        {
            if (Session["role"] == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else if (Session["role"].ToString() == "admin")
            {
                List<SelectListItem> li = new List<SelectListItem>();
                li.Add(new SelectListItem() { Text = "Active", Value = "1" });
                li.Add(new SelectListItem() { Text = "In-Active", Value = "0" });
                ViewBag.abc = new SelectList(li, "Value", "Text");

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Auth");
                //return RedirectToAction("Main","Auth");

            }

            //List<SelectListItem> li = new List<SelectListItem>();
            //li.Add(new SelectListItem() { Text = "Active", Value = "1" });
            //li.Add(new SelectListItem() { Text = "In-Active", Value = "0" });
            //ViewBag.abc=new SelectList(li, "Value","Text");


            //return View();
        }

        // POST: roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "r_id,r_name,r_status")] role role)
        {
            if (ModelState.IsValid)
            {
                db.roles.Add(role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: roles/Edit/5
        public ActionResult Edit(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem() { Text = "Active", Value = "1" });
            li.Add(new SelectListItem() { Text = "In-Active", Value = "0" });
            ViewBag.abc = new SelectList(li, "Value", "Text");

            role role = db.roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "r_id,r_name,r_status")] role role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: roles/Delete/5
        public ActionResult Delete(byte? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            role role = db.roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(byte id)
        {
            role role = db.roles.Find(id);
            db.roles.Remove(role);
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
    }
}
