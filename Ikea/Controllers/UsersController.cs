using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using static System.Net.WebRequestMethods;

namespace LogInSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _usersService;
        IPasswordService _passwordService;

        public UsersController(IUserService usersService, IPasswordService passwordService)
        {
            _usersService = usersService;
            _passwordService = passwordService;
        }


        [HttpPost]
        public async Task<ActionResult> SingUp([FromBody] User newUser)//how it works without [FromBody] ???
        {
            int strength = await _passwordService.passwordScore(newUser.Password);
            if (strength < 2)
            {
                return StatusCode(601);
            }
            //if (strength < 3)
            //{
            //    return StatusCode(601);
            //}
            //if(strength < 4)
            //{
            //    return StatusCode(602);
            //}
            User user = await _usersService.SingUp(newUser);
            return Ok(user);
        }

        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn([FromBody] DemoUser user)//( User user)
        {
            User userFound =await _usersService.SignIn(user);
            if (userFound==null)
                return NoContent();
            return Ok(userFound);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User user)
        {
            int strength = await _passwordService.passwordScore(user.Password);
            if (strength < 2)
            {
                return StatusCode(601);
            }
            await _usersService.Put(id, user);
            return Ok(user);
        }

    }
}
