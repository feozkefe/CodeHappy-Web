using KurumsalWeb.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using KurumsalWeb.Models.Model;
using System.Web.Services;

namespace KurumsalWeb.Controllers
{
    public class HomeController : Controller
    {
        private KurumsalDBContext db = new KurumsalDBContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SliderPartial()
        {
            return View(db.Slider.ToList().OrderByDescending(x=>x.SliderID));
        }

        public ActionResult Services()
        {
            ViewBag.Services = db.Services.ToList().OrderByDescending(x => x.ServiceID);
            return View(db.Services.ToList());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(string name=null,string email=null,string subject=null,string message=null)
        {
            if(name!=null && email!=null && subject!=null && message!=null)
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "teamcodehappy@gmail.com";
                WebMail.Password = "Feyza1993";
                WebMail.SmtpPort = 587;
                WebMail.Send("teamcodehappy@gmail.com", subject, message, email);
                ViewBag.X = "Your message has been sent.Thank you";
            }
            else
            {
                ViewBag.X = "An error occurred. Please try again.";
            }
            return View();
        }

        public ActionResult Blog(int page = 1)
        {
            return View(db.Blog.Include("Category").OrderByDescending(x => x.BlogID).ToPagedList(page,5));
        }
          
        public ActionResult CategoryPartial()
        {
            return PartialView(db.Category.ToList().OrderBy(x=>x.CategoryName));
        }

        public ActionResult RecentBlogs()
        {
            return PartialView(db.Blog.ToList().OrderByDescending(x => x.BlogID));
        }

        public ActionResult BlogDetails(int id)
        {
            var b = db.Blog.Include("Category").Where(x => x.BlogID == id).SingleOrDefault();
            return View(b);
        }

        public ActionResult BlogCategory(int id,int page=1)
        {
            var b = db.Blog.Include("Category").OrderByDescending(x=>x.BlogID).Where(x => x.Category.CategoryID == id).ToPagedList(page,5);
            return View(b);
        }

        public JsonResult LeaveComment(string name, string email, string commentcontent, int blogid)
        {
            if (commentcontent == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            db.Comment.Add(new Comment { Name = name, Email = email, CommentContent = commentcontent, BlogID = blogid, confirmed = false });
            db.SaveChanges();

            return Json(false, JsonRequestBehavior.AllowGet);
        }

    }
}