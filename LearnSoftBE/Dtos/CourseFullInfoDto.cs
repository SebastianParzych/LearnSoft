using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Dtos
{
    public class CourseFullInfoDto
    {
        public int ClassCycleId { get; set; }
        public int StudentCount { get; set; }
        
        public CourseInfoDto ClassInfo { get; set; }

        public IEnumerable <StudentCourseDto> CourseAssignments { get; set; }
    }
    public class CourseInfoDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int Ects { get; set; }
        public int NumberOfHours { get; set; }
    }
    public class StudentCourseDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }


    }
}
