using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using static System.Net.WebRequestMethods;

namespace LogInSite.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UsersService usersService = new();
        PasswordService passwordService = new();
        

        [HttpPost]
        public ActionResult SingUp(User newUser)//how it works without [FromBody] ???
        {
            int strength = passwordService.passwordScore(newUser.Password);
            if (strength < 3)
            {
                return StatusCode(601);//it is possible to send a message and get it in client through res.test()
            }
            if(strength < 4)
            {
                return StatusCode(602);
            }
            User user = usersService.SingUp(newUser);
            return Ok(user);
        }

        [HttpPost("signIn")] 
        public ActionResult SignIn([FromBody] User user)
        {
            User userFound = usersService.SignIn(user);
            if (userFound==null)
                return NoContent();
            return Ok(userFound);
        }


        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            usersService.Put(id, user);

        }

    }
}
