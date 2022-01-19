﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Models.ChatModels;

namespace LearnSoftBE.Models.UserModels
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Required]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }

        public byte[] Image { get; set; }
    }
}