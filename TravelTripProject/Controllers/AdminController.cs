using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Sınıflar;


namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult NewBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteBlog(int id)
        {
            var b = c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir", bl);
        }


        public ActionResult BlogUpdate(Blog b)
        {
            var blg = c.Blogs.Find(b.Id);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult CommentList()
        {
            var comments = c.Comments.ToList();
            return View(comments);
        }
        public ActionResult CommentDelete(int id)
        {
            var b = c.Comments.Find(id);
            c.Comments.Remove(b);
            c.SaveChanges();
            return RedirectToAction("CommentList");
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Comments.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult CommentUpdate(Comments y)
        {
            var yrm = c.Comments.Find(y.Id);
            yrm.KullaniciAdi= y.KullaniciAdi;
            yrm.Mail = y.Mail;
            yrm.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("CommentList");

        }
    }
}