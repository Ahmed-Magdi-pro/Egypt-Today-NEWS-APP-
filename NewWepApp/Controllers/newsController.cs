using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewWepApp.Models;

namespace NewWepApp.Controllers
{
    
    public class newsController : Controller
    {
        NewsContext db = new NewsContext();
        
        
        //method to fill dropdown list with categories items
        public void fillddl()
        {
            List<category> ctgs = db.categories.ToList();
            SelectList slt = new SelectList(ctgs, "categoryId", "categoryName");
            ViewBag.categoryList = slt;
        }
        

        public ActionResult allNews()
        {
            List<news> news = db.news.OrderBy(n => n.categoryId).ToList(); 
            return View(news);
        }

        public ActionResult addNews()
        {
            if (Session["userId"] != null)
            {
                fillddl();
                return View();
            }
            else
            {
                fillddl();

                return RedirectToAction("allNews");
            }

            
        }
        [HttpPost]
        public ActionResult addNews(news n,HttpPostedFileBase newsImg)
        {
            int id =int.Parse(Session["userId"].ToString());
            if (id>0)
            {
                newsImg.SaveAs(Server.MapPath("~/Attach/NewsImages/" + newsImg.FileName));
                n.photo = newsImg.FileName;
                n.userId = id;
                n.datetime = DateTime.Now;

                db.news.Add(n);
                db.SaveChanges();
                return RedirectToAction("allNews");
            }
            else
            {
                List<category> category = db.categories.ToList();
                SelectList slt = new SelectList(category, "categoryId", "categoryName");
                ViewBag.categoryList = slt;
                return View();
            }

        }
        public ActionResult readMore(int id)
        {
            news N = db.news.Where(n=> n.newsId == id).FirstOrDefault();
            return View(N);
        }
        public ActionResult edit(int id)
        {
            if (Session["userId"] != null)
            {
                fillddl();
                news N = db.news.Where(n => n.newsId == id).FirstOrDefault();
                return View(N);
            }
            else
            {
                fillddl();
                return RedirectToAction("allNews");
            }
        }
        [HttpPost]
        public ActionResult edit(news newsItem, HttpPostedFileBase newsImg)
        {
            
            newsImg.SaveAs(Server.MapPath("~/Attach/NewsImages/" + newsImg.FileName));

            news N = db.news.Where(n => n.newsId == newsItem.newsId).FirstOrDefault();
            N.photo = newsImg.FileName;
            N.title = newsItem.title;
            N.brief = newsItem.brief;
            N.categoryId = newsItem.categoryId;
            N.datetime = DateTime.Now;
            N.description = newsItem.description;
            db.SaveChanges();
            return RedirectToAction("userNews");
               
        }
        public ActionResult userNews()
        {
            if(Session["userId"] != null)
            {
                int uId = int.Parse(Session["userId"].ToString());
                List<news> newsList = db.news.OrderBy(n => n.userId == uId).ToList();
                return View(newsList);
            }
            else
            {
                return RedirectToAction("allNews");
            }
            
           
        }
        public ActionResult modaldisplay(int id)
        {
            news ne = db.news.Where(n => n.newsId == id).FirstOrDefault();
            ViewBag.n = ne;
            return PartialView();
        }
    }
}