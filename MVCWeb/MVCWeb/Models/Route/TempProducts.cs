using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWeb.Models.Route
{
    public class TempProducts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public static List<TempProducts> getAllproducts()
        {
            List<TempProducts> result = new List<TempProducts>();

            result.Add(new MVCWeb.Models.Route.TempProducts
            {
                ID = 1,
                Name = "自動鉛筆",
                Price = 30.0m
            });

            result.Add(new MVCWeb.Models.Route.TempProducts
            {
                ID = 2,
                Name = "記事本",
                Price = 50.0m
            });

            result.Add(new MVCWeb.Models.Route.TempProducts
            {
                ID = 3,
                Name = "橡皮擦",
                Price = 10.0m
            });

            return result;
        }
    }
}