using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class RouteController : Controller
    {
        // GET: Route
        public ActionResult Index()
        {
            var result = MVCWeb.Models.Route.TempProducts.getAllproducts();


            return View(result);
        }

        public ActionResult Index2(string id)
        {
            return Content(string.Format("id的值為:{0}", id));
        }

        public ActionResult Index3(string id,string page)
        {
            return Content(string.Format("id 的值為:{0}, page的值:{1}", id, page));
        }
    }
}