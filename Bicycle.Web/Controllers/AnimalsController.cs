using AutoMapper;
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
    public class AnimalsController : Controller
    {
        private readonly IRepository<Animal> repo;
        public AnimalsController()
        {
            repo = new AnimalRepostory();
        }
        // GET: Animals
        public ActionResult Index(FilterModel search)
        {
            //ApplicationDbContext context = new ApplicationDbContext();

            //List<AnimalVM> model = context.Animals.Select(a =>
            //    new AnimalVM
            //    {
            //        Id=a.Id,
            //        Name=a.Name,
            //        ImageUrl=a.UrlLink
            //    }).ToList();
            IEnumerable<Animal> list;
            if (search.Name!=null)
                list = repo.GetAll(x=>x.Name.Contains(search.Name));
            else
            {
                list = repo.GetAll();
            }
            var mapper =  MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var model = mapper.Map<List<AnimalVM>>(list);

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AnimalAddVM model)
        {
            string fileName = Path.GetRandomFileName()+".jpg";
            string serverPath = Server.MapPath("~/Uploading");
            string fileSave = Path.Combine(serverPath, fileName);
            model.ImageFile.SaveAs(fileSave);
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                Animal animal = new Animal
                {
                    Name = model.Name,
                    UrlLink = fileName,
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    DeleteDate = DateTime.Now
                };
                context.Animals.Add(animal);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            repo.Save();
            return RedirectToAction("Index");
        }


    }
}