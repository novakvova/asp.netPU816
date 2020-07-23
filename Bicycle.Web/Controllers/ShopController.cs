using Bicycle.Web.DAL.Repositories;
using Bicycle.Web.Entities;
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
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Category> _categoryRepository;
        public ShopController()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepostory();
        }
        // GET: Category
        public ActionResult Index(FilterModel search)
        {
            //ViewBag.Title = "Категорії --";
            IEnumerable<Product> list;
            if (search.Name != null)
                list = _productRepository.GetAll(x => x.Name.Contains(search.Name));
            else
            {
                list = _productRepository.GetAll();
            }
            var mapper = MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var model = mapper.Map<List<ProductVM>>(list);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ProductAddVM model = new ProductAddVM();
            var categories = _categoryRepository.GetAll();
            var mapper = MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var select = mapper.Map<List<SelectItemVM>>(categories);

            model.SetCategoriesSelect(select);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductAddVM model)
        {
            if (ModelState.IsValid)
            {
                Product animal = new Product()
                {
                    Name = model.Name,
                    Price=model.Price,
                    Quantity=model.Quantity,
                    CategoryId=model.CategoryId,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    DeleteDate = DateTime.Now
                };
                _productRepository.Create(animal);
                _productRepository.Save();
                //context.Animals.Add(animal);
                //context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }




        public ActionResult Search()
        {
            return View();
        }
    }
}