using AutoMapper;
using Bicycle.Web.Entities;
using Bicycle.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bicycle.Web
{
    public class BicycleMappingProfile : Profile
    {
        public BicycleMappingProfile()
        {
            CreateMap<Animal, AnimalVM>()
                    .ForMember("UrlLink", opt => opt.MapFrom(c => "/Uploading/" + c.UrlLink));

            CreateMap<Category, CategoryVM>()
                    .ForMember("UrlLink", opt => opt.MapFrom(c => "/Uploading/" + c.Image));
        }
    }

    public static class MyAutoMapperConfig
    {
        public static Mapper GetAutoMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<BicycleMappingProfile>());

            var mapper = new Mapper(config);

            return mapper;
        }
    }
}