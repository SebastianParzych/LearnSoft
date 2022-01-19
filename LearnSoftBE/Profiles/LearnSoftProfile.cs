using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Models.UserModels;
using LearnSoftBE.Models.UnitModels;
using LearnSoftBE.Dtos;

namespace LearnSoftBE.Profiles
{
    public class LearnSoftProfile : Profile
    {
        public LearnSoftProfile()
        {
            CreateMap<CourseAssignment, CourseListDto>()
                .Include<CourseAssignment, CourseMarksListDto>()
                .ForMember(p => p.Name, opt => opt.MapFrom(src => src.AssigmentCourse.ClassInfo.Name))
                .ForMember(p => p.CourseId, opt => opt.MapFrom(src => src.AssigmentCourse.ClassInfo.CourseId));

            CreateMap<CourseAssignment, CourseMarksListDto>()
                .ForMember(p => p.WeightedMark, opt => opt.MapFrom(src => src.WeightedMark))
                .ForMember(p => p.FinalMark, opt => opt.MapFrom(src => src.FinalMark));

            CreateMap<UserUnit, UserUnitsDtos>()
                .ForMember(p => p.UserUnitId, opt => opt.MapFrom(src => src.UserUnitId))
                .ForMember(p => p.DepartmentName, opt => opt.MapFrom(src => src.UserDepartment.DepartmentName))
                .ForMember(p => p.Role, opt => opt.MapFrom(src => src.Role));
            // .ForMember(p => p.UserUnitId, opt => opt.MapFrom(src => src.DepartmentId)

            CreateMap<User, UserSearchDtos>();



        }
    }
}
