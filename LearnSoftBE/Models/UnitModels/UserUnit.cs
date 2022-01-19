using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;

namespace LearnSoftBE.Models.UnitModels
{
    [Table("UserUnits")]
    public class UserUnit
    {
        [Key]
        [Required]
        public int UserUnitId { get; set; }

        [Required]
        [ForeignKey("DepartmentId")]
        public Department UserDepartment { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string Role { get; set; }

    }
}
