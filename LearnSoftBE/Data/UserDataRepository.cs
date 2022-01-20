using LearnSoftBE.Models.ChatModels;
using LearnSoftBE.Models.CourseModels;
using LearnSoftBE.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Dtos;

namespace LearnSoftBE.Data
{
    public class UserDataRepository : IUserDataRepository
    {
        private readonly LearnDataContext _context;

        public UserDataRepository (LearnDataContext context)
        {
            _context = context;
        }

        public async Task<Chat> CreateNewChatAsync(Chat chat)
        {
            var new_chat = _context.Chats.Add(chat);
            _context.SaveChanges();

            return await Task.FromResult(new_chat.Entity);
        }

        public async Task<Chat> GetChatWithMessagesAsync(int chatId)
        {
            var chat = _context.Chats
                .AsNoTracking()
                .Where(p=>p.ChatId== chatId)
                .FirstOrDefault();
   
            chat.ChatMessageList = _context.Messages.AsNoTrackingWithIdentityResolution()
                .Where(p => p.ChatId == chatId).ToList();

            chat.Participants = _context.UserChats
                .AsNoTrackingWithIdentityResolution()
                .Include(p => p.User)
                .Where(p => p.ChatId == chatId).ToList();
       
            return await Task.FromResult(chat);
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

        public async  Task<Message> SendToChatMessageAsync(Message message)
        {
            var user_chats = _context.UserChats
                .AsNoTracking()
                .FirstOrDefault(p => (p.UserId == message.UserId )
                                && (p.ChatId == message.ChatId));
       
            // Check if there is Chat with Asigned too Dto Sender
            if (user_chats != null)
            {
                var new_mes = _context.Messages.Add(message);
                _context.SaveChanges();
                return await Task.FromResult(new_mes.Entity);
            }
            else
            {
                return null;
            }
        }

        public async Task<Message> UndoChatMessageAsync(int id)
        {
            var message = _context.Messages
                .AsNoTracking()
                .Where(p=>p.MessageId == id )
                .FirstOrDefault();

            _context.Messages.Attach(message);
            _context.Messages.Remove(message);
  
            return await Task.FromResult(message);
        }

        public async Task<Message> FindMessageById(int id)
        {
            var message = _context.Messages
               .AsNoTracking()
               .Where(p => p.MessageId == id)
               .FirstOrDefault();
            _context.Attach(message);
            return await Task.FromResult(message); 
        }

        public void SaveConfigs()
        {
            _context.SaveChanges();
        }
    }
}
