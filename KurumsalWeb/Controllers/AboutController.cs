using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class AboutController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: About
        public ActionResult Index()
        {
            var about = db.About.ToList();
            return View(about);
        }
        public ActionResult Edit(int id)
        {
            var about = db.About.Where(x => x.AboutID == id).SingleOrDefault();
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, About about)
        {

            if (ModelState.IsValid)
            {
                var a = db.About.Where(x => x.AboutID == id).SingleOrDefault();
                a.Description = about.Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}