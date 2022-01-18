using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;



namespace LearnSoftBE.Models.UserModels
{
    [Table("Tutors")]
    public class Tutor : User
    {
        public string Degree { get; set; }
    }
}
