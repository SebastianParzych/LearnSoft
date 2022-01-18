﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;

namespace LearnSoftBE.Models.UnitModels
{
    [Table("Departments")]
    public class Department
    {
        [Required]
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [ForeignKey("InstituteId")]
        [Required]
        public  Institute Institute { get; set; }

        [ForeignKey("UserId")]
        [Required]
        public  Tutor Coordinator { get; set; }
    }
}
