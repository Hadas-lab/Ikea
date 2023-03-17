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
        IUsersService usersService;
        IPasswordService passwordService;

        public UsersController(IUsersService usersService, IPasswordService passwordService)
        {
            this.usersService = usersService;
            this.passwordService = passwordService;
        }


        [HttpPost]
        public async Task<ActionResult> SingUp(User newUser)//how it works without [FromBody] ???
        {
            int strength = await passwordService.passwordScore(newUser.Password);
            if (strength < 3)
            {
                return StatusCode(601);//it is possible to send a message and get it in client through res.test()
            }
            if(strength < 4)
            {
                return StatusCode(602);
            }
            User user = await usersService.SingUp(newUser);
            return Ok(user);
        }

        [HttpPost("signIn")]
        public async Task<ActionResult> SignIn([FromBody] User user)
        {
            User userFound =await usersService.SignIn(user);
            if (userFound==null)
                return NoContent();
            return Ok(userFound);
        }


        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User user)
        {
            await usersService.Put(id, user);

        }

    }
}
