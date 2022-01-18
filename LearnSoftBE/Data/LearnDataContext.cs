using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;

namespace LearnSoftBE.Data
{
    public class LearnDataContext : DbContext
    {
        public LearnDataContext(DbContextOptions <LearnDataContext> opt) : base(opt)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
