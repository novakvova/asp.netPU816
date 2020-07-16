using System;
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
        public string ImageUrl { get; set; }
    }
    public class AnimalAddVM
    {
        [Display(Name = "Вкажіть назву тварини")]
        public string Name { get; set; }
        [Display(Name = "Вкажіть посилання на фото тварини")]
        public string ImageUrl { get; set; }
    }
}