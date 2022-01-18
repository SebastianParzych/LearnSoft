using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnSoftBE.Data;
using LearnSoftBE.Models.UserModels;

namespace LearnSoftBE.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserDataRepository _repository;

        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserDataRepository repo)
        {
            // _logger = logger;
            _repository = repo;
        }

        [HttpGet("/courses")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserCoursesListAsync(int UserId)
        {
            //  var authorList =await  _repository.GetUserCoursesListAsync(UserId);
            var xd = 1;
            return Ok(xd);
        }

    }
}
