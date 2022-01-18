using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models;



namespace LearnSoftBE.Models.UserModels
{
    [Table("Students")]
    public class Student : User
    {
        public string GroupName { get; set; }

        [ForeignKey("ClassId")]
        public IEnumerable <Class> ClassesList { get; set; }
    }
}
