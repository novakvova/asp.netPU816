using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bicycle.Web.Models
{
    public class ProductVM
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}