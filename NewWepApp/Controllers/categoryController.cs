using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewWepApp.Models;

namespace NewWepApp.Controllers
{
    
    public class categoryController : Controller
    {
        NewsContext db = new NewsContext();
        
        public ActionResult categoryDDL()
        {
            SelectList sl = new SelectList(db.categories.ToList(), "categoryId", "categoryName");
            return View(sl);
        }

        public ActionResult categoryNews(int id)
        {
            List<news> news = db.news.Where(n => n.categoryId == id).ToList();
            ViewBag.news = news;
            return PartialView();
        }
      

    }
}