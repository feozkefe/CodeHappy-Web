﻿using KurumsalWeb.Models.DataContext;
using KurumsalWeb.Models.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalWeb.Controllers
{
    public class KimlikController : Controller
    {
        KurumsalDBContext db = new KurumsalDBContext();
        // GET: Kimlik
        public ActionResult Index()
        {
            return View(db.Kimlik.ToList());
        }

  

        // GET: Kimlik/Edit/5
        public ActionResult Edit(int id)
        {
            var kimlik = db.Kimlik.Where(x => x.KimlikID == id).SingleOrDefault();
            return View(kimlik);
        }

        // POST: Kimlik/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Kimlik kimlik,HttpPostedFileBase LogoURL)
        {
            if(ModelState.IsValid)
            {
                var k = db.Kimlik.Where(x => x.KimlikID == id).SingleOrDefault();

                /* if(LogoURL!=null)
                 {
                     if(System.IO.File.Exists(Server.MapPath(k.LogoURL)))
                     {
                         System.IO.File.Delete(Server.MapPath(k.LogoURL));
                     }
                     WebImage img = new WebImage(LogoURL.InputStream);
                     FileInfo imginfo =new FileInfo(LogoURL.FileName);

                     string logoname = LogoUrl.FileName + imginfo.Extension;
                     img.Resize(200, 200);
                     img.Save("~/Uploads/Kimlik/" + logoname);

                     kimlik.LogoURL = "/Uploads/Kimlik/" + logoname;
                 } */
                k.Title = kimlik.Title;
                k.Keywords = kimlik.Keywords;
                k.Description = kimlik.Description;
                k.LogoURL = kimlik.LogoURL;
                k.Unvan = kimlik.Unvan;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
