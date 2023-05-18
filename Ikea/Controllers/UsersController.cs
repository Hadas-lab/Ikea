using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using static System.Net.WebRequestMethods;
using DTO;
using AutoMapper;

namespace LogInSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService usersService, IMapper mapper, ILogger<UsersController> logger)
        {
            _usersService = usersService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult> SingUp([FromBody] User newUser) 
        {
            User user = await _usersService.SingUp(newUser);
            return user == null? NoContent() :Ok(user);
        }

        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn([FromBody] UserLoginDto user)//I need the userDto along the way???
        {
            //_logger.LogInformation($"Login attempt with User Name {user.Email} and password {user.Password}");
            //_logger.LogError("Error in your app");
            User userFound = await _usersService.SignIn(user);
            if (userFound == null)
                return NoContent();
            return Ok(userFound);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
        {
            
            bool success = await _usersService.Put(id, user);
            return success==true ? Ok(user): StatusCode(400);
        }

    }
}
