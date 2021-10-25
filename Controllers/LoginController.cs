using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication44.Models;

namespace WebApplication44.Controllers
{
    public class LoginController : Controller
    {
        lindaaEntities db = new lindaaEntities();
        // GET: Login
        public ActionResult Login()
        {

           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(user objchk)
        {
            if (ModelState.IsValid)
            {
                using (lindaaEntities db = new lindaaEntities())
                {
                    var obj = db.users.Where(a => a.username.Equals(objchk.username) && a.password.Equals(objchk.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.id.ToString();
                        Session["UserName"] = obj.username.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The UserName or Password is Incorrect");

                    }
                }
            }

           
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
           

        }
    }
}