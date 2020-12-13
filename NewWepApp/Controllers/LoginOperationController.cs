using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewWepApp.Models;

namespace NewWepApp.Controllers
{
    public class LoginOperationController : Controller
    {
        NewsContext db = new NewsContext();
        public ActionResult login()
        {
            if (Request.Cookies["journalist"] != null)
            {
                Session["userId"] = Request.Cookies["journalist"].Values["id"];
                return RedirectToAction("profile", "user");
            }
            return View();
        }
        [HttpPost]
        public ActionResult login(loginData lo,bool remember)
        {
            user u = db.users.Where(n => n.email == lo.email && n.password == lo.password).FirstOrDefault();
           
            if (u != null)
            {
                if (remember)
                {
                    HttpCookie co = new HttpCookie("journalist");
                    co.Values.Add("id", u.userId.ToString());
                    co.Values.Add("email", u.email);
                    co.Expires = DateTime.Now.AddDays(15);
                    Response.Cookies.Add(co);
                }
                Session["userId"] = u.userId;
                //1: the id will recive by session in profile action 
                return RedirectToAction("Index", "Home");

                //2: the will recive by route attr in profile action but i have to recive (int id) in "profile" action  constractor 
                //so i  need to send parameter as rout attr    
                //return RedirectToAction("profile", "user", new { id = u.userId });

            }
            else
            {
                ViewBag.mess = "incorrect user name or password";
                return View();
            }
        }
        public ActionResult logout()
        {
            Session["userId"] = null;
            HttpCookie c = new HttpCookie("journalist");
            c.Expires = DateTime.Now.AddDays(-30);
            Response.Cookies.Add(c);
            return RedirectToAction("login");
        }
    }
}