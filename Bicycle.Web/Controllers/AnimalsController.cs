using Bicycle.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bicycle.Web.Controllers
{
    public class AnimalsController : Controller
    {
        // GET: Animals
        public ActionResult Index()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var list = context.Animals.ToList();
            return View(list);
        }
    }
}