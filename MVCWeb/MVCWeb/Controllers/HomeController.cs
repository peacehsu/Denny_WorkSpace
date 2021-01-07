﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Products select s).ToList();
                return View(result);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Products
                              where s.Id == id
                              select s).FirstOrDefault();

                if (result == default(Models.Product))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(result);
                }
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult AddComment(int id, string Content)
        {
            //取得目前使用者ID
            var userId = HttpContext.User.Identity.GetUserId();

            var currentDateTime = DateTime.Now;

            var comment = new Models.ProductCommet()
            {
                ProductId = id,
                Content = Content,
                UserId = userId,
                CreateDate = currentDateTime
            };

            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                db.ProductCommets.Add(comment);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = id });
        }
    }
}