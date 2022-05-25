using AutoMapper;
using CollegeApp.Models;
using CollegeApp.Models.Account.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CollegeApp
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; private set; }
        public static void Init()
        {
            var config = new MapperConfiguration(cfg => {
                // في حالة كان في اختلاف في اسماء 
                //cfg.CreateMap<Grade, Grade01>()
                //.ForMember(dest=> dest.CourseId , src => src.MapFrom(g=>g.CourseId))
                //.ForMember(dest => dest.Grade01Id, src => src.MapFrom(g => g.GradeId)).ReverseMap();

                cfg.CreateMap<Grade, Grade01>().ReverseMap();
                cfg.CreateMap<Grade, Grade02>().ReverseMap();
                cfg.CreateMap<Grade, Grade03>().ReverseMap();
                cfg.CreateMap<Grade, Grade04>().ReverseMap();
                cfg.CreateMap<Grade, Grade05>().ReverseMap();
                cfg.CreateMap<Grade, Grade06>().ReverseMap();
                cfg.CreateMap<User, UserModel>().ReverseMap();
            });

            Mapper = config.CreateMapper();
        }
    }
}