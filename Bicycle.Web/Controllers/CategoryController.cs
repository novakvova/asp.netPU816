using Bicycle.Web.DAL.Repositories;
using Bicycle.Web.Entities;
using Bicycle.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bicycle.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> repo;
        public CategoryController()
        {
            repo = new CategoryRepostory();
        }
        // GET: Category
        public ActionResult Index(FilterModel search)
        {
            //ViewBag.Title = "Категорії --";
            IEnumerable<Category> list;
            if (search.Name != null)
                list = repo.GetAll(x => x.Name.Contains(search.Name));
            else
            {
                list = repo.GetAll();
            }
            var mapper = MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var model = mapper.Map<List<CategoryVM>>(list);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryAddVM model)
        {
            //ModelState.AddModelError("", "Вас взломали :)!");
            //ModelState.AddModelError("", "Ха ха ха!");
            //return View(model);
            if (model.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Оберіть фото для тварини!");
                return View(model);
            }

            var list = repo.GetAll(x => x.Name == model.Name).ToList();
            if (list.Count > 0)
            {
                ModelState.AddModelError("Name", "Тварина з даним ім'ям уже є!");
                return View(model);
            }
            
            if (ModelState.IsValid)
            {
                string fileName = Path.GetRandomFileName() + ".jpg";
                string serverPath = Server.MapPath("~/Uploading");
                string fileSave = Path.Combine(serverPath, fileName);
                model.ImageFile.SaveAs(fileSave);

                Category animal = new Category
                {
                    Name = model.Name,
                    Image = fileName,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    DeleteDate = DateTime.Now
                };
                repo.Create(animal);
                repo.Save();
                //context.Animals.Add(animal);
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}