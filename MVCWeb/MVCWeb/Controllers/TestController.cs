﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWeb.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult GetCart()
        {
            var cart = Models.Cart.Operation.GetCurrentCart();

            cart.AddProduct(1);

            //回傳目前購物車中的商品總價
            return Content(string.Format("目前購物車總共: {0}元", cart.TotalAmount));
        }
    }
}