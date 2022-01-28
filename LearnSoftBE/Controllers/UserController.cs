using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Data;
using LearnSoftBE.Models.CourseModels;
using AutoMapper;
using LearnSoftBE.Dtos;
using System.Text.Json;
using LearnSoftBE.Models.UserModels;
using LearnSoftBE.Models.ChatModels;

namespace LearnSoftBE.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserDataRepository _repository;
        private readonly IMapper _mapper;
        // private readonly ILogger<UserController> _logger;

        public UserController( IUserDataRepository repo, IMapper mapper)
        {
             // _logger = logger;
            _repository = repo;
            _mapper = mapper;
        }


        [HttpGet("{id}/courses/")]
        public async Task<ActionResult<IEnumerable<CourseListDto>>> GetUserCoursesListAsync(int id)
        {
            var course_list= await  _repository.GetUserCoursesListAsync(id);
            return Ok(_mapper.Map<IEnumerable<CourseListDto>>(course_list));
        }
        [HttpGet("/courses/{id}/info")]
        public async Task<ActionResult<CourseInfoDto>> GetCourseInfo(int id)
        {
            var courseInfo = await _repository.GetFullCourseInfo(id);
            if (courseInfo != null)
            {
                var asignedUsers = await _repository.GetAsignedUsersToCourse(courseInfo.ClassCycleId);
                courseInfo.CourseAssignments = asignedUsers;
                return Ok(_mapper.Map<CourseFullInfoDto>(courseInfo));

            }
            else{
                return NotFound();
            }
        }

        [HttpGet("{id}/courses/marks")]
        public async Task<ActionResult<IEnumerable<CourseMarksListDto>>> GetUserCoursesWithMarksAsync(int id)
        {
            var course_list = await _repository.GetUserCoursesListAsync(id);
            return Ok(_mapper.Map<IEnumerable<CourseMarksListDto>>(course_list));
        }


        [HttpGet("log/{login}={password}")]
        public async Task<ActionResult<CourseAssignment>> GetUserByLoginPasswordAsync(string login, string password)
        {
            var user = await _repository.GetUserByLoginPasswordAsync(login,password);
            if (user != null)
            {
                return Ok(_mapper.Map<LoginDto>(user));
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("search/user/{exp}")]
        public async Task<ActionResult<IEnumerable<UserSearchDto>>> GetUserSearchResultsAsync(string exp)
        {
            var search_results= await _repository.GetUserSearchResultsAsync(exp);
            
            return Ok(_mapper.Map<IEnumerable<UserSearchDto>>(search_results));
        }


        [HttpGet("info")]
        public async Task<ActionResult<UserSearchDto>> GetUserInfoAsync(int userId)
        {
            var userInfo = await _repository.GetUserInfoAsync(userId);
            if (userInfo != null)
            {
                return Ok(_mapper.Map<UserInfoDto>(userInfo));
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("chat/")]
        public async Task<ActionResult<ReturnMessageDto>> GetUsersChatAsync(int sender, int reciever)
        {
            
            var messages = await _repository.GetDirectMessagesAsync(sender,reciever);

            if (messages != null)
            {
               
                return Ok(_mapper.Map<IEnumerable<ReturnMessageDto>>(messages));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("chat/send")]
        public async Task<ActionResult<ReturnMessageDto>> SendMeessageAsync(MessageDto mes)
        {
            var mapped_mes = _mapper.Map<Message>(mes);
            var message= await _repository.CreateMessageAsync(mapped_mes);

            if (message!= null)
            {
                _repository.SaveConfigs();
                return Ok(_mapper.Map<ReturnMessageDto>(message));
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPatch("chat/message/update")]
        public async Task<ActionResult<MessageDto>> UpdateMessageAsync(int id, string content)
        {
 
            var search_results = await _repository.FindMessageById(id);
            if (search_results != null)
            {
                search_results.Body = content;
                search_results.MessageDateTime = DateTime.Now;
                _repository.SaveConfigs();
                return Ok(search_results);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("chat/message/undo")]
        public async Task<ActionResult<ReturnMessageDto>> UndoMessageAsync(int messageId,int userId)
        {

            var message = await _repository.FindMessageById(messageId);
            if (message != null)
            {
                if (message.SenderId == userId)
                {
                    await _repository.UndoMessageAsync(message);
                    _repository.SaveConfigs();
                    return Ok(_mapper.Map<ReturnMessageDto>(message));

                }
                else
                {
                    return BadRequest();
                }
   
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPatch("chat/messages/state")]
        public async Task<ActionResult<IEnumerable<ReturnMessageDto>>> SetSeenMessagesAsync(int reader, int sender)
        {

            var message = await _repository.SetMessagesSeenAsync(reader, sender);
            if (message != null)
            {
                return Ok(_mapper.Map<IEnumerable<ReturnMessageDto>>(message));
            }
            else
            {
                return Ok();
            }
         }

        }
}
