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
        public async Task<ActionResult<User>> GetUserSearchResults(string exp)
        {
           
            var user_list= await _repository.GetUserByLoginPasswordAsync(exp);

            return Ok(user_list);
        }
    }
}
