using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            //宣告回傳商品列表result
            List<Models.Product> result = new List<Models.Product>();

            //接收傳導的成功訊息
            ViewBag.ResultMessage = TempData["ResultMessage"];

            //使用CartsEntities類別，名稱為db
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                //使用LinQ語法抓取目前Products資料庫中所有資料
                result = (from s in db.Products select s).ToList();

                //將result傳送給檢視
                return View(result);
            }
        }

        //建立商品頁面
        public ActionResult Create()
        {
            return View();
        }

        //建立商品頁面 - 資料傳回處理
        [HttpPost] //指定只有使用POST方法才可進入
        public ActionResult Create(Models.Product postback)
        {

            if (this.ModelState.IsValid)
            {
                using (Models.CartsEntities db = new Models.CartsEntities())
                {
                    //將回傳資料postback加入至Products
                    db.Products.Add(postback);

                    //儲存自動資料
                    db.SaveChanges();

                    //設定成功訊息
                    TempData["ResultMessage"] = string.Format("商品{0}建立成功", postback.Name);

                    //轉導Product/Index頁面
                    return RedirectToAction("Index");
                }
            }
            //失敗訊息
            ViewBag.ResultMessage = "資料有誤，請檢查";

            //停留在Create頁面
            return View(postback);
        }

        public ActionResult Edit(int id)
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Products where s.Id == id select s).FirstOrDefault();
                if (result != default(Models.Product))//判斷此id是否有資料
                {
                    return View(result);
                }
                else
                {   //如果沒有資料則顯示錯誤訊息並導回index頁面
                    TempData["resultMessage"] = "資料有誤，請重新操作";
                    return RedirectToAction("Index");
                }
            }
        }

        //建立商品頁面 - 資料傳回處理
        [HttpPost]
        public ActionResult Edit(Models.Product postback)
        {
            if (this.ModelState.IsValid)
            {
                using (Models.CartsEntities db = new Models.CartsEntities())
                {
                    var result = (from s in db.Products where s.Id == postback.Id select s).FirstOrDefault();
                    result.Name = postback.Name;
                    result.PublishDate = postback.PublishDate;
                    result.Status = postback.Status;
                    result.DefaultImageId = postback.DefaultImageId;
                    result.Price = postback.Price;
                    result.Quantity = postback.Quantity;
                    result.CategoryId = postback.CategoryId;
                    result.Description = postback.Description;

                    //儲存所有變更
                    db.SaveChanges();

                    //如果沒有資料則顯示錯誤訊息並導回index頁面
                    TempData["ResultMessage"] = String.Format("商品[{0}]成功編輯",postback.Name) ;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View(postback);
            }
        }

        public ActionResult Delete(int id)
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Products where s.Id == id select s).FirstOrDefault();
                if (result != default(Models.Product))//判斷此id是否有資料
                {
                    db.Products.Remove(result);

                    db.SaveChanges();

                    TempData["ResultMessage"] = String.Format("商品[{0}]成功刪除",result.Name);

                    return RedirectToAction("Index");
                }
                else
                {   //如果沒有資料則顯示錯誤訊息並導回index頁面
                    TempData["resultMessage"] = "指定資料不存在，無法刪除";
                    return RedirectToAction("Index");
                }
            }
        }
    }
}