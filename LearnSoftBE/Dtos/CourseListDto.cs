using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Dtos
{
    public class CourseListDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

    }
    public class CourseMarksListDto : CourseListDto
    {
        public float WeightedMark { get; set; }
        public float  FinalMark{ get; set; }

    }
}
