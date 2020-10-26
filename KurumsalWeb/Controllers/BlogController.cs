using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private KurumsalDBContext db = new KurumsalDBContext();
        public ActionResult Index()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return View(db.Blog.Include("Category").ToList().OrderByDescending(x=>x.BlogID));
        }

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID","CategoryName");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog,HttpPostedFileBase ImageURL)
        {
            if(ModelState.IsValid)
            {
                if (ImageURL != null)
                {

                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(ImageURL.FileName);

                    string logoname = ImageURL.FileName + imginfo.Extension;
                    img.Resize(1024, 768);
                    img.Save("~/Uploads/Blog/" + logoname);

                    blog.ImageURL = "/Uploads/Blog/" + logoname;
                }
                db.Blog.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var b = db.Blog.Where(x => x.BlogID == id).SingleOrDefault();

            if (b == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Category, "CategoryID", "CategoryName", b.CategoryID);
            return View(b);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id,Blog blog, HttpPostedFile ImageURL)
        {
            if (ModelState.IsValid)
            {
                var b = db.Blog.Where(x => x.BlogID == id).SingleOrDefault();
                if (ImageURL == null)
                {
                    if (System.IO.File.Exists(Server.MapPath(b.ImageURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(b.ImageURL));
                    }
                    WebImage img = new WebImage(ImageURL.InputStream);
                    FileInfo imginfo = new FileInfo(ImageURL.FileName);

                    string logoname = ImageURL.FileName + imginfo.Extension;
                    img.Resize(1024, 768);
                    img.Save("~/Uploads/Blog/" + logoname);

                    b.ImageURL = "/Uploads/Blog/" + logoname;
                }

                b.BlogName = blog.BlogName;
                b.BlogContent = blog.BlogContent;
                b.CategoryID = blog.CategoryID;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        public ActionResult Delete(int id)
        {
            var b = db.Blog.Find(id);
            if(b==null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(Server.MapPath(b.ImageURL)))
            {
                System.IO.File.Delete(Server.MapPath(b.ImageURL));
            }
            db.Blog.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}