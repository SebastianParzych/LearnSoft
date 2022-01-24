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
        Task<IEnumerable<User>> GetUserByLoginPasswordAsync(string exp);
        Task<Chat> GetChatWithMessagesAsync(int chatId);

        Task<IEnumerable<Message>> GetMessageListByChat(int chatId);
        Task<IEnumerable<UserChat>> GerUsersListByChat(int chatId);

        Task <Message> SendToChatMessageAsync(Message message);
        Task<Message> UndoChatMessageAsync(int id);
        Task<Message> FindMessageById(int id);
        Task<Chat> CreateNewChatAsync(Chat chat);

        void SaveConfigs();
    }
}

