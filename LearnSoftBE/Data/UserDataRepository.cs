using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearnSoftBE.Data
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly LearnDataContext _context;

        public UserDataRepository (LearnDataContext context)
        {
            _context = context;
        }

        public async  Task<IEnumerable<User>> GetTestRepoResultAsync(string exp)
        {
            var user = _context.Users
                       .AsNoTracking()
                       .Include(s=>s.UserUnits)
                       .ThenInclude(p => p.UserDepartment)
                       .AsEnumerable();

            return await Task.FromResult(user);
        }

        public async Task<User> GetUserByLoginPasswordAsync(string login, string password)
        {
            var user = _context.Users
                .Where(p=>p.Email == login && p.Password == password).FirstOrDefault();

            return await Task.FromResult(user);
        }

        public async Task<IEnumerable<User>> GetUserByLoginPasswordAsync(string exp)
        {
            IEnumerable<User> matches = null;
            var splited_exp  = exp.Split(' ');
            System.Diagnostics.Debug.WriteLine(String.Join(", ",splited_exp));
            if (splited_exp.Length == 1)
            {
                matches = _context.Users
                        .Where(s => s.Name.Contains(exp) || s.Surname.Contains(exp))
                        .AsNoTracking()
                        .Include(s => s.UserUnits)
                        .ThenInclude(p => p.UserDepartment);
            }
            else
            {
                matches = _context.Users
                .Where(s => (s.Name.Contains(splited_exp[0]) && s.Surname.Contains(splited_exp[1]))
                        || (s.Name.Contains(splited_exp[1]) && s.Surname.Contains(splited_exp[0])))
                        .AsNoTracking()
                        .Include(s => s.UserUnits)
                        .ThenInclude(p => p.UserDepartment);
            }

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
