using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.UserModels;
using LearnSoftBE.Models.ChatModels;
using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Models.UnitModels;
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
        public DbSet<University> Universities { get; set; }
        public DbSet<Institute> Institues { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCycle> CourseCycles { get; set; }
        public DbSet<UserUnit> UserUnits { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }
        public DbSet<CourseTutor> CourseTutors { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserChat> UserChats { get; set; }
    }

}
