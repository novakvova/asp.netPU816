using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bicycle.Web.Entities
{
    [Table("tblProducts")]
    public class Product : BaseEntity<int>
    {
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required, StringLength(255)]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }

        public virtual Category Category { get; set; }
    }
}