namespace Bicycle.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bicycle.Web.Entities.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bicycle.Web.Entities.ApplicationDbContext context)
        {
            context.Animals.AddOrUpdate(a => a.Id, new Entities.Animal
            {
                Id=1,
                Name="Собака польова",
                UrlLink = "https://10aypo2cxc90hff0b1y10mx1-wpengine.netdna-ssl.com/wp-content/uploads/2018/08/iStock-491827138-1-copy.jpg",
                IsDeleted=false,
                CreateDate = DateTime.Now,
                DeleteDate = DateTime.Now,
                ModifyDate = DateTime.Now
            });

            context.Animals.AddOrUpdate(a => a.Id, new Entities.Animal
            {
                Id = 2,
                Name = "Котик мурчик",
                UrlLink = "https://i.ytimg.com/vi/OCO3qYvqQ8w/hqdefault.jpg",
                IsDeleted = false,
                CreateDate = DateTime.Now,
                DeleteDate = DateTime.Now,
                ModifyDate = DateTime.Now
            });

            context.Animals.AddOrUpdate(a => a.Id, new Entities.Animal
            {
                Id = 3,
                Name = "Бобер домашній",
                UrlLink = "https://s00.yaplakal.com/pics/pics_original/3/8/2/1240283.jpg",
                IsDeleted = false,
                CreateDate = DateTime.Now,
                DeleteDate = DateTime.Now,
                ModifyDate = DateTime.Now
            });
        }
    }
}
