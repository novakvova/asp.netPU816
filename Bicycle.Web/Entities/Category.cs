using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bicycle.Web.Entities
{
    [Table("tblCategories")]
    public class Category : BaseEntity<int>
    {
        [Required, StringLength(255)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Image { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}