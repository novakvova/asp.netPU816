using AutoMapper;
using Bicycle.Web.Entities;
using Bicycle.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bicycle.Web
{
    public static class MyAutoMapperConfig
    {
        public static Mapper GetAutoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Animal, AnimalVM>());

            var mapper = new Mapper(config);

            return mapper;
        }
    }
}