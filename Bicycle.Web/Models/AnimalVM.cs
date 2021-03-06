﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bicycle.Web.Models
{
    public class AnimalVM
    {
        public int Id { get; set; }
        [Display(Name="Назва тварини")]
        public string Name { get; set; }
        [Display(Name = "Фото тварини")]
        public string UrlLink { get; set; }
    }
    public class AnimalAddVM
    {
        [Display(Name = "Вкажіть назву тварини")]
        [Required(ErrorMessage ="Вкажіть назву тварини")]
        public string Name { get; set; }

        [Display(Name = "Оберіть фото для тварини")]
        [Required(ErrorMessage = "Оберіть фото для тварини")]
        public HttpPostedFileBase ImageFile { get; set; }
    }

    public class AnimalEditVM
    {
        public int Id { get; set; }
        [Display(Name = "Вкажіть назву тварини")]
        [Required(ErrorMessage = "Вкажіть назву тварини")]
        public string Name { get; set; }

        [Display(Name = "Вкажіть посилання на фото тварини")]
        [Required(ErrorMessage = "Вкажіть фото для тварини")]
        public string ImageUrl { get; set; }
    }
}