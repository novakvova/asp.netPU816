using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Bicycle.Web.Entities
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Animal> Animals { get; set; }
    }
}