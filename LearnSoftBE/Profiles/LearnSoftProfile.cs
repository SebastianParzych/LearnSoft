using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Dtos;
using AutoMapper;

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


        }
    }
}
