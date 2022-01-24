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
        public async Task<ActionResult<IEnumerable<CourseListDto>>> GetUserCoursesListAsync(int UserId)
        {
            var course_list= await  _repository.GetUserCoursesListAsync(UserId);
            return Ok(_mapper.Map<IEnumerable<CourseListDto>>(course_list));
        }


        [HttpGet("{id}/courses/marks")]
        public async Task<ActionResult<IEnumerable<CourseMarksListDto>>> GetUserCoursesWithMarksAsync(int UserId)
        {
            var course_list = await _repository.GetUserCoursesListAsync(UserId);
            return Ok(_mapper.Map<IEnumerable<CourseMarksListDto>>(course_list));
        }


        [HttpGet("log/{login}={password}")]
        public async Task<ActionResult<CourseAssignment>> GetUserByLoginPasswordAsync(string login, string password)
        {
            var user = await _repository.GetUserByLoginPasswordAsync(login,password);
            return Ok(user);
        }


        [HttpGet("search/user/{exp}")]
        public async Task<ActionResult<IEnumerable<UserSearchDto>>> GetUserSearchResultsAsync(string exp)
        {
            var search_results= await _repository.GetUserByLoginPasswordAsync(exp);
            
            return Ok(_mapper.Map<IEnumerable<UserSearchDto>>(search_results));
        }



        [HttpPost("chat")]
        public async Task<ActionResult<Chat>> GetChatWithMessagesAsync(ChatRequestDot chatRequest)
        {

            var chat = await _repository.GetChatWithMessagesAsync(chatRequest.ChatId);
            if (chat != null)
            {
                chat.ChatMessageList= await _repository.GetMessageListByChat(chatRequest.ChatId);
                chat.Participants= await _repository.GerUsersListByChat(chatRequest.ChatId);
                return Ok(chat);
            }
            else
            {
                var chat_m= _mapper.Map<Chat>(chatRequest);
                chat_m = await _repository.CreateNewChatAsync(chat_m);
                return  Ok(chat_m);
            }

        }


        [HttpPost("chat/send")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> SendMeessageAsync(MessageDto mes)
        {
            var mapped_mes = _mapper.Map<Message>(mes);
            var search_results = await _repository.SendToChatMessageAsync(mapped_mes);

            if (search_results != null)
            {
                return Ok(search_results);
            }
            else 

            {
                // temp solution
                return NotFound();
            }
        }


        [HttpPatch("chat/message/{id}")]
        public async Task<ActionResult<IEnumerable<MessageDto>>> UpdateMessageAsync(int id, string content)
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
                // temp solution
                return NotFound();
            }
        }


        [HttpDelete("chat/message/{id}")]
        public async Task<ActionResult<IEnumerable<Chat>>> UndoMessageAsync(int id)
        {
            var message_undo= await _repository.UndoChatMessageAsync(id);
            if (message_undo != null)
            {
                _repository.SaveConfigs();
                return Ok(message_undo);
            }
            else
            {
                return NotFound();
            }
        }



    }
}
