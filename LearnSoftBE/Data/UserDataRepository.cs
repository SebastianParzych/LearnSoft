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



        public async Task<IEnumerable<Message>> GetDirectMessagesAsync(int sender, int reciever)
        {
            var chat = _context.Messages
                .AsNoTrackingWithIdentityResolution()
                .Where(p => (p.SenderId == sender && p.RecieverId == reciever) 
                       || (p.SenderId == reciever && p.RecieverId == sender))
                .OrderByDescending(p => p.MessageDateTime);

            return await Task.FromResult(chat);
        }

 


        public async Task<User> GetUserByLoginPasswordAsync(string login, string password)
        {
            var user = _context.Users
                .Where(p=>p.Email == login && p.Password == password).FirstOrDefault();

            return await Task.FromResult(user);
        }

        public async Task<IEnumerable<User>> GetUserSearchResultsAsync(string exp)
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

        public async Task<Message> CreateMessageAsync(Message message)
        {
            var sent_mes = _context.Add(message);
            
            return await Task.FromResult(sent_mes.Entity);
        }

        public async Task<Message> UndoMessageAsync(Message message)
        {
            _context.Messages.Remove(message);

            return await Task.FromResult(message);
        }

        public async Task<IEnumerable<Message>> SetMessagesSeenAsync(int reader, int sender)
        {

            var messages = _context.Messages
                         .AsNoTracking()
                         .Where(p => p.SenderId == sender && p.RecieverId == reader)
                         .Where(p=>p.SenderId == sender)
                         .Where(p => p.HasSeen == false)
                         .OrderByDescending(p=>p.MessageDateTime)
                         .ToList();
            foreach (var el in messages)
            {
                     _context.Attach(el);
              
                el.HasSeen = true;

            }
                _context.SaveChanges();

            return await Task.FromResult(messages);
        }

        public async Task<User> GetUserInfoAsync(int userId)
        {
            var userInfo = _context.Users
                .AsNoTracking()
                .Include(p=>p.UserUnits)
                .ThenInclude(p=>p.UserDepartment)
                .Where(p => p.UserId == userId)
                .FirstOrDefault();

            return await Task.FromResult(userInfo);
        }
    }
}
