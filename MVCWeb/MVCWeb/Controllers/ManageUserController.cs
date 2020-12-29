using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class ManageUserController : Controller
    {
        // GET: ManageUser
        public ActionResult Index()
        {
            ViewBag.ResultMessage = TempData["ResultMessage"];
            using (Models.UserEntities db = new Models.UserEntities())
            {
                var result = (from s in db.AspNetUsers
                              select new Models.ManageUser
                              {
                                  Id = s.Id,
                                  UserName = s.UserName,
                                  Email = s.Email
                              }).ToList();

                return View(result);
            }
        }

        public ActionResult Edit(string id)
        {
            using (Models.UserEntities db = new Models.UserEntities())
            {
                var result = (from s in db.AspNetUsers
                              where s.Id == id
                              select new Models.ManageUser
                              {
                                  Id = s.Id,
                                  UserName =s.UserName,
                                  Email = s.Email
                              }).FirstOrDefault();
                if (result != default(Models.ManageUser))//判斷此id是否有資料
                {
                    return View(result);
                }
            }
            //如果沒有資料則顯示錯誤訊息並導回index頁面
            TempData["ResultMessage"] = String.Format("使用者[{0}]不存在，請重新操作", id) ;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Models.ManageUser postback)
        {
            using (Models.UserEntities db = new Models.UserEntities())
            {
                var result = (from s in db.AspNetUsers
                              where s.Id == postback.Id
                              select s).FirstOrDefault();
                if (result != default(Models.AspNetUsers))
                {
                    result.UserName = postback.UserName;
                    result.Email = postback.Email;
                    db.SaveChanges();
                    //設定成功訊息
                    TempData["ResultMessage"] = String.Format("使用者[{0}]成功編輯", postback.UserName);
                    return RedirectToAction("Index");
                }
            }
            //設定錯誤訊息
            TempData["ResultMessage"] = String.Format("使用者[{0}]不存在，請重新操作", postback.UserName);
            return RedirectToAction("Index");
        }

    }
}