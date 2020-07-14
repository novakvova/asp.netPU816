using Bicycle.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bicycle.Web.Controllers
{
    
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            List<ProductVM> pr = new List<ProductVM>();
            pr.Add(new ProductVM { Name = "Iphone11", Quantity = 12, Price = 10 });
            pr.Add(new ProductVM { Name = "Iphone9", Quantity = 8, Price = 5 });
            return View(pr);
        }
        public ActionResult Search()
        {
            return View();
        }
    }
}