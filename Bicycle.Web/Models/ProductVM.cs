using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bicycle.Web.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        [Display(Name = "Назва товара")]
        public string Name { get; set; }
        [Display(Name = "Кількість")]
        public int Quantity { get; set; }
        [Display(Name = "Категорія")]
        public string CategoryName { get; set; }
        [Display(Name = "Ціна")]
        public decimal Price { get; set; }
    }

    public class ProductAddVM
    {
        private List<SelectItemVM> _categories;

        public void SetCategoriesSelect(List<SelectItemVM> categories)
        {
            _categories = categories;
        }

        [Display(Name = "Назва товара")]
        [Required(ErrorMessage = "Вкажіть назву товара")]
        public string Name { get; set; }
        [Display(Name = "Кількість")]
        [Required(ErrorMessage = "Вкажіть кількість товара")]
        public int Quantity { get; set; }
        [Display(Name = "Оберіть категорію")]
        [Required(ErrorMessage = "Вкажіть категорію")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> CategoriesSelect
        {
            get { return new SelectList(_categories, "Id", "Name"); }
        }

        [Display(Name = "Ціна")]
        [Required(ErrorMessage = "Вкажіть ціну товара")]
        public decimal Price { get; set; }
    }
}