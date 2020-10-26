using KurumsalWeb.Models;
using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class AdminController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.BlogCount = db.Blog.Count();
            ViewBag.CategoryCount = db.Category.Count();
            ViewBag.ServiceCount = db.Services.Count();
            var sorgu = db.Category.ToList();
            return View(sorgu);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var a = db.Admin.Where(x => x.Email == admin.Email).SingleOrDefault();
            if(a.Email==admin.Email && a.Password==admin.Password)
            {
                Session["adminid"] = a.AdminID;
                Session["email"] = a.Email;
                return RedirectToAction("Index","Admin");
            }
            return View(admin);
            
        }

        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["email"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");

        }
    }
}