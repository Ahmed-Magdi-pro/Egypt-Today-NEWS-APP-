using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewWepApp.Models;

namespace NewWepApp.Controllers
{
    [HandleError]
    public class userController : Controller
    {
        NewsContext db = new NewsContext();

        
        public ActionResult register()
        {
            return View();
        }

        //this has no view i made it to try handle error page that is all !
        public ActionResult a()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult register(user u,HttpPostedFileBase img)
        {
            //if (ModelState.IsValid)
            //{

                img.SaveAs(Server.MapPath("~/attach/" + img.FileName));
                u.photo = img.FileName;
                db.users.Add(u);
                db.SaveChanges();
                return RedirectToAction("login", "LoginOperation");
            //}
            //else
            //{
            //    return View();
            //}
            
        }
           [HandleError] 
        public ActionResult profile()
        {
            //use that line when i dont use route attr in a (post / 'login') method
            int id = int.Parse(Session["userId"].ToString());
            
            user u = db.users.Where(n => n.userId ==id).FirstOrDefault();
            return View(u);
        }
        public ActionResult edit(int id)
        {
            user u = db.users.Where(n => n.userId == id).FirstOrDefault();
            return View(u);
        }
        [HttpPost]
        public ActionResult edit(user u)
        {
            user us = db.users.Where(n => n.userId == u.userId).FirstOrDefault();
            us.userName = u.userName;
            us.email = u.email;
            us.password = us.password;
            us.confirm_password = us.password;
            us.photo = us.photo;
            us.userId = us.userId;
            db.SaveChanges();

            return RedirectToAction("profile",new { id=us.userId});
        }

        public ActionResult check(string userName, int? userId)
        {
            if (userId == null)
            {
                user u = db.users.Where(n => n.userName == userName).FirstOrDefault();
                if (u == null)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(false, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(JsonRequestBehavior.AllowGet);
            }
            
        }

    }
}