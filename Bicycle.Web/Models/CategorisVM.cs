using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bicycle.Web.Models
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Display(Name = "Назва категорії")]
        public string Name { get; set; }
        [Display(Name = "Фото")]
        public string UrlLink { get; set; }
    }
    public class CategoryAddVM
    {
        [Display(Name = "Вкажіть назву категорії")]
        [Required(ErrorMessage = "Вкажіть назву категорії")]
        public string Name { get; set; }

        [Display(Name = "Оберіть фото для категорії")]
        [Required(ErrorMessage = "Оберіть фото для категорії")]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}