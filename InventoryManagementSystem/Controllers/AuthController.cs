using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using InventoryManagementSystem;

namespace InventoryManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user u) {
            Inventory_ManagementEntities obj = new Inventory_ManagementEntities();
            var data=obj.st_getLoginDetails(u.u_username,u.u_password);
            foreach (var item in data)
            {
                if (item.Username == u.u_username && item.Password == u.u_password)
                {
                    string r = obj.st_getRoleWRTuser(u.u_username).Single();
                    if (r != null)
                    {
                        Session["role"] = r;
                        Session["name"] = u.u_username;
                        // Add debug statement
                        System.Diagnostics.Debug.WriteLine($"Role assigned: {r}");
                        return RedirectToAction("Main");
                    }

                    else
                    {
                    }
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("name");
            Session.Remove("role");
            return View("Index");
        }

        public ActionResult  Main() 
        {
            if (Session["name"] == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            { 
            return View();
            }
           
        }
    }
}