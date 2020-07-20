using AutoMapper;
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
    public class AnimalsController : Controller
    {
        private readonly IRepository<Animal> repo;
        public AnimalsController()
        {
            repo = new AnimalRepostory();
        }
        // GET: Animals
        public ActionResult Index()
        {
            //ApplicationDbContext context = new ApplicationDbContext();

            //List<AnimalVM> model = context.Animals.Select(a =>
            //    new AnimalVM
            //    {
            //        Id=a.Id,
            //        Name=a.Name,
            //        ImageUrl=a.UrlLink
            //    }).ToList();

            var mapper =  MyAutoMapperConfig.GetAutoMapper();
            // сопоставление
            var model = mapper.Map<List<AnimalVM>>(repo.GetAll());

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
            if (ModelState.IsValid)
            {
                ApplicationDbContext context = new ApplicationDbContext();
                Animal animal = new Animal
                {
                    Name = model.Name,
                    UrlLink = model.ImageUrl,
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
    }
}