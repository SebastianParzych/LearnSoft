using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Models.UserModels;
namespace LearnSoftBE.Data
{
    public interface IUserDataRepository
    {
        Task<IEnumerable<CourseAssignment>> GetUserCoursesListAsync(int UserId);
        Task<User> GetUserByLoginPasswordAsync(string login, string password);

        Task<IEnumerable<User>> GetUserByLoginPasswordAsync(string exp);

    }
}

