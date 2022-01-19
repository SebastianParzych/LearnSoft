using LearnSoftBE.Models.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.CourseModels;
using Microsoft.EntityFrameworkCore;

namespace LearnSoftBE.Data
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly LearnDataContext _context;

        public UserDataRepository (LearnDataContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByLoginPasswordAsync(string login, string password)
        {
            var user = _context.Users
                .Where(p=>p.Email == login && p.Password == password).FirstOrDefault();

            return await Task.FromResult(user);
        }

        public async Task<IEnumerable<User>> GetUserByLoginPasswordAsync(string exp)
        {
            var matches = _context.Users
                .Where(s => s.Name.Contains(exp) || s.Surname.Contains(exp));

            return await Task.FromResult(matches);

        }

        public async Task<IEnumerable<CourseAssignment>> GetUserCoursesListAsync(int UserId)
        {

            var course_list = _context.CourseAssignments
                .Include(p=> p.AssigmentCourse.ClassInfo)
                .Include(p =>p.AssigmentCourse.ExeDepartment)
                .Where(p=> p.AssigmentUser.UserId == UserId)
                .AsEnumerable();

            return await Task.FromResult(course_list);
        }


    }
}
