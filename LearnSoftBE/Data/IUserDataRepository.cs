using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Models.UserModels;
using LearnSoftBE.Models.ChatModels;
using LearnSoftBE.Dtos;

namespace LearnSoftBE.Data
{
    public interface IUserDataRepository
    {
        Task<IEnumerable<CourseAssignment>> GetUserCoursesListAsync(int UserId);
        Task<User> GetUserByLoginPasswordAsync(string login, string password);
        Task<IEnumerable<User>> GetUserSearchResultsAsync(string exp);
        Task<User> GetUserInfoAsync(int userId);
        Task<CourseCycle> GetFullCourseInfo(int cousrseId);
        Task<IEnumerable<CourseAssignment>> GetAsignedUsersToCourse(int cousrseId);
        Task<IEnumerable<Message>> GetDirectMessagesAsync(int sender, int reciever);
        Task<Message> UndoChatMessageAsync(int id);
        Task<Message> FindMessageById(int id);
        Task<Message> CreateMessageAsync(Message message);
        Task<Message> UndoMessageAsync(Message message);
        Task<IEnumerable<Message>> SetMessagesSeenAsync(int reader, int sender);
        void SaveConfigs();
    }
}

