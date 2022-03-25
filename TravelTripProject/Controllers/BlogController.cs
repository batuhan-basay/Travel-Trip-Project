using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Sınıflar;

namespace TravelTripProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c = new Context();
        BlogComment bc = new BlogComment();
        public ActionResult Index()
        {
            //var blogs = c.Blogs.ToList();
            bc.Deger1 = c.Blogs.ToList();
            bc.Deger3 = c.Blogs.Take(3).ToList();
            return View(bc);
        }
    
         public ActionResult BlogDetail(int id)
         {

            // var blogfind = c.Blogs.Where(x => x.Id == id).ToList();
            bc.Deger1 = c.Blogs.Where(x => x.Id == id).ToList();
            bc.Deger2 = c.Comments.Where(x => x.BlogId == id).ToList();
            return View(bc);
         }
        [HttpGet]
        public PartialViewResult YorumYap( int id)
        {
            ViewBag.deger = id;
            return PartialView();

        }

         [HttpPost]
        public PartialViewResult YorumYap(Comments d)
        {
            c.Comments.Add(d);
            c.SaveChanges();
            return PartialView();
        }
    }

}