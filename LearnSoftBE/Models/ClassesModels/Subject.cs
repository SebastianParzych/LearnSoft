using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Models.ClassesModels
{
    [Table("Subjects")]
    public class Subject
    {
        public int IdSubject { get; set; }

        public string Name { get; set; }
    }
}
